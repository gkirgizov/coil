#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include "myList.h"
#include "myGraph.h"

using namespace std;

// TASK 1
void task1()
{
	List *numbers = initList();
	cout << "Enter numbers (0 is the end of input): " << endl;
	cout << "These numbers wil be outputted." << endl;
	int buffer = -1;
	cin >> buffer;
	while (buffer)
	{
		addElement(numbers, buffer);
		cin >> buffer;
	}
	printWithoutRepeat(numbers);
	deleteList(numbers);
}

// TASK 2
vector<vector<int>> readMatrixFromFile(string &filePath)
{
	vector<vector<int>> matrix;
	ifstream inputFile(filePath, ios::in);
	if (inputFile.is_open())
	{
		unsigned int height = 0;
		inputFile >> height; //rows
		matrix.resize(height);
		unsigned int width;
		inputFile >> width; //columns
		for (vector<int> &row : matrix)
		{
			row.resize(width);
		}
		for (unsigned int m = 0; m < height; ++m)
		{
			for (unsigned int n = 0; n < width; ++n)
			{
				inputFile >> matrix[m][n];
			}
		}
	}
	inputFile.close();
	return matrix;
}

void task2(vector<vector<int>> &matrix)
{
	int pointRow = -1;
	int pointColumn = -1;
	for (const vector<int> &row : matrix)
	{
		unsigned int columnIndex = 0;
		int minRowValue = row[columnIndex];
		for (unsigned int n = 1; n < row.size(); ++n)
		{
			if (row[n] < minRowValue)
			{
				minRowValue = row[n];
				columnIndex = n;
			}
		}

		unsigned int rowIndex = 0;
		int maxColumnValue = matrix[rowIndex][columnIndex];
		for (unsigned int m = 1; m < matrix.size(); ++m)
		{
			if (matrix[m][columnIndex] > maxColumnValue)
			{
				maxColumnValue = matrix[m][columnIndex];
				rowIndex = m;;
			}
		}

		if (minRowValue == maxColumnValue)
		{
			pointRow = rowIndex + 1;
			pointColumn = columnIndex + 1;
		}
	}
	if (pointRow != -1)
	{
		cout << "Coordinates of the saddle point of the matrix: " << pointRow << ", " << pointColumn << endl;
	}
	else
	{
		cout << "There's no saddle points." << endl;
	}
}

// TASK 3
void readGraphFromFile(string &inputFilePath, Graph *graph)
{
	ifstream inputFile(inputFilePath, ios::in);
	if (inputFile.is_open())
	{
		unsigned int size = 0;
		inputFile >> size;
		for (unsigned int m = 0; m < size; ++m)
		{
			for (unsigned int n = 0; n < size; ++n)
			{
				int buffer = 0;
				inputFile >> buffer;
				if (buffer)
				{
					addLink(graph, m + 1, n + 1, buffer);
				}
			}
		}
	}
	inputFile.close();
}

void main()
{
	string filePath = "graph.txt";
	Graph *graph = init();
	readGraphFromFile(filePath, graph);
	printGraph(graph);
	deleteADT(graph);
	//vector<vector<int>> matrix = readMatrixFromFile(filePath);
	//task2(matrix);
}