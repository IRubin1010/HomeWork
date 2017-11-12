#include "huffman.h"

void HuffmanTree::buildFrequencyTable(string text)
{
	ifstream infile(text); //open the file to read
	if (!infile) throw "error opening input"; //check if the file open 
	char tav;
	while (infile.get(tav)) //loop on akk the file
	{
		frequencyTable[tav]++;
	}
	infile.close(); // close the file
}

HuffmanNode * HuffmanTree::buildTree(int * frequencyTable)
{
	fullPriartyQueue(frequencyTable);
	for (int i = 0; i < pQueue.size; i++)
	{
		HuffmanNode* newNode = new HuffmanNode();
		newNode->left = pQueue.top();
		pQueue.pop();
		newNode->right = pQueue.top();
		pQueue.pop();
		newNode->frequency = newNode->left->frequency + newNode->right->frequency;
		pQueue.push(newNode);
	}
	return pQueue.top();
}

void HuffmanTree::fullPriartyQueue(int * frequencyTable)
{
	for (int i = 0; i < 256; i++)
	{
		if (frequencyTable[i] != 0)
		{
			HuffmanNode* node = new HuffmanNode(frequencyTable[i]);
			node->_tav = i;
			pQueue.push(node);
		}
	}
}

void HuffmanTree::func(HuffmanNode * root, string * codedTable, string & strTree, string & strChar)
{
	if (root->left==NULL&&root->right==NULL)
	{
		strTree += "1";
		strChar += root->_tav;
	}
}
