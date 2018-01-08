#include "ClientHash.h"

int ClientHash::H1(int key)
{
	return key % size;
}

int ClientHash::H2(int key)
{
	return key % 5;
}

list<string> ClientHash::getClientList(string name)
{
	list<string> volunteers;
	print();
	for (int i = 0; i < size; i++)
	{
		if (table[i].data.IsVolunteer(name))
			volunteers.push_front(table[i].data.getName());
	}
	volunteers.sort();
	return volunteers;
}
