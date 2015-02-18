#pragma once

typedef int ElementType;

struct ListElement;

struct List;

List* initList();

int getSize(List *list);

void addElement(List *list, ElementType addedValue);

void deleteElement(List *list, ElementType deletedValue);

void printList(List *list);

void printWithoutRepeat(List *list);

void deleteList(List *list);