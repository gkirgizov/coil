#include <iostream>
#include <fstream>
#include <string>
#include "myGraph.h"
#include "RKsearch.h"
#include "myQueue.h"

using namespace std;

void substringSearch(string &filePath)
{
	string substring;
	cout << "Input your substring, dude!" << endl;
	cin.sync();
	cin >> substring;
	string text;
	ifstream inputFile(filePath, ios::in);
	if (inputFile.is_open())
	{
		while (!inputFile.eof())
		{
			string buffer;
			getline(inputFile, buffer);
			text.append(buffer);
		}
	}
	int result = rabinKarp(text, substring);
	if (result == -1)
	{
		cout << "Such substring doesn't exist in this text." << endl;
	}
	else
	{
		cout << "Index of the substring begining in the inputed text: " << result << endl;
	}
}

void buildMinimalSpanningTree(const string &filePath)
{
	Graph *inputGraph = init();
	readGraphFromFile(filePath, inputGraph);
	Graph *spanningTree = minSpanningTree(inputGraph);
	deleteADT(inputGraph);
	printAdjacencyMatrix(spanningTree);
	deleteADT(spanningTree);
}


void main()
{
	//string filePath = "text.txt";
	//substringSearch(filePath);

	string filePath = "graph.txt";
	//Graph *gr = init();
	//readGraphFromFile(filePath, gr);
	//printGraph(gr);
	buildMinimalSpanningTree(filePath);
}