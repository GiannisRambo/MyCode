#include<iostream>
using namespace std;

extern "C" int multiply_me( int a, int b, int c, int d, int e, int f);

int main() {
	cout << "Multiplication returned " << multiply_me(1, 2, 3, 4, 5, 6) << endl;
	return 0;
}
