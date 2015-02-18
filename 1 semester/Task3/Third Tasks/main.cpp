#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <time.h>
#include <vector>
#include <iostream>

using namespace std;

//task1
void sortInsert(vector<int> &inputArray, int beginOfInputArray, int endOfInputArray)
{
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

int basicElementSearch(vector<int> &inputArray, int beginOfInputArray, int endOfInputArray)
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

bool isArraySorted(vector<int> &inputArray, int beginOfInputArray, int endOfInputArray)
{
	for (int i1 = beginOfInputArray; i1 < endOfInputArray; ++i1)
	{
		if (inputArray[i1] > inputArray[i1 + 1])
		{
			return false;
		}
	}
	return true;
}

void sortQuick(vector<int> &inputArray, int beginOfInputArray, int endOfInputArray)
{
	if (!isArraySorted(inputArray, beginOfInputArray, endOfInputArray))
	{
		if (endOfInputArray - beginOfInputArray + 1 <= 10)
		{
			sortInsert(inputArray, beginOfInputArray, endOfInputArray);
		} else
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

/* task2
1 - генерация массива n[]
2 - быстрая сортировка массива n[] (n*log(n))
3 - бинарный поиск k в n[] (?)
*/
bool binarySearch(vector<int> &inputArray, int beginOfInputArray, int endOfInputArray, int searchingObject)
{
	const int sizeOfInputArray = endOfInputArray - beginOfInputArray + 1;
	const int controlIndex = sizeOfInputArray / 2 + beginOfInputArray;
	if (sizeOfInputArray > 2)
	{
		if (searchingObject > inputArray[controlIndex])
		{
			binarySearch(inputArray, controlIndex + 1, endOfInputArray, searchingObject);
		} else
		{
			binarySearch(inputArray, beginOfInputArray, controlIndex, searchingObject);
		}
	} else if (searchingObject == inputArray[endOfInputArray] || searchingObject == inputArray[beginOfInputArray])
	{
		return true;
	} else
	{
		return false;
	}
}

void task2(const int sizeOfArray, int numberOfSearchingNumbers)
{
	srand(time(nullptr));
	vector<int> randomArray;
	for (int i1 = 0; i1 < sizeOfArray; ++i1)
	{
		randomArray.push_back(rand() * rand());
		//Outputting the array for user.
		printf("%d element: %d\n", i1 + 1, randomArray[i1]);
	}
	
	sortQuick(randomArray, 0, sizeOfArray - 1);
	
	for (int i1 = 0; i1 < numberOfSearchingNumbers; ++i1)
	{
		int searchingNumber = rand() * rand();
		bool isInArray = binarySearch(randomArray, 0, sizeOfArray - 1, searchingNumber);
		//Outputting the random number and the answer for user.
		printf("Is number %d in array? (0-no/1-yes): %d\n", searchingNumber, isInArray);
	}
}

/* task3
1 - быстрая сортировка (n*log(n))
2 - одноразовый просмотр массива (n)
*/
int task3(vector<int> &inputArray)
{
	sortQuick(inputArray, 0, inputArray.size() - 1);

	int frequency = 1;
	int maxFrequency = 1;
	int mostFrequentElement = inputArray[0];
	for (unsigned int i = 1; i < inputArray.size(); ++i)
	{
		if (inputArray[i] == inputArray[i - 1])
		{
			++frequency;
		}
		else
		{
			frequency = 1;
		}
		if (frequency > maxFrequency)
		{
			mostFrequentElement = inputArray[i - 1];
			maxFrequency = frequency;
		}
	}
	return mostFrequentElement;
}
/* test
in
{ 2, 2, 0, 4, 4, 1, 5, 5, 0, 0 }, 10
out
0

in
{ 69 }, 1
out
69
*/

int main()
{	
	//task2(1300, 100);
	vector<int> v = { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
	//cout << task3(v) << endl;
	sortQuick(v, 0, v.size() - 1);
	return 0;
}