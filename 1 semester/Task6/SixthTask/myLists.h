#pragma once

typedef int ElementType;

struct ListElement;

struct List;

// Общий интерфейс односвязного и циклического списков.
List* initList();

// Get size of the list.
int getSize(List *list);


// Интерфейс линейного односвязного сортированного списка.

// Add element to the list.
void addElement(List *list, ElementType addedValue);

// Delete element by value.
void deleteElement(List *list, ElementType deletedValue);

// Free memory
void deleteList(List *list);

// Print list.
void printList(List *list);


// Интерфейс циклического односвязного списка.

// Add element to the cyclic list.
void push(List *list, ElementType addedValue);

// Get value of the element. 
int getElement(List *list, int indexOfElement);

// Delete element by index.
void deleteElementByIndex(List *list, int indexOfDeletedElement);

// Free memory.
void deleteCycleList(List *list);