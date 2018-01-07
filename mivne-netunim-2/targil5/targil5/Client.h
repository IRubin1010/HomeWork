#ifndef __CLIENT_H
#define __CLIENT_H
#include <iostream>
#include <list>
#include <string>
using namespace std;

class Client
{
private:
	string name;
	int phone;
	string city;
	list<string> volunteers;
public:
	Client(){}
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



#endif // !__CLIENT_H
