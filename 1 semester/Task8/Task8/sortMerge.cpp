#include <string>
#include <iostream>
//#include "myArrayList.h"
#include "myLinkedList.h"
#include "sortMerge.h"

using namespace std;

string upperCase(string inputString)
{
	string outputString = inputString;
	for (unsigned int n = 0; n < outputString.size(); ++n)
	{
		outputString[n] = toupper(outputString[n]);
	}
	return outputString;
}

ListType* merge(ListType *listHalf1, ListType *listHalf2)
{
	ListType *resultList = initList();
	while (getSize(listHalf1) > 0 && getSize(listHalf2) > 0)
	{
		if (getElement(listHalf1, 0) <= getElement(listHalf2, 0))
		{
			addElement(resultList, getElement(listHalf1, 0));
			deleteElement(listHalf1, 0);
		}
		else
		{
			addElement(resultList, getElement(listHalf2, 0));
			deleteElement(listHalf2, 0);
		}
	}
	while (getSize(listHalf1) > 0)
	{
		addElement(resultList, getElement(listHalf1, 0));
		deleteElement(listHalf1, 0);
	}
	while (getSize(listHalf2) > 0)
	{
		addElement(resultList, getElement(listHalf2, 0));
		deleteElement(listHalf2, 0);
	}
	return resultList;
}

ListType* sortMerge(ListType *list)
{
	const int size = getSize(list);
	if (size <= 1)
	{
		return list;
	}
	else
	{
		ListType *listHalf1 = initList();
		ListType *listHalf2 = initList();
		ListType *resultList = initList();
		for (int n = 0; n < size / 2; ++n)
		{
			addElement(listHalf1, getElement(list, n));
		}

		for (int n = size / 2; n < size; ++n)
		{
			addElement(listHalf2, getElement(list, n));
		}
		listHalf1 = sortMerge(listHalf1);
		listHalf2 = sortMerge(listHalf2);
		resultList = merge(listHalf1, listHalf2);
		deleteList(listHalf1);
		deleteList(listHalf2);
		return resultList;
	}
}