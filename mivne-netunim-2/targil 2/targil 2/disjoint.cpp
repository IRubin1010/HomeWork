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
	in >> rhs._ID;
	cout << "enter name" << endl;
	in >> rhs._name;
	cout << "enter address" << endl;
	in >> rhs._address;
	cout << "enter phone number" << endl;
	in >> rhs._phone;
	cout << "enter city" << endl;
	in >> rhs._city;
	return in;
}

ostream & operator<<(ostream & out, Volunteer & rhs)
{
	out << "id=" << rhs._ID << " name=" << rhs._name << " address=" << rhs._address << " phone=" << rhs._phone << " city=" << rhs._city << endl;
	return out;
}

DisjointSets::DisNode::~DisNode()
{

}

DisjointSets::Representor & DisjointSets::Representor::operator+=(Representor * & rhs)
{
	_size += rhs->_size;
	_tail->_next = rhs;
	DisNode * p = rhs;
	while (p != NULL)
	{
		p->_head = this;
		p = p->_next;
	}
	_tail = rhs->_tail;
	return *this;
}

void DisjointSets::makeSet(Volunteer * volunteer)
{
	Representor * newRep = new Representor(volunteer);
	representors.push_back(newRep);
	volunteers.insert(pair<int, DisNode*>(volunteer->ID(), newRep)); /////need to check if map can get a pointer to Representor
}

DisjointSets::Representor * DisjointSets::findSet(int ID)
{
	map<int, DisNode*>::iterator it;
	it = volunteers.find(ID);
	if (it == volunteers.end()) throw "no such volunteer";
	return (Representor*)it->second->_head;
}

void DisjointSets::unionSets(int id1, int id2)
{
	try
	{
		Representor * vol1 = findSet(id1);
		Representor * vol2 = findSet(id2);
		if (vol1 == vol2) return;
		if (vol1->_size > vol2->_size)
		{
			*(vol1) += vol2;
			representors.remove(vol2);
		}
		else
		{
			*(vol2) += vol1;
			representors.remove(vol1);
		}

	}
	catch (const char * msg)
	{
		throw msg;
	}
}

void DisjointSets::delVolunteer(int id)
{
	map<int, DisNode*>::iterator it = volunteers.find(id);
	if (it == volunteers.end()) throw "no such volunteer";
	DisNode * delVol = it->second;
	if (delVol->_head == delVol) // delete representor
	{
		if (delVol->_next != NULL) // more then one node
		{
			Representor * newRep = new Representor(delVol->_next->_volunteer); // create new representor
			newRep->_next = delVol->_next->_next;
			newRep->_size = ((Representor*)delVol)->_size - 1;
			newRep->_tail = ((Representor*)delVol)->_tail;
			if (newRep->_next != NULL) // more then tow nodes conect the rest of nodes to the new representor
			{
				DisNode * p = newRep->_next;
				while (p != NULL)
				{
					p->_head = newRep;
					p = p->_next;
				}
			}
			representors.remove((Representor*)delVol); // remove the old representor
			representors.push_back(newRep); // add the new representor
			volunteers.erase(delVol->_next->_volunteer->ID());// erase the second node from the map
			volunteers.insert(pair<int, DisNode*>(newRep->_volunteer->ID(), newRep));
		}
	}
	else
	{
		((Representor*)delVol->_head)->_size--;
		DisNode * p = delVol->_head;
		while (p->_next != delVol)
		{
			p = p->_next;
		}
		p->_next = delVol->_next;
		if (((Representor*)delVol->_head)->_tail == delVol)
		{
			((Representor*)delVol->_head)->_tail = p;
		}
	}
	volunteers.erase(delVol->_volunteer->ID());
	delete delVol;
}



void DisjointSets::printSet(int id)
{
	try
	{
		DisNode * volunteer = findSet(id)->_head;
		while (volunteer != NULL)
		{
			cout << *(volunteer->_volunteer) << endl;
			volunteer = volunteer->_next;
		}
	}
	catch (const char * msg)
	{
		throw msg;
	}

}

void DisjointSets::printRepresentatives()
{
	if (representors.empty()) throw "there is no volunteers";
	list<Representor*>::iterator it;
	for (it = representors.begin(); it != representors.end(); it++)
	{
		cout << *((*it)->_volunteer) << endl;
	}
}

void DisjointSets::printAllVolunteers()
{
	if (representors.empty()) throw "there is no volunteers";
	list<Representor*>::iterator it;
	for (it = representors.begin(); it != representors.end(); it++)
	{
		DisNode * p = *it;
		while (p != NULL)
		{
			cout << *(p->_volunteer) << endl;
			p = p->_next;
		}
		cout << "**********" << endl;
	}
}


