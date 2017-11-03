#ifndef __DISJOINT_H
#define __DISJOINT_H
#include <iostream>
#include <string>
#include <list>
#include <map>
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
	int ID() { return _ID; }
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
		DisNode * _head;
		DisNode(Volunteer * volunteer) { _volunteer = volunteer; _next = NULL; _head = this; }
		~DisNode(){} /////////// need to implement
	};
	class Representor :public DisNode
	{
	public:
		DisNode *_tail;
		int _size;
		Representor(Volunteer * volunteer) :DisNode(volunteer) { _tail = this; _size = 1; }
		Representor *& operator +=(Representor * & rhs); // need to check the implementation
	};
	list<Representor*> representors;
	map<int, Volunteer*> volunteers;
public:
	DisjointSets() {}
	void makeSet(Volunteer * volunteer);
	Volunteer * findSet(int ID);


};









#endif // !__DISJOINT_H

