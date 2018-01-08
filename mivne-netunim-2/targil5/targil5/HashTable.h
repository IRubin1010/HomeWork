#ifndef __HASHTable_H
#define __HASHTable_H
#include <iostream>
using namespace std;

enum state { Empty, full, deleted };
template <typename T, typename K>
class Item
{
public:
	T data;
	K key;
	state flag;
	Item() { flag = Empty; }
	Item(T d, K k, state f) { data = d; key = k; flag = f; }
};

template <typename T, typename K>
class HashTable
{
protected:
	Item<T, K> * table;
	int size;
public:
	HashTable(int num);
	virtual ~HashTable();
	virtual int H1(K key) = 0;
	virtual int H2(K key) = 0;
	int hash(K key, int i);
	int search(K key);
	void add(T data, K key);
	void remove(K key);
	void print();
	T& getData(K key);
};

template <typename T, typename K>
HashTable<T, K>::HashTable(int num)
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
		isPrime = true;
	}
	table = new Item<T, K>[i];
	size = i;
}
template<typename T, typename K>
HashTable<T, K>::~HashTable()
{
	delete[] table;
	table = NULL;
}

template<typename T, typename K>
int HashTable<T, K>::hash(K key, int i)
{
	return (H1(key) + H2(key)*i) % size;
}
template<typename T, typename K>
int HashTable<T, K>::search(K key)
{
	int i = 0;
	int j;
	do
	{
		j = hash(key, i);
		if (table[j].key == key)
			return j;
		i++;
	} while (table[j].flag != Empty && i != size);
	return -1;
}

template<typename T, typename K>
void HashTable<T, K>::add(T data, K key)
{
	Item<T, K> item(data, key, full);
	int i = 0;
	int j;
	do
	{
		j = hash(key, i);
		if (table[j].flag != full)
		{
			table[j] = item;
			return;
		}
		i++;
	} while (i != size);
	throw "No place!";
}

template<typename T, typename K>
void HashTable<T, K>::remove(K key)
{
	int i = search(key);
	if (i != -1)
	{
		Item<T, K> item(T(), K(), deleted);
		table[i] = item;
	}
	else
	{
		throw "Not found";
	}
}

template<typename T, typename K>
inline void HashTable<T, K>::print()
{
	for (int i = 0; i < size; i++)
	{
		if (table[i].flag == full)
		{
			cout << "tabel[" << i << "]" << endl;
			cout << "\tkey " << table[i].key << " = " << table[i].data << endl;
		}
	}
}

template<typename T, typename K>
T & HashTable<T, K>::getData(K key)
{
	int i = search(key);
	if (i != -1)
		return table[i].data;
	throw "Not found!";
}





#endif // !__HASHTable_H

