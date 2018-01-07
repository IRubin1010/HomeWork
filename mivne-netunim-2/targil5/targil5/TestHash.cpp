#include "TestHash.h"

int TestHash::H1(int key)
{
	return key % size;
}

int TestHash::H2(int key)
{
	return key % 5;
}
