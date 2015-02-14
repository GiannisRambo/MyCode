test_64: nasm_64.o main_64.o
	g++ -m64 -o test_64 nasm_64.o main_64.o

nasm_64.o: nasm_64.s 
	nasm -f elf64 -o nasm_64.o nasm_64.s

main_64.o: main_64.cpp
	g++ -m64 -c main_64.cpp -o main_64.o

clean:
	rm *.o test_64
