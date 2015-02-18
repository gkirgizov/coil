#include <iostream>
#include <fstream>
#include <string>
#include "myLinkedList.h"
#include "myStack.h"
#include "myQueue.h"
//#include "sortMerge.h"

using namespace std;

// Task 1
//void task1(string iFilePath, string oFilePath, int a, int b)
//{
//	ifstream ifile(iFilePath, ios::in);
//	ofstream ofile(oFilePath, ios::out);
//	if (ifile.is_open())
//	{
//		//Stack *aNumbers = initStack();
//		Stack *abNumbers = initStack();
//		Stack *bNumbers = initStack();
//		while (!ifile.eof())
//		{
//			int buffer;
//			ifile >> buffer;
//			if (buffer < a)
//			{
//				ofile << buffer << " ";
//			}
//			else if (buffer > b)
//			{
//				enqueue(bNumbers, buffer);
//			}
//			else
//			{
//				enqueue(abNumbers, buffer);
//			}
//		}
//		while (getSize(abNumbers) != 0)
//		{
//			ofile << getHead(abNumbers) << " ";
//			stackPop(abNumbers);
//		}
//		while (getSize(bNumbers) != 0)
//		{
//			ofile << getHead(bNumbers) << " ";
//			stackPop(bNumbers);
//		}
//		deleteStack(abNumbers);
//		deleteStack(bNumbers);
//	}
//}

void task1(string iFilePath, string oFilePath, int a, int b)
{
	ifstream ifile(iFilePath, ios::in);
	ofstream ofile(oFilePath, ios::out);
	if (ifile.is_open())
	{
		Queue *abNumbers = initQueue();
		Queue *bNumbers = initQueue();

		while (!ifile.eof())
		{
			int buffer = 0;
			ifile >> buffer;
			if (buffer < a)
			{
				ofile << buffer << " ";
			}
			else if (buffer > b)
			{
				enqueue(bNumbers, buffer);
			}
			else
			{
				enqueue(abNumbers, buffer);
			}
		}

		while (getSize(abNumbers) != 0)
		{
			ofile << dequeue(abNumbers) << " ";
		}
		while (getSize(bNumbers) != 0)
		{
			ofile << dequeue(bNumbers) << " ";
		}
		deleteQueue(abNumbers);
		deleteQueue(bNumbers);
	}
	ifile.close();
	ofile.close();
}

// Task 2
bool isListSymmetric(string inputFilePath)
{
	ifstream ifile(inputFilePath, ios::in);
	if (ifile.is_open())
	{
		LinkedList *numbers = initList();
		while (!ifile.eof())
		{
			int buffer;
			ifile >> buffer;
			addElement(numbers, buffer);
		}
		unsigned int nCount = getSize(numbers);
		for (unsigned int n = 0; n <= nCount / 2; ++n)
		{
			if (getElement(numbers, n) != getElement(numbers, nCount - n - 1))
			{
				deleteList(numbers);
				return false;
			}
		}
		deleteList(numbers);
	}
	ifile.close();
	return true;
}

void main()
{
	//cout << isListSymmetric("task2.txt") << endl;
	task1("f.txt", "g.txt", 3, 7);
}