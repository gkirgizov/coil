#pragma once

typedef LinkedList List;

struct HashTable;

HashTable* initHashTable(unsigned int capacity = 128);

unsigned int hashCalc(ElementType hashedData, int mod = 128);

void addElement(HashTable *htable, ElementType data);

void deleteElement(HashTable *htable, ElementType deletedData);

void printHashTable(HashTable *htable);

void deleteHashTable(HashTable *htable);