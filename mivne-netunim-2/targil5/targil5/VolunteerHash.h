#ifndef __VOLUNTEERHASH_H
#define __VOLUNTEERHASH_H
#include "HashTable.h"
#include <string>
//#include "Volunteer.h"
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
	int getDistance() { return _distance; }
	string getName() { return _name; }
	Volunteer & operator = (const Volunteer & volunteer);
	bool operator == (const Volunteer & rhs)const;
	bool operator != (const Volunteer & rhs)const;
	bool operator > (const Volunteer & rhs)const;
	bool operator >= (const Volunteer & rhs)const;
	bool operator < (const Volunteer & rhs)const;
	bool operator <= (const Volunteer & rhs)const;
	friend istream & operator >> (istream & in, Volunteer & rhs); // overide input operator
	friend ostream & operator << (ostream & out, Volunteer & rhs); // overide output operator
};



class VolunteerHash : public HashTable<Volunteer, string>
{
public:
	VolunteerHash(int num) : HashTable<Volunteer, string>(num) {}
	int H1(string key);
	int H2(string key);
};



#endif // !__VOLUNTEERHASH_H
