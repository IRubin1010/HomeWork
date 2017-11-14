#ifndef __HUFFMAN_H
#define __HUFFMAN_H
#include<iostream>
#include<string>
#include<vector>
#include<queue>
#include<fstream>
#include <cmath>
using namespace std;

class compareNode; //declar on class compreNode
class HuffmanTree;

//Represents a node in the Hoffmann tree
class HuffmanNode
{
private:
	string str; //
	int frequency; //frequency of this node or the sum of all subtree
	HuffmanNode* left; //point to left son
	HuffmanNode* right; //point to right son
public:
	HuffmanNode() {};
	HuffmanNode(int freq, char tav) : left(NULL), right(NULL) { frequency = freq; str = tav; }
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
	void buildFrequencyTable(string text);
	void buildcodedTable();

	int buildTree();
	int fullPriorityQueue();
	void func(HuffmanNode * root, string  codedTableLatter, string & strTree, string & strLatter);

	int bitHuffmanCode();
	string encode(const char letter);
	string encode(string text);
public:

	void encode(string sourceFileName, string destFileName);
};
#endif // !__HUFFMAN_H
