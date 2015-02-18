#include "myStack.h"
#include <iostream>

using namespace std;

struct StackElement
{
	ElementType data;
	StackElement *next = nullptr;
};

struct Stack
{
	StackElement *head = nullptr;
};

Stack* initStack()
{
	Stack *stack = new Stack;
	return stack;
}

//ElementType getElement(Stack *stack, int elementIndex)
//{
//	if (stack->head != nullptr)
//	{
//		StackElement *cursor = stack->head;
//		for (elementIndex; cursor != nullptr && elementIndex > 0; --elementIndex)
//		{
//			cursor = cursor->next;
//		}
//		return cursor->data;
//	}
//	cout << "Oops.. stack is empty." << endl;
//	return 0;
//}

int getSize(Stack *stack)
{
	int size = 0;
	StackElement *cursor = stack->head;
	for (size; cursor != nullptr; ++size)
	{
		cursor = cursor->next;
	}
	return size;
}

ElementType getHead(Stack *stack)
{
	if (stack->head != nullptr)
	{
		return stack->head->data;
	}
	//cout << "Oops..stack is empty." << endl;
	return 0;
}

ElementType getNeck(Stack *stack)
{
	if (stack->head != nullptr && stack->head->next != nullptr)
	{
		return stack->head->next->data;
	}
	//cout << "Oops..stack has only the head." << endl;
	return 0;
}

void stackPush(Stack *stack, ElementType addedData)
{
	StackElement *newElement = new StackElement;
	newElement->data = addedData;
	newElement->next = stack->head;
	stack->head = newElement;
}

void stackPop(Stack *stack)
{
	if (stack->head != nullptr)
	{
		StackElement *tempElement = stack->head;
		stack->head = stack->head->next;
		delete tempElement;
	}
}

void deleteStack(Stack *stack)
{
	while (stack->head != nullptr)
	{
		StackElement *tempElement = stack->head;
		stack->head = stack->head->next;
		delete tempElement;
	}
}