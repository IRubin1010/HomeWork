#include "ClientHash.h"

Client::Client(const Client & rhs)
{
	name = rhs.name;
	phone = rhs.phone;
	city = rhs.city;
	volunteers = rhs.volunteers;
}

Client & Client::operator=(const Client & rhs)
{
	name = rhs.name;
	phone = rhs.phone;
	city = rhs.city;
	volunteers = rhs.volunteers;
	return *this;
}

bool Client::operator==(const Client & rhs) const
{
	return phone == rhs.phone;
}

bool Client::IsVolunteer(string volName)
{
	for (list<string>::iterator it = volunteers.begin(); it != volunteers.end(); it++)
	{
		if (*it == volName)
			return true;
	}
	return false;
}

void Client::addVolunteerToList(string name)
{
	volunteers.push_front(name);
	volunteers.sort();
}

void Client::printListOfVolunteers()
{
	for (list<string>::iterator it = volunteers.begin(); it != volunteers.end(); it++)
	{
		cout << *it << ' ';
	}
	cout << endl;
}

istream & operator>>(istream & in, Client & rhs)
{
	in >> rhs.name >> rhs.phone >> rhs.city;
	return in;
}

ostream & operator<<(ostream & out, Client & rhs)
{
	out << " name=" << rhs.name << " phone=" << rhs.phone << " city=" << rhs.city << endl;
	for (list<string>::iterator it = rhs.volunteers.begin(); it != rhs.volunteers.end(); it++)
	{
		out << *it << endl;
	}
	return out;
}


int ClientHash::H1(int key)
{
	return key % size;
}

int ClientHash::H2(int key)
{
	return 1 + key % 4;
}

list<string> ClientHash::getClientList(string name)
{
	list<string> volunteers;
	for (int i = 0; i < size; i++)
	{
		if (table[i].data.IsVolunteer(name))
			volunteers.push_front(table[i].data.getName());
	}
	volunteers.sort();
	return volunteers;
}
