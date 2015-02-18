#include <stdio.h>
#include <iostream>
#include <stdlib.h>
#include <time.h>

using namespace std;

//task 1
int fibRecursive(int number)
{
	if (number > 2)
	{
		return fibRecursive(number - 1) + fibRecursive(number - 2);
	}
	else if (number > 0)
	{
		return 1;
	}
	else
	{
		return 0;
	}
}
/* test
in
40
out
102334155

in
0
out
0

in
1
out
1
*/

int fibIterate(int number)
{//вычисляет верно до 46 числа.
	if (number >= 1)
	{
		int fibPrevious = 1;
		int fibLast = 1;
		for (int i = 3; i <= number; ++i)
		{
			int fibTemp = fibLast;
			fibLast += fibPrevious;
			fibPrevious = fibTemp;
		}
		return fibLast;
	}
	else
	{
		return 0;
	}
}
/* test
in
40
out
102334155

in
0
out
0

in
1
out
1
*/

//task2
int powStraight(int base, int power)
{//Возведение в неотрицательную целую степень.
	if (power >= 0)
	{
		int powResult = 1;
		for (int i = 0; i < power; ++i)
		{
			powResult *= base;
		}
		return powResult;
	}
	else
	{
		return 0;
	}
}
/* test
in
2, 10
out
1024

in
-2, 11
out
-2048

in
69, 0
out
1

in
2, -1
out
0
*/

int powRecursive(int base, int power)
{//Возведение в неотрицательную целую степень.
	if (power >= 0)
	{
		if (power == 0)
		{
			return 1;
		}
		else if (power == 1)
		{
			return base;
		}
		else if (power == 2)
		{
			return base * base;
		}
		else if (power % 2 == 0)
		{
			return powRecursive(powRecursive(base, power / 2), 2);
		} else if (power % 2 == 1)
		{
			return powRecursive(powRecursive(base, (power - 1) / 2), 2) * base;
		}
	}
	return 0;
}
/* test
in
2, 13
out
8192

in
-2, 13
out
-8192

in
69, 0
out
1

in
2, -1
out
0
*/

//task3
void sortBubble(int inputArray[], int sizeOfInputArray)
{
	for (int i1 = 0; i1 < sizeOfInputArray; ++i1)
	{
		for (int i2 = i1 + 1; i2 < sizeOfInputArray; ++i2)
		{
			if (inputArray[i2] < inputArray[i1])
			{
				int temp = inputArray[i2];
				inputArray[i2] = inputArray[i1];
				inputArray[i1] = temp;
			}
		}
	}
}
/* test
in
{ 3, 2, 0, 4, 5, 1 }, 6
out
{ 0, 1, 2, 3, 4, 5 }

in
{ 0 }, 1
out
{ 0 }
*/

//алгоритм сортировки подсчетом для неотрицательных чисел.
void sortCount(unsigned int inputArray[], int sizeOfInputArray)
{
	unsigned int maxElementOfInputArray = 0;
	for (int i1 = 0; i1 < sizeOfInputArray; ++i1)
	{
		if (inputArray[i1] > maxElementOfInputArray)
		{
			maxElementOfInputArray = inputArray[i1];
		}
	}

	unsigned int *helpArray = new unsigned int[maxElementOfInputArray + 1];
	for (unsigned int i1 = 0; i1 <= maxElementOfInputArray; ++i1)
	{
		helpArray[i1] = 0;
	}

	for (int i1 = 0; i1 < sizeOfInputArray; ++i1)
	{
		++helpArray[inputArray[i1]];
	}

	int iOfInputArray = 0;
	for (unsigned int i1 = 0; i1 <= maxElementOfInputArray; ++i1)
	{
		for (unsigned int i2 = 1; i2 <= helpArray[i1]; ++i2)
		{
			inputArray[iOfInputArray] = i1;
			++iOfInputArray;
		}
	}
	delete[] helpArray;
}
/* test
in
{ 3, 1, 2, 2, 1000, 1000 }, 6
out
{ 1, 2, 2, 3, 1000, 1000 }

in
{ 0 }, 1
out
{ 0 }
*/

//task4
void task4()
{
	srand(time(nullptr));
	const int sizeOfArray = 10;
	int randomArray[sizeOfArray] = { 0 };
	for (int i1 = 0; i1 < sizeOfArray; ++i1)
	{
		randomArray[i1] = rand() % (sizeOfArray * sizeOfArray);
	}
	/* проверка
	for (int i = 0; i < sizeOfArray; ++i)
		printf("%d\n", randomArray[i]);
	*/
	int indexOfFirst = 0;
	int indexOfBigger = sizeOfArray - 1;
	for (int i1 = 1; i1 <= indexOfBigger; ++i1) //проверяем ли лишний раз посл. элемент? < или <= ?
	{
		/*
		если элемент меньше, то меняем его с эталоном(первым), сдвигая эталон вправо.
		если элемент больше эталона, то меняем этот элемент с каким-то из хвоста.
		итерацию в таком случае не производим, а на следующем шаге цикла проверяем 
		эталон с переставленным из хвоста элементом
		*/
		if (randomArray[i1] < randomArray[indexOfFirst])
		{
			int temp = randomArray[indexOfFirst];
			randomArray[indexOfFirst] = randomArray[i1];
			randomArray[i1] = temp;
			++indexOfFirst; //сдвиг эталона.
		}
		//выходит, что неменьшие элементы потом перескакиваются. исправляем это недоразумение.
		else
		//бОльшие элементы кидаем в конец, меняя с теми, что были там.
		{
			int temp = randomArray[i1];
			randomArray[i1] = randomArray[indexOfBigger];
			randomArray[indexOfBigger] = temp;
			--indexOfBigger; //сдвиг хвостового индекса обмена.
			--i1;			 //отмена итерации.
		}
	}
	/* проверка
	for (int i = 0; i < sizeOfArray; ++i)
		printf("%d\n", randomArray[i]);
	printf("\n");
	*/
}
/* test
in
	{ 3, 1, 2, 4, 5, 0 }
out
	{ 1, 2, 0, 3, 5, 4 }	
*/

int main()
{	
	return 0;
}