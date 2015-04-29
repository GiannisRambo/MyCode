// SimpleCppConsumer.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "SimpleLabViewDll.h"

#include <iostream>

int _tmain(int argc, _TCHAR* argv[])
{
	// Test setting and getting a 32-bit integer
	Set32bitInteger(200);

	int32_t res = Get32bitInteger();
	std::cout << "\nres = " << res;

	// Test getting an error code from LabVIEW and translating the code
	// into a string description
	int32_t errorCode = GetError();
	std::cout << "\nerrorCode = " << errorCode;

	int32_t testArray[5] = {1, 2, 3, 4, 5};
	Set32bitIntegerArray(testArray, 5);
	LStrHandle errText;
	NIGetOneErrorCode(errorCode, &errText);
	
	int32_t* targetArray = new int32_t[5];
	int32_t bytesRead = 5;
	Get32bitIntegerArray(targetArray, &bytesRead);
	for (int i=0; i<bytesRead; i++) {
		std::cout << "\n[" << i << "] = " << targetArray[i];
	}

	// Array Data Pointer
	// Array Handle Pointer
	return 0;
}
