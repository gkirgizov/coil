#pragma once

#include "myLinkedList.h"

//ArrayList - сортирвка списков на массивов, LinkedList - сортирвока списков на указателях.
typedef LinkedList ListType;

//Сортировка слиянием.
ListType* sortMerge(ListType *list);