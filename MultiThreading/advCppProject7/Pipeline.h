#ifndef PIPELINE_H
#define PIPELINE_H

#include <condition_variable>
#include <cstdlib>
#include <iostream>
#include <mutex>
#include <queue>
#include <thread>


class Pipeline
{
    static std::queue<int> q;
    static std::condition_variable q_cond;
    static std::mutex q_sync, prod, print;
    static size_t nprod;
public:
    static const size_t nprods = 10, ncons = 2;
    static void consume() {
        for (;;) {
            // Get lock for sync mutex
            std::unique_lock<std::mutex> qlck(q_sync);

            // Check for end of program (no live producers, no data left); note stand-alone scope block
            {
                std::lock_guard<std::mutex> plck(prod);
                if (nprod == 0 && q.empty())
                    break;
            }

            // Wait for queue to have something to process
            q_cond.wait(qlck, []() {return !q.empty(); });
            auto x = q.front();
            q.pop();
            qlck.unlock();

            // Print trace of consumption
            std::lock_guard<std::mutex> plck(print);
            std::cout << x << " consumed" << std::endl;
        }
    }

    static void produce(int i) {
        // Generate 20 random ints
        srand(time(nullptr) + i);
        for (int i = 0; i < 20; ++i) {
            int n = rand();     // Get random int

            // Get lock for sync mutex; push int
            std::unique_lock<std::mutex> slck(q_sync);
            q.push(n);
            slck.unlock();
            q_cond.notify_one();

            // Get lock for print mutex
            std::lock_guard<std::mutex> plck(print);
            std::cout << n << " produced" << std::endl;
        }

        // Notify consumers that a producer has shut down
        --nprod;
        q_cond.notify_all();
    }
};

std::queue<int> Pipeline::q;
std::condition_variable Pipeline::q_cond;
std::mutex Pipeline::q_sync, Pipeline::prod, Pipeline::print;
size_t Pipeline::nprod = nprods;




#endif


/*

#include <condition_variable>
#include <cstdlib>
#include <iostream>
#include <mutex>
#include <queue>
#include <thread>
using namespace std;

class ProducerConsumer {
    static queue<int> q;
    static condition_variable q_cond;
    static mutex q_sync, prod, print;
    static size_t nprod;
public:
    static const size_t nprods = 10, ncons = 2;
    static void consume() {
        for (;;) {
            // Get lock for sync mutex
            unique_lock<mutex> qlck(q_sync);

            // Check for end of program (no live producers, no data left); note stand-alone scope block
            {
                lock_guard<mutex> plck(prod);
                if (nprod == 0 && q.empty())
                    break;
            }

            // Wait for queue to have something to process
            q_cond.wait(qlck,[](){return !q.empty();});
            auto x = q.front();
            q.pop();
            qlck.unlock();

            // Print trace of consumption
            lock_guard<mutex> plck(print);
            cout << x << " consumed" << endl;
        }
    }

    static void produce(int i) {
        // Generate 20 random ints
        srand(time(nullptr)+i);
        for (int i = 0; i < 20; ++i) {
            int n = rand();     // Get random int

            // Get lock for sync mutex; push int
            unique_lock<mutex> slck(q_sync);
            q.push(n);
            slck.unlock();
            q_cond.notify_one();

            // Get lock for print mutex
            lock_guard<mutex> plck(print);
            cout << n << " produced" << endl;
        }

        // Notify consumers that a producer has shut down
        --nprod;
        q_cond.notify_all();
    }
};

queue<int> ProducerConsumer::q;
condition_variable ProducerConsumer::q_cond;
mutex ProducerConsumer::q_sync, ProducerConsumer::prod, ProducerConsumer::print;
size_t ProducerConsumer::nprod = nprods;

int main() {
    vector<thread> prods, cons;
    for (int i = 0; i < ProducerConsumer::ncons; ++i)
        cons.push_back(thread(&ProducerConsumer::consume));
    for (int i = 0; i < ProducerConsumer::nprods; ++i)
        prods.push_back(thread(&ProducerConsumer::produce,i));

    // Join all threads
    for (auto &p: prods)
        p.join();
    for (auto &c: cons)
        c.join();
}

*/