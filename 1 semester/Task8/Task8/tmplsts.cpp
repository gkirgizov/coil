//#include "tmplsts.h"
//#include <iostream>
//#include <string>
//
//using namespace std;
//
////struct ArrayListElement
////{
////	ElementType value;
////};
//
//struct ArrayList
//{
//	unsigned int capacity = 127;
//	unsigned int size = 0;
//	ElementType *data = new ElementType[capacity];
//	//ArrayListElement *data = new ArrayListElement[capacity];
//};
//
//struct LinkedListElement
//{
//	ElementType value;
//	LinkedListElement *next = nullptr;
//};
//
//struct LinkedList
//{
//	LinkedListElement *head = nullptr;
//	LinkedListElement *tail = nullptr;
//};
//
//
//ListType* initList()
//{
//	ListType *list = new ListType;
//	return list;
//}
//
////Интерфейс односвязного списка на указателях.
//int getSize(LinkedList *list)
//{
//	int size = 0;
//	LinkedListElement *cursor = list->head;
//	for (size; cursor != nullptr; ++size)
//	{
//		cursor = cursor->next;
//	}
//	return size;
//}
//
//void deleteList(LinkedList *list)
//{
//	while (list->head != nullptr)
//	{
//		LinkedListElement *tempElement = list->head;
//		list->head = list->head->next;
//		delete tempElement;
//	}
//	//list->tail = nullptr;
//}
//
//void addElement(LinkedList *list, ElementType addedValue)
//{
//	LinkedListElement *addedElement = new LinkedListElement;
//	addedElement->value = addedValue;
//	if (list->head != nullptr && list->tail != nullptr)
//	{
//		list->tail->next = addedElement;
//		list->tail = addedElement;
//	}
//	else
//	{
//		list->head = addedElement;
//		list->tail = addedElement;
//	}
//}
//
//void deleteElement(LinkedList *list, int indexOfElement)
//{
//	if (indexOfElement < getSize(list))
//	{
//		LinkedListElement *cursor = list->head;
//		if (indexOfElement == 0)
//		{
//			if (list->tail == list->head)
//			{
//				list->tail = nullptr;
//			}
//			list->head = list->head->next;
//			delete cursor;
//		}
//		else
//		{
//			for (int n = 1; n < indexOfElement; ++n)
//			{
//				cursor = cursor->next;
//			}
//			LinkedListElement *tempElement = cursor->next->next;
//			delete cursor->next;
//			cursor->next = tempElement;
//		}
//	}
//}
//
//void printList(LinkedList *list)
//{
//	LinkedListElement *cursor = list->head;
//	while (cursor != nullptr)
//	{
//		cout << cursor->value << endl;
//		cursor = cursor->next;
//	}
//}
//
//ElementType getElement(LinkedList *list, int indexOfElement)
//{
//	if (indexOfElement < getSize(list))
//	{
//		LinkedListElement *cursor = list->head;
//		for (int n = 1; n <= indexOfElement; ++n)
//		{
//			cursor = cursor->next;
//		}
//		return cursor->value;
//	}
//	return 0;
//}
//
//
////Интерфейс списка на массивах.
//int getSize(ArrayList *list)
//{
//	return list->size;
//}
//
//void deleteList(ArrayList *list)
//{
//	//for (unsigned int n = 0; n < list->size; ++n)
//	//{
//	//	delete &list->data[n];
//	//}
//	delete[] list->data;
//	delete list;
//}
//
//void addElement(ArrayList *list, ElementType addedValue)
//{
//	//ArrayListElement addedElement;
//	//addedElement.value = addedValue;
//	if (list->size < list->capacity)
//	{
//		list->data[list->size] = addedValue;
//		++list->size;
//	}
//	else
//	{
//		ArrayList *biggerList = new ArrayList;
//		biggerList->capacity <<= 1;
//		for (unsigned int n = 0; n < list->size; ++n)
//		{
//			biggerList->data[n] = list->data[n];
//		}
//		biggerList->data[list->size] = addedValue;
//		biggerList->size = list->size + 1;
//		ArrayList *tempptr = list;
//		list = biggerList;
//		deleteList(tempptr);
//	}
//}
//
//void deleteElement(ArrayList *list, unsigned int indexOfElement)
//{
//	for (unsigned int n = indexOfElement; n < list->size - 1; ++n)
//	{
//		list->data[n] = list->data[n + 1];
//	}
//	--list->size;
//}
//
//void printList(ArrayList *list)
//{
//	for (unsigned int n = 0; n < list->size; ++n)
//	{
//		cout << list->data[n] << endl;
//	}
//}
//
//ElementType getElement(ArrayList *list, unsigned int indexOfElement)
//{
//	if (indexOfElement < list->size)
//	{
//		return list->data[indexOfElement];
//	}
//	return 0;
//}
//
//
////MERGE_SORT
//string upperCase(string inputString)
//{
//	string outputString = inputString;
//	for (unsigned int n = 0; n < outputString.size(); ++n)
//	{
//		outputString[n] = toupper(outputString[n]);
//	}
//	return outputString;
//}
//
//ListType* merge(ListType *listHalf1, ListType *listHalf2)
//{
//	ListType *resultList = initList();
//	while (getSize(listHalf1) > 0 && getSize(listHalf2) > 0)
//	{
//		if (getElement(listHalf1, 0) <= getElement(listHalf2, 0))
//		{
//			addElement(resultList, getElement(listHalf1, 0));
//			deleteElement(listHalf1, 0);
//		}
//		else
//		{
//			addElement(resultList, getElement(listHalf2, 0));
//			deleteElement(listHalf2, 0);
//		}
//	}
//	while (getSize(listHalf1) > 0)
//	{
//		addElement(resultList, getElement(listHalf1, 0));
//		deleteElement(listHalf1, 0);
//	}
//	while (getSize(listHalf2) > 0)
//	{
//		addElement(resultList, getElement(listHalf2, 0));
//		deleteElement(listHalf2, 0);
//	}
//	return resultList;
//}
//
//ListType* sortMerge(ListType *list)
//{
//	const int size = getSize(list);
//	if (size <= 1)
//	{
//		return list;
//	}
//	else
//	{
//		ListType *listHalf1 = initList();
//		ListType *listHalf2 = initList();
//		ListType *resultList = initList();
//		for (int n = 0; n < size / 2; ++n)
//		{
//			addElement(listHalf1, getElement(list, n));
//		}
//		
//		for (int n = size / 2; n < size; ++n)
//		{
//			addElement(listHalf2, getElement(list, n));
//		}
//		listHalf1 = sortMerge(listHalf1);
//		listHalf2 = sortMerge(listHalf2);
//		resultList = merge(listHalf1, listHalf2);
//		deleteList(listHalf1);
//		deleteList(listHalf2);
//		return resultList;
//	}
//}
//
