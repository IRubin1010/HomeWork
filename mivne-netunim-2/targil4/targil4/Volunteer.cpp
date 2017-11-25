//#include <iostream>
#include "Volunteer.h"
//using namespace std;

// copy constractor
Volunteer::Volunteer(Volunteer & volunteer)
{
	_ID = volunteer._ID;
	_name = volunteer._name;
	_address = volunteer._address;
	_phone = volunteer._phone;
	_city = volunteer._city;
	_distance = volunteer._distance;
}

bool Volunteer::operator==(const Volunteer & rhs) const
{
	return _distance == rhs._distance;
}

bool Volunteer::operator!=(const Volunteer & rhs) const
{
	return _distance != rhs._distance;
}

bool Volunteer::operator>(const Volunteer & rhs) const
{
	return _distance > rhs._distance;
}

bool Volunteer::operator>=(const Volunteer & rhs) const
{
	return _distance >= rhs._distance;
}

bool Volunteer::operator<(const Volunteer & rhs) const
{
	return _distance < rhs._distance;
}

bool Volunteer::operator<=(const Volunteer & rhs) const
{
	return _distance <= rhs._distance;
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
	out << "id=" << rhs._ID << " name=" << rhs._name << " address=" << rhs._address << " phone=" << rhs._phone << " city=" << rhs._city << endl << " distance=" << rhs._distance;
	return out;
}
