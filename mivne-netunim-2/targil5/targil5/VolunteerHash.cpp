#include "VolunteerHash.h"
#include <string>

int VolunteerHash::H1(string key)
{
	int hash = 0;
	for (int i = 0; i < key.length(); i++)
	{
		hash += static_cast<int>(key[i]);
	}
	return hash % size;
}

int VolunteerHash::H2(string key)
{
	int hash = 0;
	for (int i = 0; i < key.length(); i++)
	{
		hash += static_cast<int>(key[i]);
	}
	return hash % 5;
}

