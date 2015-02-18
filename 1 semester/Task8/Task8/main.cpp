#include <iostream>
#include <fstream>
#include <string>
#include <vector>
//#include "tmplsts.h"
//#include "myArrayList.h"
//#include "myLinkedList.h"
//#include "sortMerge.h"
#include "myTree.h"
#include "arithmeticTree.h"

using namespace std;

int task3(string filePath)
{
	setlocale(LC_ALL, "Russian");
	Tree *arithmeticPlant = arithmeticTree(filePath);
	cout << "Дерево разбора арифметического выражения:" << endl;
	string out = printTree(arithmeticPlant, 2);
	cout << out << endl;
	int result = calcTree(arithmeticPlant);
	deleteTree(arithmeticPlant);
	return result;
}

void main()
{
//Тест универсальной сортировки слиянием.
	//ListType *list = initList();
	//addElement(list, 0);
	//addElement(list, 5);
	//addElement(list, 3);
	//addElement(list, 4);
	//addElement(list, 2);
	//addElement(list, 1);
	//
	//cout << "pr: " << endl;
	//printList(list);
	//cout << endl;
	//
	//ListType *tmpptr = list;
	//list = sortMerge(list);
	//deleteList(tmpptr);
	//
	//cout << "sorted:" << endl;
	//printList(list);

//Проверка дерева.
	Tree *tree = initTree();
	addElement(tree, 50);
	addElement(tree, 70);
	addElement(tree, 20);
	addElement(tree, 80);
	addElement(tree, 60);
	addElement(tree, 10);
	addElement(tree, 30);
	addElement(tree, 90);
	addElement(tree, 15);
	addElement(tree, 25);
	addElement(tree, 0);
	//
	cout << "pr:" << endl;
	printTree(tree, 3);
	//
	deleteElement(tree, 20);
	cout << endl << "dltd:" << endl;
	printTree(tree, 3);

//Substring checking.
	//string filePath = "task3.txt";
	//string entireString;
	//ifstream inputFile(filePath, ios::in);
	//getline(inputFile, entireString);
	//string substring = generateSubstring(entireString);
	//substring = generateSubstring(substring);
	//cout << "ss:" << endl << substring << endl;
	
	//cout << task3("task3.txt") << endl;
}