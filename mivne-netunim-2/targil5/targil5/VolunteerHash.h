#ifndef __VOLUNTEERHASH_H
#define __VOLUNTEERHASH_H
#include "HashTable.h"
#include "Volunteer.h"
using namespace std;

class VolunteerHash : public HashTable<Volunteer, string>
{
public:
	VolunteerHash(int num) : HashTable<Volunteer, string>(num) {}
	int H1(string key);
	int H2(string key);
};



#endif // !__VOLUNTEERHASH_H
