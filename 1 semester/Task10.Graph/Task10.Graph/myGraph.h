#pragma once

typedef unsigned int IntType;

struct Graph;

// Add link or change link's weight.
void addLink(Graph *graph, unsigned int strng, unsigned int clmn, IntType length = 1);

// Delete link.
void deleteLink(Graph *graph, unsigned int strng, unsigned int clmn);

// Initialize graph in adjacency matrix representation.
Graph* init(unsigned int strings = 0, unsigned int columns = 0);

void deleteADT(Graph *graph);

void dijkstra(Graph *graph, unsigned int vertex, std::vector<unsigned int> &lengths);