#ifndef __DISJOINT_H
#define __DISJOINT_H
#include <iostream>
#include <string>
<<<<<<< HEAD
<<<<<<< HEAD
#include <list>
#include <map>
=======
>>>>>>> master
=======
#include <list>
#include <map>
>>>>>>> b8cd4979ac401e1ba925645da6b6422cea11acaf
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
<<<<<<< HEAD
	int ID() { return _ID; }
=======
>>>>>>> master
=======
	int ID() { return _ID; }
>>>>>>> b8cd4979ac401e1ba925645da6b6422cea11acaf
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
<<<<<<< HEAD
		DisNode * _head;
		DisNode(Volunteer * volunteer) { _volunteer = volunteer; _next = NULL; _head = this; }
=======
		DisNode * _representor;
		DisNode(Volunteer * volunteer) { _volunteer = volunteer; _next = NULL; _representor = this; }
>>>>>>> master
=======
		DisNode * _head;
		DisNode(Volunteer * volunteer) { _volunteer = volunteer; _next = NULL; _head = this; }
>>>>>>> b8cd4979ac401e1ba925645da6b6422cea11acaf
		~DisNode(){} /////////// need to implement
	};
	class Representor :public DisNode
	{
	public:
		DisNode *_tail;
		int _size;
		Representor(Volunteer * volunteer) :DisNode(volunteer) { _tail = this; _size = 1; }
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> b8cd4979ac401e1ba925645da6b6422cea11acaf
		Representor *& operator +=(Representor * & rhs); // need to check the implementation
	};
	list<Representor*> representors;
	map<int, Volunteer*> volunteers;
public:
	DisjointSets() {}
	void makeSet(Volunteer * volunteer);
	Volunteer * findSet(int ID);

<<<<<<< HEAD
=======
		Representor & operator +=(Representor rhs); // need to implement
	};
>>>>>>> master

=======
>>>>>>> b8cd4979ac401e1ba925645da6b6422cea11acaf
};









#endif // !__DISJOINT_H

