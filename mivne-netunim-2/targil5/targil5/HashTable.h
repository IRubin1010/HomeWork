#ifndef __HASHTABEL_H
#define __HASHTABEL_H
#include <iostream>
using namespace std;

enum state { empty, full, deleted };
template <typename T, typename K>
class Item
{
public:
	T data;
	K key;
	state flag;
	Item() {}
	Item(T d, K k, state f) { data = d; key = k; flag = f; }
};

template <typename T, typename K>
class HashTabel
{
private:
	Item<T, K> * tabel[];
public:
	HashTabel(int num);
	~HashTabel() = 0;
	int H1(K key) = 0;
	int H2(K key) = 0;
	int Hash(K key, int i);

};

template <typename T, typename K>
HashTabel<typename T, typename K>::HashTabel(int num)
{
	int i = num;
	bool isPrime = true;
	for (i; ; i++)
	{
		for (int j = 2; j < i / 2; j++)
		{
			if (i % j == 0)
			{
				isPrime = false;
				break;
			}
		}
		if (isPrime)
			break;
		isPrme = true;
	}
	tabel = new Item<T, K>[i];
};





#endif // !__HASHTABEL_H

