#include "MyClass.h"
#include <iostream>

MyClass::MyClass()
{
	std::cout << "MyClass::MyClass()" << std::endl;
}

MyClass::~MyClass()
{
	std::cout << "MyClass::~MyClass()" << std::endl;
}