#include <iostream>
#include <fstream>
#include <vector>
#include "myGraph.h"
#include "myQueue.h"

using namespace std;

struct Graph
{
	vector<vector<IntType>> vertexes;
	unsigned int rows = 0;
	unsigned int columns = 0;
};

void addLink(Graph *graph, unsigned int row, unsigned int column, IntType weight)
{
	if (row > column)
	{
		if (graph->rows <= row)
		{
			graph->vertexes.resize(row + 1);
			graph->rows = row + 1;
		}
		if (graph->columns <= row)
		{
			for (vector<unsigned int> &str : graph->vertexes)
			{
				str.resize(row + 1);
			}
			graph->columns = row + 1;
		}
	}
	else
	{
		if (graph->rows <= column)
		{
			graph->vertexes.resize(column + 1);
			graph->rows = column + 1;
		}
		if (graph->columns <= column)
		{
			for (vector<unsigned int> &str : graph->vertexes)
			{
				str.resize(column + 1);
			}
			graph->columns = column + 1;
		}
	}
	graph->vertexes[row][column] = weight;
	graph->vertexes[column][row] = weight;
}

void deleteLink(Graph *graph, unsigned int row, unsigned int column)
{
	addLink(graph, row, column, 0);
}

Graph* init(unsigned int rows, unsigned int columns)
{
	Graph* graph = new Graph;
	if (rows && columns)
	{
		deleteLink(graph, rows - 1, columns - 1);
	}
	return graph;
}

void deleteADT(Graph *graph)
{
	delete graph;
}

void printGraphRecursion(Graph *graph, vector<bool> &isVisited, unsigned int vertex)
{
	cout << endl << "parent: " << vertex << endl << "chldrn:";
	isVisited[vertex] = true;
	Queue *children = initQueue();
	for (unsigned int n = 0; n < graph->columns; ++n)
	{
		if (graph->vertexes[vertex][n] && !isVisited[n])
		{
			cout << " " << n;
			enqueue(children, n);
		}
	}
	cout << endl;
	while (getSize(children))
	{
		printGraphRecursion(graph, isVisited, dequeue(children));
	}
	deleteQueue(children);
}
void printGraph(Graph *graph, unsigned int firstVertex)
{
	vector<bool> isVisited(graph->columns, false);
	printGraphRecursion(graph, isVisited, firstVertex);
}

void printAdjacencyMatrix(Graph *graph)
{
	for (const vector<IntType> &row : graph->vertexes)
	{
		for (const IntType &edge : row)
		{
			cout << edge << " ";
		}
		cout << endl;
	}
}


void readGraphFromFile(const string &inputFilePath, Graph *graph)
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
					addLink(graph, m, n, buffer);
				}
			}
		}
	}
	inputFile.close();
}

// Dijkstra
unsigned int srchNrstVrtx(vector<IntType> &row, vector<bool> &isVisited)
{
	unsigned int nearest = row.size();
	IntType nearestWay = INT_MAX;
	for (unsigned int n = 0; n < row.size(); ++n)
	{
		if (!isVisited[n])
		{
			if (row[n] < nearestWay)
			{
				nearestWay = row[n];
				nearest = n;
			}
		}
	}
	return nearest;
}
bool isUnvisitedExist(vector<bool> isVisited)
{
	for (unsigned int vertex = 0; vertex < isVisited.size(); ++vertex)
	{
		if (!isVisited[vertex])
		{
			return true;
		}
	}
	return false;
}

void dijkstra(Graph *graph, unsigned int vertex, vector<unsigned int> &lengths)
{
	const unsigned int inf = UINT_MAX;
	lengths.assign(graph->columns, inf);
	lengths[vertex - 1] = 0;
	vector<bool> isVisited(graph->rows, false);
	while (isUnvisitedExist(isVisited))
	{
		unsigned int nrstVrtx = srchNrstVrtx(lengths, isVisited);
		isVisited[nrstVrtx] = true;

		vector<IntType> &vertexNow = graph->vertexes[nrstVrtx];
		for (unsigned int adjacent = 0; adjacent < vertexNow.size(); ++ adjacent)
		{
			if (!isVisited[adjacent] && vertexNow[adjacent] != 0)
			{
				unsigned int newLength = lengths[nrstVrtx] + vertexNow[adjacent];
				if (lengths[adjacent] > newLength)
				{
					lengths[adjacent] = newLength;
				}
			}
		}
	}
}

// Spanning tree
bool isCyclicRecursion(Graph *graph, unsigned int vertex, vector<bool> &isVisited, unsigned int prevVertex)
{
	if (isVisited[vertex])
	{
		return true;
	}
	isVisited[vertex] = true;
	for (unsigned int n = 0; n < graph->rows; ++n)
	{
		if (graph->vertexes[vertex][n] && n != prevVertex)
		{
			if (isCyclicRecursion(graph, n, isVisited, vertex))
			{
				return true;
			}
		}
	}
	return false;
}
bool isCyclic(Graph *graph, unsigned int firstVertex)
{
	vector<bool> isVisited(graph->rows, false);
	return isCyclicRecursion(graph, firstVertex, isVisited, firstVertex);
}

struct Edge
{
	unsigned int vertex1;
	unsigned int vertex2;
	int weight = 1;
};

void edgesSort(vector<Edge> &edges)
{
	const unsigned int edgesCount = edges.size();
	for (unsigned int n = 0; n < edgesCount; ++n)
	{
		for (unsigned int m = n + 1; m < edgesCount; ++m)
		{
			if (edges[n].weight > edges[m].weight)
			{
				swap(edges[n], edges[m]);
			}
		}
	}
}

Graph* minSpanningTree(Graph *graph)
{
	vector<Edge> edges;
	for (unsigned int row = 0; row < graph->rows; ++row)
	{
		for (unsigned int column = row; column < graph->columns; ++column)
		{
			if (graph->vertexes[row][column])
			{
				Edge tempEdge;
				tempEdge.vertex1 = row;
				tempEdge.vertex2 = column;
				tempEdge.weight = graph->vertexes[row][column];
				edges.push_back(tempEdge);
			}
		}
	}
	edgesSort(edges);
	
	Graph *spanningTree = init(graph->rows, graph->columns);
	for (const Edge &edge : edges)
	{
		addLink(spanningTree, edge.vertex1, edge.vertex2, edge.weight);
		if (isCyclic(spanningTree, edge.vertex1))
		{
			deleteLink(spanningTree, edge.vertex1, edge.vertex2);
		}
	}
	return spanningTree;
}
