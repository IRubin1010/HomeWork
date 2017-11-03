#ifndef __DISJOINT_H
#define __DISJOINT_H
#include <iostream>
#include <string>
using namespace std;


class Volunteer
{
private:
	int _ID;
	string _name;
	string _address;
	int _phone;
	string _city;
public:
	Volunteer() {};
	Volunteer(Volunteer & volunteer);
	friend istream & operator >> (istream & in, Volunteer & rhs);
	friend ostream & operator << (ostream & out, Volunteer & rhs);
};

class DisjointSets
{
	class DisNode
	{
	public:
		Volunteer * _volunteer;
		DisNode * _next;
		DisNode * _representor;
		DisNode(Volunteer * volunteer) { _volunteer = volunteer; _next = NULL; _representor = this; }
		~DisNode(){} /////////// need to implement
	};
	class Representor :public DisNode
	{
	public:
		DisNode *_tail;
		int _size;
		Representor(Volunteer * volunteer) :DisNode(volunteer) { _tail = this; _size = 1; }
		Representor & operator +=(Representor rhs); // need to implement
	};

};









#endif // !__DISJOINT_H

