#ifndef __DISJOINT_H
#define __DISJOINT_H
#include <iostream>
#include <string>
#include <list>
#include <map>
using namespace std;

// declare a volunteer
class Volunteer
{
private:
	int _ID;
	string _name;
	string _address;
	int _phone;
	string _city;
public:
	Volunteer() {}; // constractor
	Volunteer(Volunteer & volunteer); // copy constractor
	int ID() { return _ID; } // geter
	friend istream & operator >> (istream & in, Volunteer & rhs); // overide input operator
	friend ostream & operator << (ostream & out, Volunteer & rhs); // overide output operator
};


class DisjointSets
{
	class DisNode
	{
	public:
		Volunteer * _volunteer; // point to volunteer
		DisNode * _next; // point to the next volunteer
		DisNode * _head; // point to representor
		DisNode(Volunteer * volunteer) { _volunteer = volunteer; _next = NULL; _head = this; } // constractor
		virtual ~DisNode(); /////////// need to implement
	};
	class Representor :public DisNode
	{
	public:
		DisNode *_tail; // point to the end 
		int _size; // size of volunteers in the group
		Representor(Volunteer * volunteer) :DisNode(volunteer) { _tail = this; _size = 1; } // constractor
		Representor & operator +=(Representor * & rhs); // overide += operator
		~Representor() {};
	};
	list<Representor*> representors; // list of the representors
	map<int, DisNode*> volunteers; // map of all volunters
public:
	DisjointSets() {} // constractor
	~DisjointSets();
	void makeSet(Volunteer * volunteer); 
	Representor * findSet(int ID);
	void unionSets(int id1, int id2);
	void delVolunteer(int id);
	void printSet(int id);
	void printRepresentatives();
	void printAllVolunteers();
};

#endif // !__DISJOINT_H

