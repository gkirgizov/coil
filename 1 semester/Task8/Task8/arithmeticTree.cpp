#include "myTree.h"
#include "arithmeticTree.h"
#include <iostream>
#include <fstream>
#include <string>

using namespace std;

bool isOperator(char token)
{
	return (token == '+' ||
		token == '-' ||
		token == '*' ||
		token == '/');
}
bool isDigit(char token)
{
	return (token >= '0' && token <= '9');
}
int doOperation(char key, int operand1, int  operand2)
{
	int tempResult = 0;
	if (key == '+')
	{
		tempResult = operand1 + operand2;
	}
	else if (key == '-')
	{
		tempResult = operand1 - operand2;
	}
	else if (key == '*')
	{
		tempResult = operand1 * operand2;
	}
	else if (key == '/')
	{
		if (operand2 != 0)
		{
			tempResult = operand1 / operand2;
		}
	}
	return tempResult;
}

string generateSubstring(string &inputString)
{
	string outputString;
	int openBracket = inputString.find('(');
	int closeBracket = inputString.rfind(')');
	outputString = inputString.substr(openBracket + 1, closeBracket - openBracket - 1);
	return outputString;
}

void arithmeticTreeRecursion(TreeElement *root, string substring)
{
	for (unsigned int n = 0; n < substring.size(); ++n)
	{
		if (substring[n] != ' ')
		{
			if (substring[n] == '(')
			{
				TreeElement *deeper = createTreeElement();
				if (getLeftSon(root) == nullptr)
				{
					addLeftSon(root, deeper);
				}
				else
				{
					addRightSon(root, deeper);
				}
				arithmeticTreeRecursion(deeper, generateSubstring(substring));
				for (n; substring[n] != ')' && n < substring.size(); ++n);
			}
			else if (isOperator(substring[n]))
			{
				assignData(root, substring[n]);
			}
			else if (isDigit(substring[n]))
			{
				TreeElement *digit = createTreeElement();
				assignData(digit, substring[n]);
				if (getLeftSon(root) == nullptr)
				{
					addLeftSon(root, digit);
				}
				else
				{
					addRightSon(root, digit);
				}
			}
		}
	}
}
Tree* arithmeticTree(const string &filePath)
{
	ifstream inputFile(filePath, ios::in);
	Tree *arithmeticPlant = initTree();
	if (inputFile.is_open())
	{
		addElement(arithmeticPlant, 0);
		string entireString;
		getline(inputFile, entireString);
		arithmeticTreeRecursion(getRoot(arithmeticPlant), generateSubstring(entireString));
	}
	return arithmeticPlant;
}

int calcTreeRecursion(TreeElement *ptr)
{
	ElementType left = getData(getLeftSon(ptr));
	if (isOperator(left))
	{
		left = calcTreeRecursion(getLeftSon(ptr));
	}
	else
	{
		left = left - 48;
	}
	ElementType right = getData(getRightSon(ptr));
	if (isOperator(right))
	{
		right = calcTreeRecursion(getRightSon(ptr));
	}
	else
	{
		right = right - 48;
	}
	return doOperation(getData(ptr), left, right);
}
int calcTree(Tree *arithmeticPlant)
{
	TreeElement *ptr = getRoot(arithmeticPlant);
	return calcTreeRecursion(ptr);
}