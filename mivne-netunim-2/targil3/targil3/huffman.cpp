#include "huffman.h"

void HuffmanTree::buildFrequencyTable(string text)
{
	//Places zero in all array cells
	for (int i = 0; i < 256; i++)
	{
		frequencyTable[i] = 0;
	}
	//Updating the frequencies of all array cells
	for (int i = 0; i < text.length(); i++)
	{
		frequencyTable[text[i]]++;
	}
}

void HuffmanTree::buildcodedTable()
{
	//Updating all array cells with empty strings
	for (int i = 0; i < 256; i++)
	{
		codedTable[i] = "";
	}
}
//build the huffman tree
//return the count of the diffrent latter
int HuffmanTree::buildTree()
{
	int count = fullPriorityQueue(); //Calls the function that filled the frequencyTable and counting the diffrent latter
	for (int i = 0; i < count-1; i++) //loop on all the queue
	{
		HuffmanNode* newNode = new HuffmanNode(); //creat a new node
		newNode->left = pQueue.top(); //The left son points to the smallest organ in the priority queue
		pQueue.pop(); //Remove the organ from the queue
		newNode->right = pQueue.top();//The right son points to the next smallest part in the priority queue
		pQueue.pop();//Remove the organ from the queue 
		newNode->frequency = newNode->left->frequency + newNode->right->frequency;//Updates the frequency of the new node to be equal to the frequency of its two son
		pQueue.push(newNode);//push the node to the priority queue
	}
	root = pQueue.top();
	pQueue.pop();
	return count; //return thr root of huffmanTree
}
//Fills the priority queue from the frequencyTable of non-empty cells
//and updates the tav field that represents the signal at each node
int HuffmanTree::fullPriorityQueue()
{
	int count = 0;
	for (int i = 0; i < 256; i++) //loop on all frequencyTable
		if (frequencyTable[i] != 0) //check if the cells isnot empty
		{
			HuffmanNode* node = new HuffmanNode(frequencyTable[i], char(i)); //creat a new node and updates the freqency and the str
			pQueue.push(node); //push the node to the priority queue
			count++;
		}
	return count;
}

void HuffmanTree::func(HuffmanNode * root, string  codedTableLatter, string & strTree, string & strLatter)
{
	if (root == NULL)return;
	//is leaf
	if (root->left == NULL && root->right == NULL)
	{
		codedTable[root->str[0]] = codedTableLatter;
		strLatter += root->str;
		strTree += "1";
	}
	//go left
	if (root->left != NULL)
	{
		strTree += "0";
		func(root->left, codedTableLatter + "0", strTree, strLatter);
	}
	//go right
	if (root->right != NULL)
	{
		func(root->right, codedTableLatter+"1", strTree, strLatter);
	}
}

int HuffmanTree::bitHuffmanCode()
{
	int sum = 0;
	for (int i = 0; i < 256; i++)
	{
		sum += frequencyTable[i] * codedTable[i].length();
	}
	return sum;
}

void HuffmanTree::encode(string sourceFileName, string destFileName)
{
	string  codedTableLatter;
	string  strTree;
	string strLatter ;
	int sumOfLetter;
	ifstream infile(sourceFileName);
	if (!infile) throw "error opening input"; //check if the file open 
	ofstream outfile(destFileName);
	if (!outfile) throw "error opening output"; //check if the file open 
	string text;
	infile >> text;

	buildFrequencyTable(text);
	buildcodedTable();
	sumOfLetter = buildTree();
	func(root, codedTableLatter, strTree, strLatter);

	cout << "huffman code:" << endl;
	for (int i = 0; i < 256; i++)
		if (codedTable[i] != "")
			cout << i << ": " << codedTable[i] << endl;
	int totalFrequncy = root->frequency;
	int fixCode = ceil(log2(sumOfLetter));
	int bitFixCode = totalFrequncy*fixCode;
	int bitHuffmanCod = bitHuffmanCode();
	string encodeText = encode(text);
	cout << "In the fixed - length code, the number of bits needed per character: " << fixCode << endl;
	cout << "Encoding in fixed-length code requires " << bitFixCode << "bits" << endl;
	cout << "Encoding in huffman code requires " << bitHuffmanCod << "bits" << endl;
	cout << "The encoded string is:" << endl;
	cout << sumOfLetter << endl << strLatter << endl << strTree << endl;
	cout << encodeText << endl;

	outfile << sumOfLetter<<endl;
	outfile << strLatter<<endl;
	outfile << strTree<<endl;
	outfile << encodeText<<endl;
}

string HuffmanTree::encode(const char letter)
{
	return codedTable[letter];
}

string HuffmanTree::encode(string text)
{
	string str;
	for (int i = 0; i < text.length(); i++)
	{
		str += encode(text[i]);
	}
	return str;
}
