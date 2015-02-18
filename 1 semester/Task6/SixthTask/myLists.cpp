#include "myLists.h"
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

//Общий интерфейс односвязного и циклического списков.
List* initList()
{
	return new List;
}

int getSize(List *list)
{
	int size = 0;
	ListElement *cursor = list->head;
	for (size; (cursor != nullptr) && (cursor->next != list->head); ++size)
	{
		cursor = cursor->next;
	}
	if (cursor->next == list->head)
	{
		++size;
	}
	return size;
}

//Интерфейс линейного односвязного сортированного списка.
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
			ListElement *cursor = list->head;
			while ((cursor->next != nullptr) && (cursor->next->value < addedValue))
			{
				cursor = cursor->next;
			}
			addedElement->next = cursor->next;
			cursor->next = addedElement;
		}
	}
	else
	{
		list->head = addedElement;
	}
}

void deleteElement(List *list, ElementType deletedValue)
{
	ListElement *cursor = list->head;
	if (cursor != nullptr)
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
			while ((cursor->next != nullptr) && (cursor->next->value != deletedValue))
			{
				cursor = cursor->next;
			}
			while ((cursor->next != nullptr) && (cursor->next->value == deletedValue))
			{
				ListElement *tempElement = cursor->next;
				cursor->next = cursor->next->next;
				delete tempElement;
			}
		}
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

void printList(List *list)
{
	ListElement *cursor = list->head;
	while (cursor != nullptr)
	{
		cout << cursor->value << endl;
		cursor = cursor->next;
	}
}

//Интерфейс циклического односвязного списка.
void push(List *list, ElementType addedValue)
{
	ListElement *addedElement = new ListElement;
	addedElement->value = addedValue;

	if (list->head != nullptr)
	{
		ListElement *cursor = list->head;
		while (cursor->next != list->head)
		{
			cursor = cursor->next;
		}
		addedElement->next = list->head;
		cursor->next = addedElement;
	} else
	{
		list->head = addedElement;
		addedElement->next = list->head;
	}
}

int getElement(List *list, int indexOfElement)
{
	if (list->head != nullptr)
	{
		ListElement *cursor = list->head;
		for (indexOfElement; indexOfElement > 0; --indexOfElement)
		{
			cursor = cursor->next;
		}
		return cursor->value;
	}
	return -1;
}

void deleteElementByIndex(List *list, int indexOfElement)
{
	if (list->head != nullptr)
	{
		ListElement *cursor = list->head;
		for (indexOfElement; indexOfElement > 1; --indexOfElement)
		{
			cursor = cursor->next;
		}
		//если удаляемый элемент - это head, то перекидываем head на след. элемент
		if (cursor->next == list->head)
		{
			list->head = cursor->next->next;
		}
		ListElement *tempElement = cursor->next->next;
		delete cursor->next;
		cursor->next = tempElement;
	}
}

void deleteCycleList(List *list)
{
	if (list->head != nullptr)
	{
		while (list->head->next != list->head)
		{
			ListElement *tempElement = list->head->next->next;
			delete list->head->next;
			list->head->next = tempElement;
		}
		delete list->head;
	}
	delete list;
}