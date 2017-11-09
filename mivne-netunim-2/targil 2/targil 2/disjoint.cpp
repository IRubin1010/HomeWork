#include <iostream>
#include "disjoint.h"
using namespace std;

// copy constractor
Volunteer::Volunteer(Volunteer & volunteer)
{
	_ID = volunteer._ID;
	_name = volunteer._name;
	_address = volunteer._address;
	_phone = volunteer._phone;
	_city = volunteer._city;
}

// input operator
istream & operator>>(istream & in, Volunteer & rhs)
{
	in >> rhs._ID >> rhs._name >> rhs._address >> rhs._phone >> rhs._city;
	return in;
}

// utput operator
ostream & operator<<(ostream & out, Volunteer & rhs)
{
	out << "id=" << rhs._ID << " name=" << rhs._name << " address=" << rhs._address << " phone=" << rhs._phone << " city=" << rhs._city << endl;
	return out;
}

// distractor
DisjointSets::DisNode::~DisNode()
{
	delete _volunteer;
	_volunteer = NULL;
}

// += operator
DisjointSets::Representor & DisjointSets::Representor::operator+=(Representor * & rhs)
{
	_size += rhs->_size;
	_tail->_next = rhs;
	DisNode * p = rhs;
	while (p != NULL) // go over rhs and update the head
	{
		p->_head = this;
		p = p->_next;
	}
	_tail = rhs->_tail;
	return *this;
}

// distractor
DisjointSets::~DisjointSets()
{
	//if (representors.empty()) throw "there is no volunteers";
	list<Representor*>::iterator it;
	for (it = representors.begin(); it != representors.end(); it++)
	{
		delete *it;
		*it = NULL;
	}
}

// make set
void DisjointSets::makeSet(Volunteer * volunteer)
{
	Representor * newRep = new Representor(volunteer); // create new volunteer
	representors.push_back(newRep); // push the new representor the the list of representors
	volunteers.insert(pair<int, DisNode*>(volunteer->ID(), newRep)); // insert the new volunteer into the map
}

// find set - find a volunteer representor
DisjointSets::Representor * DisjointSets::findSet(int ID)
{
	map<int, DisNode*>::iterator it = volunteers.find(ID); // find the vounteer in map
	if (it == volunteers.end()) throw "no such volunteer"; // if didn't find the volunteer
	return (Representor*)it->second->_head; // return the representor
}

// union
void DisjointSets::unionSets(int id1, int id2)
{
	try
	{
		Representor * vol1 = findSet(id1); // get the first volunteer
		Representor * vol2 = findSet(id2); // get the seconed volunteer
		if (vol1 == vol2) return; // if the same representor
		if (vol1->_size > vol2->_size) // if vol1 bigger then vol2
		{
			*(vol1) += vol2; // conect vol2 to vol1
			representors.remove(vol2); // remove from representor list vol2
		}
		else // if vol2 bigger then vol1
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

// delete a volunteer
void DisjointSets::delVolunteer(int id)
{
	map<int, DisNode*>::iterator it = volunteers.find(id); // get the volunteer
	if (it == volunteers.end()) throw "no such volunteer"; // if didn't find
	DisNode * delVol = it->second;
	if (delVol->_head == delVol) //if delete representor
	{
		if (delVol->_next != NULL) //if there is to this representor more then one node
		{
			Representor * newRep = new Representor(delVol->_next->_volunteer); // create new representor
			newRep->_next = delVol->_next->_next; // conect the next of the new repesentor 
			newRep->_size = ((Representor*)delVol)->_size - 1; // put the size
			newRep->_tail = ((Representor*)delVol)->_tail; // conect the tail
			if (newRep->_next != NULL) // if there is more then tow nodes conect the rest of nodes to the new representor
			{
				DisNode * p = newRep->_next;
				while (p != NULL)
				{
					p->_head = newRep;
					p = p->_next;
				}
			}
			representors.push_back(newRep); // add the new representor
			volunteers.erase(delVol->_next->_volunteer->ID());// erase the second node from the map
			volunteers.insert(pair<int, DisNode*>(newRep->_volunteer->ID(), newRep)); // add the new volunteer
		}
		representors.remove((Representor*)delVol); // remove the old representor
	}
	else // dont delete a representor
	{
		((Representor*)delVol->_head)->_size--;
		DisNode * p = delVol->_head;
		while (p->_next != delVol) // find the volenteer
		{
			p = p->_next;
		}
		p->_next = delVol->_next;
		if (((Representor*)delVol->_head)->_tail == delVol) // if delete a tail
		{
			((Representor*)delVol->_head)->_tail = p;
		}
	}
	volunteers.erase(delVol->_volunteer->ID());
	delete delVol;
}

// print volunteers of a representor
void DisjointSets::printSet(int id)
{
	try
	{
		DisNode * volunteer = findSet(id)->_head; // find the representor
		while (volunteer != NULL)
		{
			cout << *(volunteer->_volunteer) << endl; // print the volunteer
			volunteer = volunteer->_next;
		}
	}
	catch (const char * msg)
	{
		throw msg;
	}

}

// print the representors
void DisjointSets::printRepresentatives()
{
	if (representors.empty()) throw "there is no volunteers";
	list<Representor*>::iterator it;
	for (it = representors.begin(); it != representors.end(); it++)
	{
		cout << *((*it)->_volunteer) << endl;
	}
}

// print all volunteers
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


