#include "myList.h"
#include <iostream>

using namespace std;

struct ListElement
{
	ElementType value;
	ListElement *next = nullptr;
};

struct List
{
	ListElement *head = nullptr;
};

List* initList()
{
	return new List;
}

int getSize(List *list)
{
	int size = 0;
	ListElement *ptr = list->head;
	for (size; (ptr != nullptr) && (ptr->next != list->head); ++size)
	{
		ptr = ptr->next;
	}
	if (ptr->next == list->head)
	{
		++size;
	}
	return size;
}

void addElement(List *list, ElementType addedValue)
{
	ListElement *addedElement = new ListElement;
	addedElement->value = addedValue;
	if (list->head != nullptr)
	{
		if (list->head->value > addedValue)
		{
			addedElement->value = list->head->value;
			list->head->value = addedValue;
			ListElement *tempElement = list->head->next;
			list->head->next = addedElement;
			addedElement->next = tempElement;
		}
		else
		{
			ListElement *ptr = list->head;
			while ((ptr->next != nullptr) && (ptr->next->value < addedValue))
			{
				ptr = ptr->next;
			}
			addedElement->next = ptr->next;
			ptr->next = addedElement;
		}
	}
	else
	{
		list->head = addedElement;
	}
}

void deleteElement(List *list, ElementType deletedValue)
{
	ListElement *ptr = list->head;
	if (ptr != nullptr)
	{
		if (list->head->value == deletedValue)
		{
			while ((list->head != nullptr) && (list->head->value == deletedValue))
			{
				ListElement *tempElement = list->head;
				list->head = list->head->next;
				delete tempElement;
			}
		} 
		else
		{
			while ((ptr->next != nullptr) && (ptr->next->value != deletedValue))
			{
				ptr = ptr->next;
			}
			while ((ptr->next != nullptr) && (ptr->next->value == deletedValue))
			{
				ListElement *tempElement = ptr->next;
				ptr->next = ptr->next->next;
				delete tempElement;
			}
		}
	}
}

void printList(List *list)
{
	ListElement *ptr = list->head;
	while (ptr != nullptr)
	{
		cout << ptr->value << endl;
		ptr = ptr->next;
	}
}

void printWithoutRepeat(List *list)
{
	ListElement *ptr = list->head;
	while (ptr != nullptr)
	{
		unsigned int count = 1;
		if (ptr->next != nullptr)
		{
			while (ptr->next->value == ptr->value)
			{
				++count;
				ptr = ptr->next;
			}
		}
		cout << ptr->value << " count: " << count << endl;
		ptr = ptr->next;
	}
}

void deleteList(List *list)
{
	while (list->head != nullptr)
	{
		ListElement *tempElement = list->head;
		list->head = list->head->next;
		delete tempElement;
	}
	delete list;
}