#include "calculator.h"
#include "myStack.h"
#include <string>
#include <iostream>

using namespace std;

bool isBracketSequenceValid(string const &inputString)
{
	Stack *stack = initStack();
	for (unsigned int n = 0; n < inputString.size(); ++n)
	{
		const char element = inputString[n];
		if (element == '(')
		{
			stackPush(stack, 1);
		}
		else if (element == ')')
		{
			stackPush(stack, -1);
		}
		else if (element == '[')
		{
			stackPush(stack, 2);
		}
		else if (element == ']')
		{
			stackPush(stack, -2);
		}
		else if (element == '{')
		{
			stackPush(stack, 3);
		}
		else if (element == '}')
		{
			stackPush(stack, -3);
		}
		else
		{
			continue;
		}

		if ((getHead(stack) < 0) && (getNeck(stack) > 0))
		{
			if (abs(getHead(stack)) == getNeck(stack))
			{
				stackPop(stack);
				stackPop(stack);
			}
			else
			{
				return false;
			}
		}
	}
	bool result = (getSize(stack) == 0);
	deleteStack(stack);
	return result;
}

// Doing operation "key" in stack "operands" with POP and PUSH stack functions.
int operation(char key, Stack *operands)
{
	int tempResult = 0;
	if (key == '+')
	{
		tempResult = getNeck(operands) + getHead(operands);
	}
	else if (key == '-')
	{
		tempResult = getNeck(operands) - getHead(operands);
	}
	else if (key == '*')
	{
		tempResult = getNeck(operands) * getHead(operands);
	}
	//exception for zero
	else if (key == '/')
	{
		try
		{
			if (getHead(operands) == 0)
			{
				throw "100";
			}
			tempResult = getNeck(operands) / getHead(operands);
		}
		catch (char *error)
		{
			cout << "Error #" << error <<  " : Divisor can't be 0." << endl;
		}
	}
	stackPop(operands);
	stackPop(operands);
	stackPush(operands, tempResult);
	return tempResult;
}

bool isOperator(char token)
{
	return (token == '+' ||
		token == '-' ||
		token == '*' ||
		token == '/' ||
		token == '(' ||
		token == ')');
}
bool isFigure(char token)
{
	return (token >= '0' && token <= '9');
}

// Calculation of the Reverse Polish notation.
int calcRPN(string const &inputString)
{
	Stack *stack = initStack();
	for (const char &token : inputString)
	{
		if (isOperator(token))
		{
			operation(token, stack);
		}
		else if (isFigure(token))
		{
			stackPush(stack, token - 48);// static_cast<int>(token)-48);
		}
	}
	int temp = getHead(stack);
	deleteStack(stack);
	return temp;
}

// Is token's priority lower than priority of head in stack or equal.
bool checkingPriority(Stack *operators, char token)
{
	if (getHead(operators) == '*' || getHead(operators) == '/')
	{
		return true;
	}
	return (token == '+' || token == '-');
}

//--//Calculation of the infix notation.
//int calcIN(string inputString)
//{
//	Stack *operands = initStack();
//	Stack *operators = initStack();
//	stackPush(operators, '(');
//	inputString.push_back(')');
//
//	for (const char &token : inputString)
//	{
//		if (isOperator(token))
//		{
//			if (token == ')')
//			{
//				while (getHead(operators) != '(')
//				{
//					operation(getHead(operators), operands);
//					stackPop(operators);
//				}
//				stackPop(operators);
//			}
//			else if (getSize(operands) > 1 && checkingPriority(operators, token))
//			{
//				operation(getHead(operators), operands);
//				stackPush(operators, token);
//			}
//			else
//			{
//				stackPush(operators, token);
//			}
//		}
//		else if (token != ' ')
//		{
//			stackPush(operands, token - 48);
//		}
//	}
//	return getHead(operands);
//}

string infixNotatonToRPN(string const &inputString)
{
	if (isBracketSequenceValid(inputString))
	{
		string outputString;
		Stack *operators = initStack();
		for (const char &token : inputString)
		{
			if (token == ' ')
			{
				continue;
			}
			else if (isFigure(token))
			{
				outputString.push_back(token);
			}
			else if (token == '(')
			{
				stackPush(operators, token);
			}
			else if (token == ')')
			{
				while (getHead(operators) != '(')
				{
					outputString.push_back(getHead(operators));
					stackPop(operators);
				}
				stackPop(operators);
			}
			else if (isOperator(token))
			{
				//Пока голова стека - оператор, но не скобка
				//и пока приоритет токена меньше или равен приоритету головы.
				while ((isOperator(getHead(operators)) && (getHead(operators) != '(' && getHead(operators) != ')'))
					&& (checkingPriority(operators, token)))
				{
					outputString.push_back(getHead(operators));
					stackPop(operators);
				}
				stackPush(operators, token);
			}
			else
			{
				cout << "Error: unexpected symbol: " << token << endl;
				deleteStack(operators);
				return "";
			}
		}
		while (getSize(operators) > 0)
		{
			outputString.push_back(getHead(operators));
			stackPop(operators);
		}
		deleteStack(operators);
		return outputString;
	}
	cout << "Error: invalid bracket sequence." << endl;
	return "";
}