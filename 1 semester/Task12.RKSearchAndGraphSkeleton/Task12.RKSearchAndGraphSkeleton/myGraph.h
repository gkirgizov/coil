#pragma once

#include <vector>

typedef unsigned int IntType;

struct Graph;

// Add edge or change edge's weight. (for non-oriented graph)
void addLink(Graph *graph, unsigned int row, unsigned int column, IntType length = 1);

// Delete edge.
void deleteLink(Graph *graph, unsigned int row, unsigned int column);

// Initialize graph in adjacency matrix representation.
Graph* init(unsigned int strings = 0, unsigned int columns = 0);

void deleteADT(Graph *graph);

// Outputting of graph to the console.
void printGraph(Graph *graph, unsigned int firstVertex = 0);

// Output the graph to the console in adjacency matrix representation.
void printAdjacencyMatrix(Graph *graph);

// Read adjacency matrix from the file.
void readGraphFromFile(const std::string &inputFilePath, Graph *graph);

// Dijkstra's algorythm.
void dijkstra(Graph *graph, unsigned int vertex, std::vector<unsigned int> &lengths);

// Checking graph for cyclic recurrence.
bool isCyclic(Graph *graph, unsigned int firstVertex = 0);

// Build minimal spanning tree for non-directed linked graph.
Graph* minSpanningTree(Graph *graph);