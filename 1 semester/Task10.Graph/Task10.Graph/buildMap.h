#pragma once

#include <vector>
#include <string>

struct State
{
	unsigned int capital = NULL;
	std::vector<unsigned int> cities;
};

std::vector<State> task(std::string inputFilePath);