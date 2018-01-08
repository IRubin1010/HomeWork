//#include <iostream>
//#include <string>
//using namespace std;
//#include "TestHash.h"
//#include <time.h>
//
//
//int main()
//{
//	try
//	{
//		srand(time(NULL));
//		int val;
//		TestHash table(6);
//		for (int i = 0; i<7; i++)
//		{
//			val = rand() % 100;
//			table.add(val, val);
//			cout << val << ' ';
//		}
//		cout << endl;
//		table.print();
//
//		for (int i = 0; i<3; i++)
//		{
//			cout << "enter to remove" << endl;
//			cin >> val;
//			table.remove(val);
//		}
//		cout << endl;
//		table.print();
//		cout << "enter to add " << endl;
//		cin >> val;
//		table.add(val, val);
//		cout << "enter to search " << endl;
//		cin >> val;
//		cout << "find at " << table.search(val) << endl;;
//
//
//
//		for (int i = 0; i<10; i++)
//		{
//			
//			val = rand() % 50;
//			int pos = table.search(val);
//			if (pos>-1)
//				cout << val << " was found at place: " << pos << endl;
//			else
//				cout << val << " was not found\n";
//		}
//	}
//	catch (const char * er)
//	{
//		cout << er << endl;
//	}
//	
//	
//	return 0;
//}


#include <iostream>
#include <string>
#include "VolunteerHash.h"
#include "ClientHash.h"
using namespace std;

int main()
{
	VolunteerHash vh(6);
	ClientHash ch(6);
	Volunteer v;
	Client c;
	int choice;
	string name;
	int phone;

	cout << "Hash Tables\n";
	cout << "\nChoose one of the following" << endl;
	cout << "1: New volunteer" << endl;
	cout << "2: Del a volunteer " << endl;
	cout << "3: New client" << endl;
	cout << "4: Del a client " << endl;
	cout << "5: Add a connection volunteer-client " << endl;
	cout << "6: Print volunteers that helped a client " << endl;
	cout << "7: Print clients that were helped by a voluneer " << endl;
	cout << "0: for exit " << endl;
	cin >> choice;
	while (choice)
	{
		try {
			switch (choice)
			{
			case 1: cout << "Enter volunteers id, name, address, phone number and city" << endl;
				cin >> v;
				vh.add(v,v.getName());
				vh.print();
				break;
			case 2: cout << "Enter the name of volunteer to remove" << endl;
				cin >> name;
				vh.remove(name);
				vh.print();
				break;
			case 3: cout << "Enter clients name, phone number and city" << endl;
				cin >> c;
				ch.add(c,c.getPhone());
				break;
			case 4: cout << "Enter the phone number of client to remove" << endl;
				cin >> phone;
				ch.remove(phone);
				break;
			case 5: {
				cout << "enter volunteers name and clients phone number" << endl;
				cin >> name >> phone;
				Client & c = ch.getData(phone);
				c.addVolunteerToList(name);
				cout << c;
			}
					break;
			case 6: {
				cout << "enter clients phone number" << endl;
				cin >> phone;
				Client& c = ch.getData(phone);
				cout << "list of volunteers that helped " << c.getName() << endl;
				c.printListOfVolunteers();
			}
					break;
			case 7: {
				ch.print();
				cout << "enter volunteers name " << endl;
				cin >> name;
				list<string>lst = ch.getClientList(name);
				list<string>::iterator it = lst.begin();
				cout << "list of clients that " << name << " helped:" << endl;
				for (; it != lst.end(); it++)
					cout << *it << ' ';
				cout << endl;
			}
					break;

			default: cout << "error ";  break;
			}
		}
		catch (const char* msg)
		{
			cout << msg << endl;
		}
		cout << "enter a choice" << endl;
		cin >> choice;
	}
}