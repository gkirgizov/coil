#include "task2.h"
#include <string>
#include <vector>
#include <iostream>
#include <fstream>

using namespace std;

//begin of quick sort
void sortInsert(vector<int> &inputArray, int beginOfInputArray, int endOfInputArray)
{
	const int sizeOfInputArray = endOfInputArray - beginOfInputArray + 1;
	for (int i1 = beginOfInputArray; i1 <= endOfInputArray; ++i1)
	{
		for (int i2 = i1; i2 > 0 && inputArray[i2 - 1] > inputArray[i2]; --i2)
		{
			int temp = inputArray[i2];
			inputArray[i2] = inputArray[i2 - 1];
			inputArray[i2 - 1] = temp;
		}
	}
}

int basicElementSearch(vector<int> inputArray, int beginOfInputArray, int endOfInputArray)
{
	int minElement = inputArray[beginOfInputArray];
	int maxElement = inputArray[beginOfInputArray];

	for (int i1 = beginOfInputArray; i1 < endOfInputArray; ++i1)
	{
		if (minElement > inputArray[i1 + 1])
		{
			minElement = inputArray[i1 + 1];
		}
		if (maxElement < inputArray[i1 + 1])
		{
			maxElement = inputArray[i1 + 1];
		}
	}

	int basicElement = inputArray[beginOfInputArray];
	for (int i1 = beginOfInputArray; i1 <= endOfInputArray; ++i1)
	{
		if (inputArray[i1] < maxElement && inputArray[i1] > minElement)
		{
			basicElement = inputArray[i1];
			break;
		}
	}
	return basicElement;
}

bool isInArrayAreOnlyEqualElemenets(vector<int> inputArray, int beginOfInputArray, int endOfInputArray)
{
	for (int i1 = beginOfInputArray; i1 < endOfInputArray; ++i1)
	{
		if (inputArray[i1] != inputArray[i1 + 1])
		{
			return false;
		}
	}
	return true;
}

void sortQuick(vector<int> &inputArray, int beginOfInputArray, int endOfInputArray)
{
	if (endOfInputArray - beginOfInputArray + 1 <= 10)
	{
		sortInsert(inputArray, beginOfInputArray, endOfInputArray);
	} 
	else
	{
		if (!isInArrayAreOnlyEqualElemenets(inputArray, beginOfInputArray, endOfInputArray))
		{
			int basicElement = basicElementSearch(inputArray, beginOfInputArray, endOfInputArray);

			int lborder = beginOfInputArray;
			int rborder = endOfInputArray;

			while (lborder < rborder)
			{
				while (inputArray[lborder] < basicElement)
				{
					++lborder;
				}
				while (inputArray[rborder] >= basicElement)
				{
					--rborder;
				}
				if (lborder < rborder)

				{
					int temp = inputArray[lborder];
					inputArray[lborder] = inputArray[rborder];
					inputArray[rborder] = temp;
				}
			}

			if (rborder > 0)
			{
				sortQuick(inputArray, beginOfInputArray, rborder);
			}
			if (lborder > 0)
			{
				sortQuick(inputArray, lborder, endOfInputArray);
			}
		}
	}
}
//end of quick sort

int search(vector<int> &inputArray, int sizeOfInputArray)
{
	sortQuick(inputArray, 0, sizeOfInputArray - 1);

	int frequency = 1;
	int maxFrequency = 1;
	int mostFrequentElement = inputArray[0];
	for (int i = 0; i < sizeOfInputArray - 1; ++i)
	{
		if (inputArray[i + 1] == inputArray[i])
		{
			++frequency;
		} else
		{
			if (frequency > maxFrequency)
			{
				mostFrequentElement = inputArray[i];
				maxFrequency = frequency;
			}
			frequency = 1;
		}
	}
	//проверка на случай если искомый элемент является последним по порядку
	if (frequency > maxFrequency)
	{
		mostFrequentElement = inputArray[sizeOfInputArray - 1];
		maxFrequency = frequency;
	}
	return mostFrequentElement;
}

/* test
in
//without file.
out
Input file not found
0

in
6 6 6 6 6 6 6 6 6 6 6 1
out
6

in
69 96
out
69

in
5 5 5 5 5 4 4 4 4 3 3 3 2 2 1
out
5
*/