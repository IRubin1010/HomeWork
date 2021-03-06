#include "VolunteerHash.h"
#include <string>


// copy constractor
Volunteer::Volunteer(const Volunteer & volunteer)
{
	_ID = volunteer._ID;
	_name = volunteer._name;
	_address = volunteer._address;
	_phone = volunteer._phone;
	_city = volunteer._city;
	_distance = volunteer._distance;
}

/* copy assignment*/
Volunteer &  Volunteer::operator = (const Volunteer & volunteer)
{
	_ID = volunteer._ID;
	_name = volunteer._name;
	_address = volunteer._address;
	_phone = volunteer._phone;
	_city = volunteer._city;
	_distance = volunteer._distance;
	return *this;
}

/*operators*/

bool Volunteer::operator==(const Volunteer & rhs) const
{
	return _name == rhs._name;
}

bool Volunteer::operator!=(const Volunteer & rhs) const
{
	return _name != rhs._name;
}

bool Volunteer::operator>(const Volunteer & rhs) const
{
	return _name > rhs._name;
}

bool Volunteer::operator>=(const Volunteer & rhs) const
{
	return _name >= rhs._name;
}

bool Volunteer::operator<(const Volunteer & rhs) const
{
	return _name < rhs._name;
}

bool Volunteer::operator<=(const Volunteer & rhs) const
{
	return _name <= rhs._name;
}

// input operator
istream & operator>>(istream & in, Volunteer & rhs)
{
	in >> rhs._ID >> rhs._name >> rhs._address >> rhs._phone >> rhs._city;
	rhs._distance = 0;
	return in;
}

// utput operator
ostream & operator<<(ostream & out, Volunteer & rhs)
{
	out << "id=" << rhs._ID << " name=" << rhs._name << " address=" << rhs._address << " phone=" << rhs._phone << " city=" << rhs._city << " distance=" << rhs._distance << endl;
	return out;
}



int VolunteerHash::H1(string key)
{
	int hash = 0;
	for (int i = 0; i < key.length(); i++)
	{
		hash += static_cast<int>(key[i]);
	}
	return hash % size;
}

int VolunteerHash::H2(string key)
{
	int hash = 0;
	for (int i = 0; i < key.length(); i++)
	{
		hash += static_cast<int>(key[i]);
	}
	return 1 + hash % 4;
}

