#pragma once

typedef int elementType;

struct ListElement;

struct List;

//����� ��������� ������������ � ������������ �������.
List* initList();

int getSize(List *list);

//��������� ��������� ������������ �������������� ������.
void addElement(List *list, elementType addedValue);

void deleteElement(List *list, elementType deletedValue);

void deleteList(List *list);

void printList(List *list);

//��������� ������������ ������������ ������.
void push(List *list, elementType addedValue);

int getElement(List *list, int indexOfElement);

void deleteElementByIndex(List *list, int indexOfDeletedElement);

void deleteCycleList(List *list);