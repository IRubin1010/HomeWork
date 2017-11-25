#ifndef __VOLUNTEER_H
#define __VOLUNTEER_H
#include <iostream>
#include <string>
using namespace std;

class Volunteer
{
private:
	int _ID;
	string _name;
	string _address;
	int _phone;
	string _city;
	int _distance;
public:
	Volunteer() {}; // constractor
	Volunteer(const Volunteer & volunteer); // copy constractor
	int ID() { return _ID; } // geter
	void setDistance(int distance) { _distance = distance; }
	int getDistance() {return _distance; }
	string getName() { return _name; }
	bool operator == (const Volunteer & rhs)const;
	bool operator != (const Volunteer & rhs)const;
	bool operator > (const Volunteer & rhs)const;
	bool operator >= (const Volunteer & rhs)const;
	bool operator < (const Volunteer & rhs)const;
	bool operator <= (const Volunteer & rhs)const;
	friend istream & operator >> (istream & in, Volunteer & rhs); // overide input operator
	friend ostream & operator << (ostream & out, Volunteer & rhs); // overide output operator
};


#endif