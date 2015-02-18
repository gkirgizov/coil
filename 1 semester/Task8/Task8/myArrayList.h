#pragma once

typedef int ElementType;

//struct ArrayListElement;

struct ArrayList;

ArrayList* initList();

int getSize(ArrayList *list);

void deleteList(ArrayList *list);

void addElement(ArrayList *list, ElementType addedValue);

void deleteElement(ArrayList *list, unsigned int indexOfElement);

void printList(ArrayList *list);

ElementType getElement(ArrayList *list, unsigned int indexOfElement);