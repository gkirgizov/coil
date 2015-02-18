#pragma once

#include <string>

typedef int ElementType;

struct TreeElement;

struct Tree;

Tree* initTree();

// ����������� ������� ���������� �������� � ������.
void addElement(Tree *tree, ElementType addedData);

// �������� �������� �� ������.
void deleteElement(Tree *tree, ElementType deletedData);

// ����������� ������� ������ �������� ��������� ������.
// �������� key ���������� ������� ������ (key = 0 - �� ���������):
// 0 - ���������� (�� �����������);
// 1 - ���������� (�� ��������);
// 2 - ��������;
// 3 - ������.
std::string printTree(Tree *tree, int key = 0);

// �������� �� �������������� �������� ���������.
bool isIncluded(Tree *tree, ElementType checkingData);

// ����������� ������� �������� �������� �� ������.
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