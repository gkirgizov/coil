#include <iostream>
#include "myLinkedList.h"

using namespace std;

struct LinkedListElement
{
	ElementType value;
	unsigned int count = 0;
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
	LinkedListElement *ptr = list->head;
	for (size; ptr != nullptr; ++size)
	{
		ptr = ptr->next;
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

void addElement(LinkedList *list, ElementType addedValue, unsigned int count)
{
	LinkedListElement *addedElement = new LinkedListElement;
	addedElement->value = addedValue;
	addedElement->count = count;
	if (list->head != nullptr && list->tail != nullptr)
	{
		LinkedListElement *ptr = list->head;
		while (ptr)
		{
			if (ptr->value.compare(addedValue) == 0)
			{
				ptr->count = ptr->count + count;
				return;
			}
			ptr = ptr->next;
		}
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
		LinkedListElement *ptr = list->head;
		if (indexOfElement == 0)
		{
			if (list->tail == list->head)
			{
				list->tail = nullptr;
			}
			list->head = list->head->next;
			delete ptr;
		}
		else
		{
			for (int n = 1; n < indexOfElement; ++n)
			{
				ptr = ptr->next;
			}
			LinkedListElement *tempElement = ptr->next->next;
			delete ptr->next;
			ptr->next = tempElement;
		}
	}
}

void deleteElement(LinkedList *list, ElementType deletedValue)
{
	LinkedListElement *ptr = list->head;
	if (ptr != nullptr)
	{
		if (list->head->value.compare(deletedValue) == 0)
		{
			LinkedListElement *tempElement = list->head;
			if (list->tail == list->head)
			{
				list->tail = nullptr;
			}
			list->head = list->head->next;
			delete tempElement;
		}
		else
		{
			while ((ptr->next != nullptr) && (ptr->next->value.compare(deletedValue) != 0))
			{
				ptr = ptr->next;
			}
			if ((ptr->next != nullptr) && (ptr->next->value.compare(deletedValue) == 0))
			{
				if (ptr->next = list->tail)
				{
					list->tail = ptr;
					delete ptr->next;
					if (list->head = list->tail)
					{
						list->head->next = nullptr;
					}
				}
				else
				{
					LinkedListElement *tempElement = ptr->next;
					ptr->next = ptr->next->next;
					delete tempElement;
				}
			}
		}
	}
}

void printList(LinkedList *list)
{
	LinkedListElement *ptr = list->head;
	while (ptr != nullptr)
	{
		cout << ptr->value << " - " << ptr->count << endl;
		ptr = ptr->next;
	}
}

ElementType getElement(LinkedList *list, int indexOfElement)
{
	if (indexOfElement < getSize(list))
	{
		LinkedListElement *ptr = list->head;
		for (int n = 1; n <= indexOfElement; ++n)
		{
			ptr = ptr->next;
		}
		return ptr->value;
	}
	return 0;
}

bool searchElement(LinkedList *list, ElementType searched)
{
	LinkedListElement *ptr = list->head;
	while (ptr)
	{
		if (ptr->value.compare(searched) == 0)
		{
			return true;
		}
		ptr = ptr->next;
	}
	return false;
}