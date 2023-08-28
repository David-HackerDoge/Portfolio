#include <iostream>
#include <thread>
#include <condition_variable>
#include <cstdlib>
#include <iostream>
#include <mutex>
#include <queue>
#include <thread>
#include <fstream>
#include <string>

using namespace std;

class ProducerConsumer {
    static queue<int> q;
    static queue<int> q2;
    static condition_variable q_cond, q_cond2;
    static mutex q_sync, q_sync2, prod, con, print;
    static size_t nprod, ncon;
public:
    static const size_t nprods = 4, ncons = 3;
    static void consume() {
        for (;;) {
            // Get lock for sync mutex
            unique_lock<mutex> qlck(q_sync);

            // Check for end of program (no live producers, no data left); note stand-alone scope block
            {
                lock_guard<mutex> plck(prod);
                if (nprod == 0 && q.empty())
                {
                    lock_guard<mutex> clck(con);
                    ncon--;
                    break;
                }
            }

            // Wait for queue to have something to process
            q_cond.wait(qlck, []() {return !q.empty(); });
            auto x = q.front();
            q.pop();
            qlck.unlock();

            if (x % 3 != 0)
            {
                lock_guard<mutex> qlck2(q_sync2);
                q2.push(x);
            }

        }
    }

    static void produce(int i) {
        // Generate 1000 random ints
        srand(time(nullptr) + i);
        for (int i = 0; i < 1000; ++i) {
            int n = rand();     // Get random int

            // Get lock for sync mutex; push int
            unique_lock<mutex> slck(q_sync);
            q.push(n);
            slck.unlock();
            q_cond.notify_one();
        }

        // Notify consumers that a producer has shut down
        --nprod;
        q_cond.notify_all();
    }

    
    static void fileOut(size_t filter){
        for (;;) {
            bool correctFilter = false;
            // Get lock for sync mutex
            unique_lock<mutex> qlck2(q_sync2);

            // Check for end of program (no live consumers, no data left); note stand-alone scope block
            {
                lock_guard<mutex> clck(con);
                if (ncon == 0 && q2.empty())
                    break;
            }

            // Wait for queue to have something to process
            q_cond2.wait(qlck2, []() {return !q2.empty(); });
            auto x = q2.front();
            if (x % 10 == filter)
            {
                q2.pop();
                correctFilter = true;
            }
            qlck2.unlock();

            if (correctFilter == true)
            {
                if (filter == 0)
                {
                    ofstream file;
                    file.seekp(ios::end);
                    file.open("file0.txt", fstream::app);
                    file << x << "\n";
                }
                if (filter == 1)
                {
                    ofstream file;
                    file.seekp(ios::end);
                    file.open("file1.txt", fstream::app);
                    file << x << "\n";
                }
                if (filter == 2)
                {
                    ofstream file;
                    file.seekp(ios::end);
                    file.open("file2.txt", fstream::app);
                    file << x << "\n";
                }
                if (filter == 3)
                {
                    ofstream file;
                    file.seekp(ios::end);
                    file.open("file3.txt", fstream::app);
                    file << x << "\n";
                }
                if (filter == 4)
                {
                    ofstream file;
                    file.open("file4.txt", fstream::app);
                    file.seekp(ios::end);
                    file << x << "\n";
                }
                if (filter == 5)
                {
                    ofstream file;
                    file.open("file5.txt", fstream::app);
                    file.seekp(ios::end);
                    file << x << "\n";
                }
                if (filter == 6)
                {
                    ofstream file;
                    file.open("file6.txt", fstream::app);
                    file.seekp(ios::end);
                    file << x << "\n";
                }
                if (filter == 7)
                {
                    ofstream file;
                    file.open("file7.txt", fstream::app);
                    file.seekp(ios::end);
                    file << x << "\n";
                }
                if (filter == 8)
                {
                    ofstream file;
                    file.open("file8.txt", fstream::app);
                    file.seekp(ios::end);
                    file << x << "\n";
                }
                if (filter == 9)
                {
                    ofstream file;
                    file.open("file9.txt", fstream::app);
                    file.seekp(ios::end);
                    file << x << "\n";
                }
            }

        }
    }
    
};

queue<int> ProducerConsumer::q;
queue<int> ProducerConsumer::q2;
condition_variable ProducerConsumer::q_cond;
condition_variable ProducerConsumer::q_cond2;
mutex ProducerConsumer::q_sync, ProducerConsumer::q_sync2, ProducerConsumer::con, ProducerConsumer::prod, ProducerConsumer::print;
size_t ProducerConsumer::nprod = nprods;
size_t ProducerConsumer::ncon = ncons;


int main() {

    const int FILTERS = 10;

    /*
    vector<fstream> files;


    files.push_back(fstream("file0.txt"));
    files.push_back(fstream("file1.txt"));
    files.push_back(fstream("file2.txt"));
    files.push_back(fstream("file3.txt"));
    files.push_back(fstream("file4.txt"));
    files.push_back(fstream("file5.txt"));
    files.push_back(fstream("file6.txt"));
    files.push_back(fstream("file7.txt"));
    files.push_back(fstream("file8.txt"));
    files.push_back(fstream("file9.txt"));
    */




    ofstream file0;
    file0.open("file0.txt");
    ofstream file1;
    file1.open("file1.txt");
    ofstream file2;
    file2.open("file2.txt");
    ofstream file3;
    file3.open("file3.txt");
    ofstream file4;
    file4.open("file4.txt");
    ofstream file5;
    file5.open("file5.txt");
    ofstream file6;
    file6.open("file6.txt");
    ofstream file7;
    file7.open("file7.txt");
    ofstream file8;
    file8.open("file8.txt");
    ofstream file9;
    file9.open("file9.txt");


    vector<thread> prods, cons, fileOuts;
    for (int i = 0; i < ProducerConsumer::ncons; ++i)
        cons.push_back(thread(&ProducerConsumer::consume));
    for (int i = 0; i < ProducerConsumer::nprods; ++i)
        prods.push_back(thread(&ProducerConsumer::produce, i));
    for (int i = 0; i < FILTERS; ++i)
    {
        if (i == 0)
            fileOuts.push_back(thread(&ProducerConsumer::fileOut, i));
        if (i == 1)
            fileOuts.push_back(thread(&ProducerConsumer::fileOut, i));
        if (i == 2)
            fileOuts.push_back(thread(&ProducerConsumer::fileOut, i));
        if (i == 3)
            fileOuts.push_back(thread(&ProducerConsumer::fileOut, i));
        if (i == 4)
            fileOuts.push_back(thread(&ProducerConsumer::fileOut, i));
        if (i == 5)
            fileOuts.push_back(thread(&ProducerConsumer::fileOut, i));
        if (i == 6)
            fileOuts.push_back(thread(&ProducerConsumer::fileOut, i));
        if (i == 7)
            fileOuts.push_back(thread(&ProducerConsumer::fileOut, i));
        if (i == 8)
            fileOuts.push_back(thread(&ProducerConsumer::fileOut, i));
        if (i == 9)
            fileOuts.push_back(thread(&ProducerConsumer::fileOut, i));
    }

    // Join all threads
    for (auto& f : fileOuts)
        f.join();
    for (auto& p : prods)
        p.join();
    for (auto& c : cons)
        c.join();


    
    //print out number of lines in each file

    ifstream fileRead;
    fileRead.open("file0.txt");
    string line;
    int numLines = 0;
    while (getline(fileRead, line))
        numLines++;
    fileRead.close();
    cout << "group 0 has " << numLines << " numbers" << endl;
    numLines = 0;
    fileRead.open("file1.txt");
    while (getline(fileRead, line))
        numLines++;
    fileRead.close();
    cout << "group 1 has " << numLines << " numbers" << endl;
    numLines = 0;
    fileRead.open("file2.txt");
    while (getline(fileRead, line))
        numLines++;
    fileRead.close();
    cout << "group 2 has " << numLines << " numbers" << endl;
    numLines = 0;
    fileRead.open("file3.txt");
    while (getline(fileRead, line))
        numLines++;
    fileRead.close();
    cout << "group 3 has " << numLines << " numbers" << endl;
    numLines = 0;
    fileRead.open("file4.txt");
    while (getline(fileRead, line))
        numLines++;
    fileRead.close();
    cout << "group 4 has " << numLines << " numbers" << endl;
    numLines = 0;
    fileRead.open("file5.txt");
    while (getline(fileRead, line))
        numLines++;
    fileRead.close();
    cout << "group 5 has " << numLines << " numbers" << endl;
    numLines = 0;
    fileRead.open("file6.txt");
    while (getline(fileRead, line))
        numLines++;
    fileRead.close();
    cout << "group 6 has " << numLines << " numbers" << endl;
    numLines = 0;
    fileRead.open("file7.txt");
    while (getline(fileRead, line))
        numLines++;
    fileRead.close();
    cout << "group 7 has " << numLines << " numbers" << endl;
    numLines = 0;
    fileRead.open("file8.txt");
    while (getline(fileRead, line))
        numLines++;
    fileRead.close();
    cout << "group 8 has " << numLines << " numbers" << endl;
    numLines = 0;
    fileRead.open("file9.txt");
    while (getline(fileRead, line))
        numLines++;
    fileRead.close();
    cout << "group 9 has " << numLines << " numbers" << endl;
    

}