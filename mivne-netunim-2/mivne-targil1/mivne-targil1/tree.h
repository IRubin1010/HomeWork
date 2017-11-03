#ifndef __TREE_H
#define __TREE_H

#include <iostream>
#include <list>
#include <string>
using namespace std;

class Node;

//Answer: for each answer, the string, and the pointer to the node where to continue
class Answer
{
public:
	string ans;
	Node* son;
	Answer(string s, Node *p) { ans = s; son = p; }
};

//Node: each node in the decision tree
class Node
{
	void removeSonValue(string v);
public:
	list<Answer *> answersList;
	Node * parent;
	string value;
	bool isLeaf;
	Node(string v, Node* p) { isLeaf = true;  value = v; parent = p; }

	friend class Tree;
};


//Tree: the Decision Tree
class Tree
{
	Node *root;
	Node* search(Node *p, string val, Node *&parent);
	//returns node t where the string equals val. If t has a prent, the pointer parent will contain its address. 

	bool searchAndPrint(Node *p, string val);
	void print(Node *p, int level = 0);
	void process(Node *p);
public:
	Tree() { root = NULL; }
	~Tree() {
		deleteAllSubTree(root);
		root = 0;
	}
	void deleteAllSubTree(Node *t);
	void addRoot(string newval);
	bool addSon(string fatherquestion, string newanswer, string newval);
	void searchAndPrint(string val)
	{
		if (!searchAndPrint(root, val))
			cout << "Value not found" << endl;
	}
	void searchAndPrintArea(string val)
	{
		Node *parent;
		Node *area = search(root, val, parent);
		if (area) print(root);
	}
	void printAllTree() { print(root); }
	string printToString(Node *p, string s);
	string printToString() { string s; return printToString(root,s); }
	void deleteSubTree(string val);
	void process() { process(root); }


};

#endif//__TREE_H
