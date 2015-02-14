test_32: nasm_32.o main_32.o
	g++ -m32 -o test_32 nasm_32.o main_32.o

nasm_32.o: nasm_32.s 
	nasm -f elf32 -o nasm_32.o nasm_32.s

main_32.o: main_32.cpp
	g++ -m32 -c main_32.cpp -o main_32.o

clean:
	rm *.o test_32
