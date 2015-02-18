#include "myLinkedList.h"
#include "myHashTable.h"
#include <iostream>
#include <fstream>
#include <string>

using namespace std;

string upperCase(string inputString)
{
	string outputString = inputString;
	for (unsigned int n = 0; n < outputString.size(); ++n)
	{
		outputString[n] = toupper(outputString[n]);
	}
	return outputString;
}

void task(string filepath)
{
	ifstream inputFile(filepath, ios::in);
	if (inputFile.is_open())
	{
		HashTable *stringTable = initHashTable();
		while (!inputFile.eof())
		{
			string buffer;
			inputFile >> buffer;
			addElement(stringTable, upperCase(buffer));
		}
		printHashTable(stringTable);
		deleteHashTable(stringTable);
	}
}

void main()
{
//LinkedList* list = initList();
	//addElement(list, "1");
	//addElement(list, "9");
	//addElement(list, "4");
	//addElement(list, "2");
	//
	//printList(list);
	//cout << endl;
	//searchElement(list, "4");
	task("text.txt");
}