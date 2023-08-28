This program uses 10 threads in a consumer, producer model to create 1000 ints concurrently.
The threads write the ints to 10 different text files based on the modulus of the generated int.
The program then prints the number of ints written to each file.