#ifndef __TESTHASH_H
#define __TESTHASH_H
#include "HashTable.h"
#include <iostream>
using namespace std;

class TestHash : public HashTable<int, int>
{
public:
	TestHash(int num): HashTable<int,int>(num){}
	int H1(int key);
	int H2(int key);
};

#endif // !__TESTHASH_H

