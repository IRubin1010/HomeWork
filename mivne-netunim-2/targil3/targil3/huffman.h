#ifndef __HUFFMAN_H
#define __HUFFMAN_H
#include<iostream>
#include<string>
#include<vector>
#include<queue>
#include<fstream>
using namespace std;

class compareNode; //declar on class compreNode

//Represents a node in the Hoffmann tree
class HuffmanNode
{
private:
	string str; //
	int frequency; //frequency of this node or the sum of all subtree
	HuffmanNode* left; //point to left son
	HuffmanNode* right; //point to right son
public:
	friend compareNode;
};
class compareNode
{
public:
	bool operator()(HuffmanNode* const & n1, HuffmanNode* const & n2)
	{
		return n1->frequency > n2->frequency;
	}
};

class HuffmanTree
{
private:
	HuffmanNode* root;
	int frequencyTable[256];
	string codedTable[256];
public:
	HuffmanTree() {};
	void buildFrequencyTable(string text);
};
#endif // !__HUFFMAN_H
