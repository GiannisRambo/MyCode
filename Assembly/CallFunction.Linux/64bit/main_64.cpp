
#include <iostream>

extern "C" int multiply_me( int a, int b, int c, int d, int e, int f);

int main ( int argc, char * argv[] ) {

	std::cout << "\nCalling an Assembly language function from C++ on 64-bit Linux: ";
	std::cout << "\nResult: " << multiply_me ( 1, 2, 3, 4, 5, 6 ) << std::endl;

	return 0;
}
