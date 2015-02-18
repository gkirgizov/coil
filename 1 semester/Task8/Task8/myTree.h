#pragma once

#include <string>

typedef int ElementType;

struct TreeElement;

struct Tree;

Tree* initTree();

// Рекурсивная функция добавления элемента в дерево.
void addElement(Tree *tree, ElementType addedData);

// Удаление элемента из дерева.
void deleteElement(Tree *tree, ElementType deletedData);

// Рекурсивная функция вывода значений элементов дерева.
// Параметр key определяет порядок обхода (key = 0 - по умолчанию):
// 0 - внутренний (по возрастанию);
// 1 - внутренний (по убыванию);
// 2 - обратный;
// 3 - прямой.
std::string printTree(Tree *tree, int key = 0);

// Проверка на принадлежность элемента множеству.
bool isIncluded(Tree *tree, ElementType checkingData);

// Рекурсивная функция удаления элемента из дерева.
void deleteTree(Tree *tree);

// FOR_TASK_THREE.
TreeElement* createTreeElement();
TreeElement* getRoot(Tree *tree);
TreeElement* getLeftSon(TreeElement *parent);
TreeElement* getRightSon(TreeElement *parent);
void addLeftSon(TreeElement *parent, TreeElement *son);
void addRightSon(TreeElement *parent, TreeElement *son);
void assignData(TreeElement *element, ElementType assignedData);
ElementType getData(TreeElement *root);