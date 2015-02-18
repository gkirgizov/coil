#include <iostream>
#include "myArrayList.h"

using namespace std;

//struct ArrayListElement
//{
//	ElementType value;
//};

struct ArrayList
{
	unsigned int capacity = 127;
	unsigned int size = 0;
	ElementType *data = new ElementType[capacity];
	//ArrayListElement *data = new ArrayListElement[capacity];
};

ArrayList* initList()
{
	return new ArrayList;
}

int getSize(ArrayList *list)
{
	return list->size;
}

void deleteList(ArrayList *list)
{
	delete[] list->data;
	delete list;
}

void addElement(ArrayList *list, ElementType addedValue)
{
	//ArrayListElement addedElement;
	//addedElement.value = addedValue;
	if (list->size < list->capacity)
	{
		list->data[list->size] = addedValue;
		++list->size;
	}
	else
	{
		ArrayList *biggerList = new ArrayList;
		biggerList->capacity <<= 1;
		for (unsigned int n = 0; n < list->size; ++n)
		{
			biggerList->data[n] = list->data[n];
		}
		biggerList->data[list->size] = addedValue;
		biggerList->size = list->size + 1;
		ArrayList *tempptr = list;
		list = biggerList;
		deleteList(tempptr);
	}
}

void deleteElement(ArrayList *list, unsigned int indexOfElement)
{
	for (unsigned int n = indexOfElement; n < list->size - 1; ++n)
	{
		list->data[n] = list->data[n + 1];
	}
	--list->size;
}

void printList(ArrayList *list)
{
	for (unsigned int n = 0; n < list->size; ++n)
	{
		cout << list->data[n] << endl;
	}
}

ElementType getElement(ArrayList *list, unsigned int indexOfElement)
{
	if (indexOfElement < list->size)
	{
		return list->data[indexOfElement];
	}
	return 0;
}