#include "myLinkedList.h"
#include "myHashTable.h"
#include <iostream>
#include <string>
#include <vector>

using namespace std;

struct HashTable
{
	vector<List*> table;
};

HashTable* initHashTable(unsigned int capacity)
{
	HashTable *htable = new HashTable;
	for (capacity; capacity > 0; --capacity)
	{
		htable->table.push_back(initList());
	}
	return htable;
}

unsigned int hashCalc(ElementType hashedData, unsigned int mod)
{
	unsigned int hash = 0;
	for (const char &symbol : hashedData)
	{
		hash += symbol;
	}
	return hash * hash % mod;
}

void addElement(HashTable *htable, ElementType data)
{
	unsigned int htableCapacity = htable->table.size();
	unsigned int hash = hashCalc(data, htableCapacity);
	addElement(htable->table[hash], data);
}

void deleteElement(HashTable *htable, ElementType deletedData)
{
	unsigned int htableCapacity = htable->table.size();
	unsigned int hash = hashCalc(deletedData, htableCapacity);
	deleteElement(htable->table[hash], deletedData);
}

void printHashTable(HashTable *htable)
{
	for (List* htableElement : htable->table)
	{
		printList(htableElement);
	}
}

void deleteHashTable(HashTable *htable)
{
	for (List* element : htable->table)
	{
		deleteList(element);
	}
	delete htable;
}