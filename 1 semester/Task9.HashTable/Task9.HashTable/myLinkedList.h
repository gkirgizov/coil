#pragma once
#include <string>

typedef std::string ElementType;

struct LinkedListElement;

struct LinkedList;

LinkedList* initList();

int getSize(LinkedList *list);

void deleteList(LinkedList *list);

// Добавление элемента в список; count - количество элементов.
void addElement(LinkedList *list, ElementType addedValue, unsigned int count = 1);

// Удаляет элемент по индексу.
void deleteElement(LinkedList *list, int indexOfElement);

// Удаляет первое вхождение эелемента в список.
void deleteElement(LinkedList *list, ElementType deletedValue);

void printList(LinkedList *list);

ElementType getElement(LinkedList *list, int indexOfElement);

bool searchElement(LinkedList *list, ElementType searched);