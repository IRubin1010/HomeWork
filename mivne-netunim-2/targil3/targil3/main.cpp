#include"huffman.h"
using namespace std;
int main()
{
	int chioce;
	string sourceFile, destFile;
	HuffmanTree tree;
	do
	{

	cout << "enter your choise:" << endl;
	cout << "1 - encode file" << endl;
	cout << "2 - dcode file" << endl;
	cout << "3 - exit" << endl;
	cin >> chioce;
	try 
	{
		switch (chioce)
		{
		case 1:cout << "enter the name sourch file and the name of destination file" << endl;
			cin >> sourceFile >> destFile;
			tree.encode(sourceFile, destFile);
			break;
		case 2:cout << "enter the name sourch file and the name of destination file" << endl;
			cin >> sourceFile >> destFile;
			tree.encode(sourceFile, destFile);
			break;
		case 3: cout << "Goodbye" << endl;
			break;
		default:cout << "ERROR" << endl;
			break;
		}
	}
	catch (const string exception)
	{
		cout << exception << endl;
	}
	} while (chioce!=3);



	return 0;
}