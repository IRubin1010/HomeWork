#ifndef __DISJOINT_H
#define __DISJOINT_H
#include <iostream>
#include <string>
<<<<<<< HEAD
#include <list>
#include <map>
=======
>>>>>>> master
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
<<<<<<< HEAD
	int ID() { return _ID; }
=======
>>>>>>> master
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
<<<<<<< HEAD
		DisNode * _head;
		DisNode(Volunteer * volunteer) { _volunteer = volunteer; _next = NULL; _head = this; }
=======
		DisNode * _representor;
		DisNode(Volunteer * volunteer) { _volunteer = volunteer; _next = NULL; _representor = this; }
>>>>>>> master
		~DisNode(){} /////////// need to implement
	};
	class Representor :public DisNode
	{
	public:
		DisNode *_tail;
		int _size;
		Representor(Volunteer * volunteer) :DisNode(volunteer) { _tail = this; _size = 1; }
<<<<<<< HEAD
		Representor *& operator +=(Representor * & rhs); // need to check the implementation
	};
	list<Representor*> representors;
	map<int, Volunteer*> volunteers;
public:
	DisjointSets() {}
	void makeSet(Volunteer * volunteer);
	Volunteer * findSet(int ID);

=======
		Representor & operator +=(Representor rhs); // need to implement
	};
>>>>>>> master

};









#endif // !__DISJOINT_H

