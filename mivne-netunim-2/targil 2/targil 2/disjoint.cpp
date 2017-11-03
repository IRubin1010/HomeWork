#include <iostream>
#include "disjoint.h"
using namespace std;

Volunteer::Volunteer(Volunteer & volunteer)
{
	_ID = volunteer._ID;
	_name = volunteer._name;
	_address = volunteer._address;
	_phone = volunteer._phone;
	_city = volunteer._city;
}

istream & operator>>(istream & in, Volunteer & rhs)
{
	cout << "enter ID" << endl;
	cin >> rhs._ID;
	cout << "enter name" << endl;
	cin >> rhs._name;
	cout << "enter address" << endl;
	cin >> rhs._address;
	cout << "enter phone number" << endl;
	cin >> rhs._phone;
	cout << "enter city" << endl;
	cin >> rhs._city;
	return in;
}

ostream & operator<<(ostream & out, Volunteer & rhs)
{
	cout << "id=" << rhs._ID << " name=" << rhs._name << " address=" << rhs._address << " phone=" << rhs._phone << " city=" << rhs._city << endl;
	return out;
}

DisjointSets::Representor *& DisjointSets::Representor::operator+=(Representor * & rhs)
{
	_tail = rhs->_tail;
	_size = rhs->_size;
	_tail->_next = rhs->_head;
	DisNode * p = rhs;
	while (p->_next != NULL)
	{
		p->_head = _head;
		p = p->_next;
	}
	Representor * pRepresentor = this;
	return pRepresentor;
}

void DisjointSets::makeSet(Volunteer * volunteer)
{
	Representor * newRep = new Representor(volunteer);
	representors.push_back(newRep);
	volunteers[volunteer->ID] = volunteer;
}

Volunteer * DisjointSets::findSet(int ID)
{
	map<int, Volunteer*>::iterator it;
	it = volunteers.find(ID);
	if (it == volunteers.end()) throw "no such volunteer";
	return it->second;
}
