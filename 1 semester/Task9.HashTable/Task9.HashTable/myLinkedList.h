#pragma once
#include <string>

typedef std::string ElementType;

struct LinkedListElement;

struct LinkedList;

LinkedList* initList();

int getSize(LinkedList *list);

void deleteList(LinkedList *list);

// ���������� �������� � ������; count - ���������� ���������.
void addElement(LinkedList *list, ElementType addedValue, unsigned int count = 1);

// ������� ������� �� �������.
void deleteElement(LinkedList *list, int indexOfElement);

// ������� ������ ��������� ��������� � ������.
void deleteElement(LinkedList *list, ElementType deletedValue);

void printList(LinkedList *list);

ElementType getElement(LinkedList *list, int indexOfElement);

bool searchElement(LinkedList *list, ElementType searched);