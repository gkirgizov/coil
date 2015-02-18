#pragma once

typedef int ElementType;

struct Stack;

// Create stack.
Stack* initStack();

//ElementType getElement(Stack *stack, int elementIndex);

// Get size of the stack.
int getSize(Stack *stack);

// Get first element.
ElementType getHead(Stack *stack);

// Neck is next after Head.
ElementType getNeck(Stack *stack);

// Add element to the stack.
void stackPush(Stack *stack, ElementType addedData);

// Delete element from the stack.
void stackPop(Stack *stack);

// Delete the stack.
void deleteStack(Stack *stack);