#include "huffman.h"

// build the array of the frequency of the charactors
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

// build the array of the charactors code
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
	for (int i = 0; i < count - 1; i++) //loop on all the queue
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

// fill the code array
void HuffmanTree::fillCodedTable(HuffmanNode * root, string  codedTableLatter, string & strTree, string & strLatter)
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
		fillCodedTable(root->left, codedTableLatter + "0", strTree, strLatter);
	}
	//go right
	if (root->right != NULL)
	{
		fillCodedTable(root->right, codedTableLatter + "1", strTree, strLatter);
	}
}

// sum the number of bitd needed in huffman code
int HuffmanTree::bitHuffmanCode()
{
	int sum = 0;
	for (int i = 0; i < 256; i++)
	{
		sum += frequencyTable[i] * codedTable[i].length();
	}
	return sum;
}

// encode a file
void HuffmanTree::encode(string sourceFileName, string destFileName)
{
	Dtor(root);
	string  codedTableLatter;
	string  strTree;
	string strLatter;
	int sumOfLetter;
	// read from file
	ifstream infile(sourceFileName);
	if (!infile) throw "error opening input"; //check if the file open 
	ofstream outfile(destFileName);
	if (!outfile) throw "error opening output"; //check if the file open 
	string text;
	infile >> text;
	// build the tree and tha arrays
	buildFrequencyTable(text);
	buildcodedTable();
	sumOfLetter = buildTree();
	fillCodedTable(root, codedTableLatter, strTree, strLatter);
	// print the details to the console
	cout << "huffman code:" << endl;
	for (int i = 0; i < 256; i++)
		if (codedTable[i] != "")
			cout << (char)i << ": " << codedTable[i] << endl;
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
	// print to file
	outfile << sumOfLetter << endl;
	outfile << strLatter << endl;
	outfile << strTree << endl;
	outfile << encodeText << endl;
	infile.close();
	outfile.close();
}

// return the code of a charactor
string HuffmanTree::encode(const char letter)
{
	return codedTable[letter];
}

// code a string with according the code array
string HuffmanTree::encode(string text)
{
	string str;
	for (int i = 0; i < text.length(); i++)
	{
		str += encode(text[i]);
	}
	return str;
}

// decode a file
void HuffmanTree::decode(string sourceFileName, string destFileName)
{
	Dtor(root);
	ifstream infile(sourceFileName);
	if (!infile) throw "error opening input"; //check if the file open 
	ofstream outfile(destFileName);
	if (!outfile) throw "error opening output"; //check if the file open 
	string treeText;
	string letterText;
	string strLetter;
	string strTree;
	string code;
	string text;
	string codedTableLatter;
	int sumOfLetters;
	infile >> sumOfLetters;
	infile >> strLetter;
	letterText = strLetter;
	infile >> strTree;
	treeText = strTree;
	infile >> code;
	root = new HuffmanNode();

	// decode the tree wint the information from file 
	decodeTree(root, treeText);
	addLettersToTree(root, letterText, codedTableLatter);
	text = decodeWord(code);

	cout << "huffman code:" << endl;
	for (int i = 0; i < 256; i++)
	{
		if (codedTable[i] != "")
			cout << (char)i << ": " << codedTable[i] << endl;
	}
	cout << "The decoded string is: " << text << endl;
	outfile << text << endl;
	infile.close();
	outfile.close();
}

// build the tree
void HuffmanTree::decodeTree(HuffmanNode * root, string &strTree)
{
	if (strTree == "")
	{
		return;
	}

	// if get 0 build 2 sons
	// then check the next char, if it is 0 - call function again with left sun
	//                           if it is 1 - call function again with right sun
	if (strTree[0] == '0')
	{
		root->left = new HuffmanNode();
		root->right = new HuffmanNode();
		strTree.erase(strTree.begin());
		if (strTree[0] == '0')
		{
			decodeTree(root->left, strTree);
		}
		else if (strTree[0] == '1')
		{
			strTree.erase(strTree.begin());
			decodeTree(root->right, strTree);
		}
		else
		{
			return;
		}
	}
	strTree.erase(strTree.begin());
	return;
}

// go over the tree and add the letters
// and fill the code array of each letter
void HuffmanTree::addLettersToTree(HuffmanNode * root, string & strLetter, string codedTableLatter)
{
	if (root == NULL) return;
	if (root->left == NULL && root->right == NULL)
	{
		root->str = strLetter[0];
		strLetter.erase(strLetter.begin());
		codedTable[root->str[0]] = codedTableLatter;
		return;
	}
	if (root->left != NULL)
	{
		addLettersToTree(root->left, strLetter, codedTableLatter + "0");
	}
	if (root->right != NULL)
	{
		addLettersToTree(root->right, strLetter, codedTableLatter + "1");
	}
}

// get a code and return the letter it represent
string HuffmanTree::decodeLetter(HuffmanNode * root, string & code)
{
	if (root->left == NULL && root->right == NULL)
	{
		return root->str;
	}
	if (code[0] == '0')
	{
		code.erase(code.begin());
		return decodeLetter(root->left, code);
	}
	if (code[0] == '1')
	{
		code.erase(code.begin());
		return decodeLetter(root->right, code);
	}
	else
	{
		throw "the code is invalid";
	}
}

// decode the text in file
string HuffmanTree::decodeWord(string code)
{
	string word;
	try
	{
		// go over the text and decode it.
		while (code != "")
		{
			word += decodeLetter(root, code);
		}
		return word;
	}
	catch (const char * msg)
	{
		return msg;
	}
}

// distractor 
void HuffmanTree::Dtor(HuffmanNode * root)
{
	if (root == NULL) return;
	if (root->left != NULL)
	{
		Dtor(root->left);
	}
	else
	{
		Dtor(root->right);
	}
	delete root;
	root = nullptr;
}



