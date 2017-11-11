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
