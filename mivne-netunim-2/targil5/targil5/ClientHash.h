#ifndef __CLIENTHASH_H
#define __CLIENTHASH_H
#include "HashTable.h"
#include "Client.h"
using namespace std;

class ClientHash : public HashTable<Client, int>
{
public:
	ClientHash(int num) : HashTable(num) {}
	int H1(int key);
	int H2(int key);
	
	list<string> getClientList(string name);
};


#endif // !__CLIENTHASH_H

