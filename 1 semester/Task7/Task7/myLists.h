#pragma once

typedef int elementType;

struct ListElement;

struct List;

//Общий интерфейс односвязного и циклического списков.
List* initList();

int getSize(List *list);

//Интерфейс линейного односвязного сортированного списка.
void addElement(List *list, elementType addedValue);

void deleteElement(List *list, elementType deletedValue);

void deleteList(List *list);

void printList(List *list);

//Интерфейс циклического односвязного списка.
void push(List *list, elementType addedValue);

int getElement(List *list, int indexOfElement);

void deleteElementByIndex(List *list, int indexOfDeletedElement);

void deleteCycleList(List *list);