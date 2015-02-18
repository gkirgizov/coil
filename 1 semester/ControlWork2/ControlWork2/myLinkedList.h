#pragma once

typedef int ElementType;

struct LinkedListElement;

struct LinkedList;

LinkedList* initList();

int getSize(LinkedList *list);

void deleteList(LinkedList *list);

void addElement(LinkedList *list, ElementType addedValue);

void deleteElement(LinkedList *list, int indexOfElement);

void printList(LinkedList *list);

ElementType getElement(LinkedList *list, int indexOfElement);