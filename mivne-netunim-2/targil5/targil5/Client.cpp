#include "Client.h"

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
	for (auto it = volunteers.begin(); it != volunteers.end(); it++)
	{
		if (*it == volName)
			return true;
	}
	return false;
}

void Client::addVolunteerToList(string name)
{
	volunteers.push_front(name);
}

void Client::printListOfVolunteers()
{
	for (auto it = volunteers.begin(); it != volunteers.end(); it++)
	{
		cout << *it << endl;
	}
}

istream & operator>>(istream & in, Client & rhs)
{
	in >> rhs.name >> rhs.phone >> rhs.city;
	return in;
}

ostream & operator<<(ostream & out, Client & rhs)
{
	out << " name=" << rhs.name << " phone=" << rhs.phone << " city=" << rhs.city << endl;
	for (auto it = rhs.volunteers.begin(); it != rhs.volunteers.end(); it++)
	{
		out << *it << endl;
	}
	return out;
}
