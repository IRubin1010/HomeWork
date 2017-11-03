#include "tree.h"

// search for a Node
Node * Tree::search(Node * p, string val, Node *& parent)
{
	if (p == NULL) return NULL; 
	if (p->value == val) return p; // have found the node 
	if (p->isLeaf == true) return NULL;
	// go over the list
	for (list<Answer*>::iterator it = p->answersList.begin(); it != p->answersList.end(); it++)
	{
		Node * a = search((*it)->son, val, p);
		if (a != NULL) return a;
	}
	return NULL;
}

//search for a node and print the way to this node
bool Tree::searchAndPrint(Node * p, string val)
{
	Node* parent;
	Node* question = search(root, val, parent); // search for the question on the tree
	if (question == NULL) return false;
	cout << question->value; 
	question = question->parent;
	while (question != NULL) // print the way to the root
	{
		cout << " -> " << question->value;
		question = question->parent;
	}
	return true;
}

// print the tree (possible from a node on the middle of the tree)
void Tree::print(Node * p, int level)
{
	level++;
	if (p == NULL) return;
	for (int i = 1; i < level; i++)
	{
		cout << " ";
	}
	cout << p->value << endl;
	if (p->isLeaf == true) return;
	// go over the list and print
	for (list<Answer*>::iterator it = p->answersList.begin(); it != p->answersList.end(); it++)
	{
		for (int i = 1; i < level; i++)
		{
			cout << " ";
		}
		cout << ":" << (*it)->ans << endl;
		print((*it)->son, level);
	}
}

// make the proxess of the decision tree
void Tree::process(Node * p)
{
	if (p->isLeaf) // if a decision print it
	{
		cout << p->value << endl;
		return;
	}
	else
	{
		string ans;
		cout << p->value << endl; // print the question 
		cin >> ans; // get the answer
		// find the answer on the list and continue processing
		for (list<Answer*>::iterator it = p->answersList.begin(); it != p->answersList.end(); it++)
		{
			if ((*it)->ans == ans)
			{
				process((*it)->son);
			}
		}
		return;
	}
}

// delete a sub tree from a node 
void Tree::deleteAllSubTree(Node * t)
{
	if (t == NULL)return;
	if (t == root) // if there is only the root
	{
		delete t;
		root = NULL;
		return;
	}
	if (t->isLeaf == true)return;
	// go over the list and delete
	for (list<Answer*>::iterator it = t->answersList.begin(); it != t->answersList.end(); it++)
	{
		deleteAllSubTree((*it)->son);
		(*it)->son->parent = NULL;
		delete (*it)->son;
		(*it)->son = NULL;
	}
}

// create a new tree
void Tree::addRoot(string newval)
{
	root = new Node(newval, NULL);
}

// add a new decision / question to the tree 
bool Tree::addSon(string fatherquestion, string newanswer, string newval)
{
	Node* parent;
	Node* question = search(root, fatherquestion, parent); // search for the question on the tree
	if (question == NULL) return false; // if there is no such question
	Node* newson = new Node(newval, question);
	Answer* newans = new Answer(newanswer, newson);
	question->answersList.push_back(newans); // add the answer to the tree
	question->isLeaf = false; // if the question was leaf, change to false
	return true;
}

// print the all tree with a string
string Tree::printToString(Node * p, string s)
{
	if (p == NULL) return ""; // make space after decision
	if (p->isLeaf)
	{
		s += p->value;
		return s;
	}
	s += "(" + p->value;
	// go over the list and add to the string
	for (list<Answer*>::iterator it = p->answersList.begin(); it != p->answersList.end(); it++)
	{
		s += "(" + (*it)->ans + " ";
		s = printToString((*it)->son, s);
		s += ")";
	}
	return s;
}

// delete a sub tree withe a givan value
void Tree::deleteSubTree(string val)
{
	Node* subtree = search(root, val, root->parent); // get the node where the value is
	if (subtree == NULL) return;
	if (subtree == root) { deleteAllSubTree(root); return; } // if delete the root
	Answer * remove;
	// search for subtree on his parent list in order to delete subtree from the list 
	for (list<Answer*>::iterator it = subtree->parent->answersList.begin(); it != subtree->parent->answersList.end(); it++)
	{
		if ((*it)->son == subtree)
		{
			remove = *it;
			break;
		}
	}
	subtree->parent->answersList.remove(remove); // remove subtree from parent list
	if(subtree->parent->answersList.empty())subtree->parent->isLeaf = true; // if parent became a decision
	deleteAllSubTree(subtree); 
}
