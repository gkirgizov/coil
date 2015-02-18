#include <iostream>
#include "myLinkedList.h"

using namespace std;

struct LinkedListElement
{
	ElementType value;
	LinkedListElement *next = nullptr;
};

struct LinkedList
{
	LinkedListElement *head = nullptr;
	LinkedListElement *tail = nullptr;
};

LinkedList* initList()
{
	return new LinkedList;
}

int getSize(LinkedList *list)
{
	int size = 0;
	LinkedListElement *cursor = list->head;
	for (size; cursor != nullptr; ++size)
	{
		cursor = cursor->next;
	}
	return size;
}

void deleteList(LinkedList *list)
{
	while (list->head != nullptr)
	{
		LinkedListElement *tempElement = list->head;
		list->head = list->head->next;
		delete tempElement;
	}
	delete list;
}

void addElement(LinkedList *list, ElementType addedValue)
{
	LinkedListElement *addedElement = new LinkedListElement;
	addedElement->value = addedValue;
	if (list->head != nullptr && list->tail != nullptr)
	{
		list->tail->next = addedElement;
		list->tail = addedElement;
	}
	else
	{
		list->head = addedElement;
		list->tail = addedElement;
	}
}

void deleteElement(LinkedList *list, int indexOfElement)
{
	if (indexOfElement < getSize(list))
	{
		LinkedListElement *cursor = list->head;
		if (indexOfElement == 0)
		{
			if (list->tail == list->head)
			{
				list->tail = nullptr;
			}
			list->head = list->head->next;
			delete cursor;
		}
		else
		{
			for (int n = 1; n < indexOfElement; ++n)
			{
				cursor = cursor->next;
			}
			LinkedListElement *tempElement = cursor->next->next;
			delete cursor->next;
			cursor->next = tempElement;
		}
	}
}

void printList(LinkedList *list)
{
	LinkedListElement *cursor = list->head;
	while (cursor != nullptr)
	{
		cout << cursor->value << endl;
		cursor = cursor->next;
	}
}

ElementType getElement(LinkedList *list, int indexOfElement)
{
	if (indexOfElement < getSize(list))
	{
		LinkedListElement *cursor = list->head;
		for (int n = 1; n <= indexOfElement; ++n)
		{
			cursor = cursor->next;
		}
		return cursor->value;
	}
	return 0;
}