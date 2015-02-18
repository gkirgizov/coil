#include "myTree.h"
#include <stdlib.h>
#include <iostream>

#include <fstream>
#include <string>

using namespace std;

struct TreeElement
{
	ElementType data;
	TreeElement *left = nullptr;
	TreeElement *right = nullptr;
};

struct Tree
{
	TreeElement *root = nullptr;
};

Tree* initTree()
{
	return new Tree;
}

// Рекурсивная функция добавления элемента в дерево.
void addElementRecursion(TreeElement *ptr, ElementType addedData)
{
	if (addedData < ptr->data)
	{
		if (ptr->left == nullptr)
		{
			ptr->left = new TreeElement;
			ptr->left->data = addedData;
		}
		ptr = ptr->left;
	}
	else if (addedData > ptr->data)
	{
		if (ptr->right == nullptr)
		{
			ptr->right = new TreeElement;
			ptr->right->data = addedData;
		}
		ptr = ptr->right;
	}
	if (ptr->data != addedData)
	{
		addElementRecursion(ptr, addedData);
	}
}
void addElement(Tree *tree, ElementType addedData)
{
	TreeElement *ptr = tree->root;
	if (ptr != nullptr)
	{
		addElementRecursion(ptr, addedData);
	}
	else
	{
		tree->root = new TreeElement;
		tree->root->data = addedData;
	}
}

// Рекурсивная функция удаления элемента из дерева.
TreeElement* deleteElementRecursion(TreeElement *ptr, ElementType key)
{
	if (!ptr)
	{
		return ptr;
	}
	if (ptr->data == key)
	{
		TreeElement *p = nullptr;
		TreeElement *p2 = nullptr;
		if (ptr->left == ptr->right)
		{
		}
		else if (ptr->left == nullptr)
		{
			p = ptr->right;
		}
		else if (ptr->right == nullptr)
		{
			p = ptr->left;
		}
		else
		{
			p = ptr->right;
			p2 = ptr->right;
			while (p2->left != nullptr)
			{
				p2 = p2->left;
			}
			p2->left = ptr->left;
		}
		delete ptr;
		return p;
	}

	if (ptr->data < key)
	{
		ptr->right = deleteElementRecursion(ptr->right, key);
	}
	else
	{
		ptr->left = deleteElementRecursion(ptr->left, key);
	}
	return ptr;
}

void deleteElement(Tree *tree, ElementType deletedData)
{
	if (tree->root != nullptr)
	{
		TreeElement *ptr = tree->root;
		deleteElementRecursion(ptr, deletedData);
	}
}

// Рекурсивная функция вывода значений элементов дерева.
// Параметр key определяет порядок обхода (key = 0 - по умолчанию):
// 0 - внутренний (по возрастанию);
// 1 - внутренний (по убыванию);
// 2 - обратный;
// 3 - прямой.
void printTreeRecursion(TreeElement *ptr, string &outputString, int key)
{
	if (ptr != nullptr)
	{
		if (key == 0)
		{
			printTreeRecursion(ptr->left, outputString, key);
			cout << ptr->data << endl;
			outputString.push_back(ptr->data);
			printTreeRecursion(ptr->right, outputString, key);
		}
		else if (key == 1)
		{
			printTreeRecursion(ptr->right, outputString, key);
			cout << ptr->data << endl;
			outputString.push_back(ptr->data);
			printTreeRecursion(ptr->left, outputString, key);
		}
		else if (key == 2)
		{
			printTreeRecursion(ptr->right, outputString, key);
			printTreeRecursion(ptr->left, outputString, key);
			cout << ptr->data << endl;
			outputString.push_back(ptr->data);
		}
		else if (key == 3)
		{
			cout << ptr->data << endl;
			outputString.push_back(ptr->data);
			printTreeRecursion(ptr->right, outputString, key);
			printTreeRecursion(ptr->left, outputString, key);
		}
	}
}

string printTree(Tree *tree, int key)
{
	TreeElement *ptr = tree->root;
	string outputString;
	printTreeRecursion(ptr, outputString, key);
	return outputString;
}

// Проверка на принадлежность элемента множеству.
bool isIncluded(Tree *tree, ElementType checkingData)
{
	TreeElement *ptr = tree->root;
	while (ptr != nullptr)
	{
		if (checkingData < ptr->data)
		{
			ptr = ptr->left;
		}
		else if (checkingData > ptr->data)
		{
			ptr = ptr->right;
		}
		else
		{
			return true;
		}
	}
	return false;
}

// Рекурсивная функция удаления дерева.
void deleteTreeRecursion(TreeElement *ptr)
{
	if (ptr != nullptr)
	{
		deleteTreeRecursion(ptr->left);
		deleteTreeRecursion(ptr->right);
		delete ptr;
	}
}
void deleteTree(Tree *tree)
{
	TreeElement *ptr = tree->root;
	deleteTreeRecursion(ptr);
	delete tree;
}

// FOR_TASK_THREE.
TreeElement* createTreeElement()
{
	return new TreeElement;
}
TreeElement* getRoot(Tree *tree)
{
	return tree->root;
}
TreeElement* getLeftSon(TreeElement *parent)
{
	return parent->left;
}
TreeElement* getRightSon(TreeElement *parent)
{
	return parent->right;
}
void addLeftSon(TreeElement *parent, TreeElement *son)
{
	parent->left = son;
}
void addRightSon(TreeElement *parent, TreeElement *son)
{
	parent->right = son;
}
void assignData(TreeElement *element, ElementType assignedData)
{
	element->data = assignedData;
}
ElementType getData(TreeElement *root)
{
	return root->data;
}

