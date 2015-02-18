#include "buildMap.h"
#include "myGraph.h"
#include <iostream>
#include <fstream>
#include <string>
#include <vector>

using namespace std;

void readGraphFromFile(string inputFilePath, Graph *map, vector<unsigned int> &capitals)
{
	ifstream inFile(inputFilePath, ios::in);
	if (inFile.is_open())
	{
		unsigned int citiesCount = 0;
		unsigned int roadsCount = 0;
		inFile >> citiesCount;
		inFile >> roadsCount;
		for (; roadsCount > 0; --roadsCount)
		{
			unsigned int strng = 0;
			unsigned int clmn = 0;
			unsigned int roadLength = 0;
			inFile >> strng;
			inFile >> clmn;
			inFile >> roadLength;
			addLink(map, strng, clmn, roadLength);
		}
		unsigned int capitalsCount = 0;
		inFile >> capitalsCount;
		for (; capitalsCount > 0; --capitalsCount)
		{
			unsigned int buffer = 0;
			inFile >> buffer;
			capitals.push_back(buffer);
		}
		inFile.close();
	}
}

bool isCapital(vector<unsigned int> &capitals, unsigned int city)
{
	for (const unsigned int &capital : capitals)
	{
		if (city == capital)
		{
			return true;
		}
	}
	return false;
}

void citiesDistribution(Graph *map, vector<unsigned int> &capitals, vector<State> &world)
{
	vector<vector<unsigned int>> worldRoads;
	for (const unsigned int &capital : capitals)
	{
		State buffer;
		buffer.capital = capital;
		world.push_back(buffer);

		vector<unsigned int> roadsBuffer;
		dijkstra(map, capital, roadsBuffer);
		worldRoads.push_back(roadsBuffer);
	}

	const unsigned int citiesCount = worldRoads[0].size();
	for (unsigned int city = 0; city < citiesCount; ++city)
	{
		if (!isCapital(capitals, city + 1))
		{
			unsigned int minRoad = UINT_MAX;
			unsigned int nearestCapital = capitals.size();
			for (unsigned int capitalIndex = 0; capitalIndex < capitals.size(); ++capitalIndex)
			{
				if (worldRoads[capitalIndex][city] < minRoad)
				{
					minRoad = worldRoads[capitalIndex][city];
					nearestCapital = capitalIndex;
				}
			}
			world[nearestCapital].cities.push_back(city + 1);
		}
	}
}

void printWorld(vector<State> &world)
{
	for (const State &russia : world)
	{
		cout << "capital: " << endl << russia.capital << endl << "cities:" << endl;
		for (const unsigned int &moscow : russia.cities)
		{
			cout << moscow << endl;
		}
	}
}

vector<State> task(string inputFilePath)
{
	Graph* map = init();
	vector<unsigned int> capitals;
	readGraphFromFile(inputFilePath, map, capitals);
	vector<State> world;
	citiesDistribution(map, capitals, world);
	deleteADT(map);
	printWorld(world);
	return world;
}
