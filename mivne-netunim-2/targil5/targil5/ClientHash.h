#ifndef __CLIENTHASH_H
#define __CLIENTHASH_H
#include "HashTable.h"
#include <list>
#include <string>
//#include "Client.h"
using namespace std;

class Client
{
private:
	string name;
	int phone;
	string city;
	list<string> volunteers;
public:
	Client() {}
	Client(const Client & rhs);
	Client & operator = (const Client & rhs);
	int getPhone() { return phone; }
	string getName() { return name; }
	bool operator == (const Client & rhs)const;

	bool IsVolunteer(string volName);
	void addVolunteerToList(string name);
	void printListOfVolunteers();

	friend istream & operator >> (istream & in, Client & rhs); // overide input operator
	friend ostream & operator << (ostream & out, Client & rhs); // overide output operator
};

class ClientHash : public HashTable<Client, int>
{
public:
	ClientHash(int num) : HashTable(num) {}
	int H1(int key);
	int H2(int key);
	
	list<string> getClientList(string name);
};


#endif // !__CLIENTHASH_H

