#ifndef __HUFFMAN_H
#define __HUFFMAN_H
#include<iostream>
#include<string>
#include<vector>
#include<queue>
#include<fstream>
using namespace std;

class compareNode; //declar on class compreNode
class HuffmanTree;

//Represents a node in the Hoffmann tree
class HuffmanNode
{
private:
	string str; //
	string _tav;
	int frequency; //frequency of this node or the sum of all subtree
	HuffmanNode* left; //point to left son
	HuffmanNode* right; //point to right son
public:
	HuffmanNode() {};
	HuffmanNode(int freq, string tav = "") :str(""), left(NULL), right(NULL) { frequency = freq; _tav = tav; }
	friend compareNode;
	friend HuffmanTree;
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
	priority_queue<HuffmanNode*, vector<HuffmanNode*>, compareNode> pQueue;
public:
	HuffmanTree(){};
	void buildFrequencyTable(string text);
	HuffmanNode* buildTree(int * frequencyTable);
	void fullPriartyQueue(int * frequencyTable);
	void func(HuffmanNode* root, string * codedTable, string& strTree, string& strChar);
};
#endif // !__HUFFMAN_H
