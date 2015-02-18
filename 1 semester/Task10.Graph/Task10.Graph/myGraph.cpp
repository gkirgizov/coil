#include <iostream>
#include <fstream>
#include <vector>
#include "myGraph.h"

using namespace std;

struct Graph
{
	vector<vector<IntType>> vertexes;
	unsigned int strings = NULL;
	unsigned int columns = NULL;
};

void addLink(Graph *graph, unsigned int strng, unsigned int clmn, IntType length)
{
	if (strng > clmn)
	{
		if (graph->strings <= strng)
		{
			graph->vertexes.resize(strng);
			graph->strings = strng;
		}
		if (graph->columns <= strng)
		{
			for (vector<unsigned int> &str : graph->vertexes)
			{
				str.resize(strng);
			}
			graph->columns = strng;
		}
	}
	else
	{
		if (graph->strings <= clmn)
		{
			graph->vertexes.resize(clmn);
			graph->strings = clmn;
		}
		if (graph->columns <= clmn)
		{
			for (vector<unsigned int> &str : graph->vertexes)
			{
				str.resize(clmn);
			}
			graph->columns = clmn;
		}
	}
	graph->vertexes[strng - 1][clmn - 1] = length;
	graph->vertexes[clmn - 1][strng - 1] = length;
}

void deleteLink(Graph *graph, unsigned int strng, unsigned int clmn)
{
	addLink(graph, strng, clmn, 0);
}

Graph* init(unsigned int strings, unsigned int columns)
{
	Graph* graph = new Graph;
	if (strings && columns)
	{
		deleteLink(graph, strings, columns);
	}
	return graph;
}

//TODO
void deleteADT(Graph *graph)
{
	delete graph;
}

// Dijkstra
unsigned int srchNrstVrtx(vector<IntType> &strng, vector<bool> &isVisited)
{
	unsigned int nearest = strng.size();
	IntType nearestWay = INT_MAX;
	for (unsigned int n = 0; n < strng.size(); ++n)
	{
		if (!isVisited[n])
		{
			if (strng[n] < nearestWay)
			{
				nearestWay = strng[n];
				nearest = n;
			}
		}
	}
	return nearest;
}

bool srchUnvstd(vector<bool> isVisited)
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
	vector<bool> isVisited(graph->strings, false);
	while (srchUnvstd(isVisited))
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