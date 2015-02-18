#include <cstdlib>
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include "task2.h"

using namespace std;

///////task1

//Перевод числа в прямой код.
void toStraight(int inputNumber, vector<bool> &outputBitRepresentation, int digits)
{
	//переводим число в двоичную систему счисления. итог читается с конца массива
	int temp2 = abs(inputNumber);
	for (temp2; temp2 > 1; temp2 >>= 1)
	{
		int temp1 = temp2;
		temp2 >>= 1;
		temp2 <<= 1;
		outputBitRepresentation.push_back(temp1 - temp2);
	}
	outputBitRepresentation.push_back(temp2);
	
	//заполняем оставшиеся пустые разряды нулями
	const int sizeOfUselessArray = digits - outputBitRepresentation.size();
	bool *uselessArray = new bool[sizeOfUselessArray];
	for (int i1 = 0; i1 < sizeOfUselessArray; ++i1)
	{
		uselessArray[i1] = false;
	}
	outputBitRepresentation.insert(outputBitRepresentation.end(), uselessArray, uselessArray + sizeOfUselessArray);
	
	if (inputNumber < 0)
	{
		outputBitRepresentation[digits - 1] = true;
	}
	delete[] uselessArray;
}

//Перевод числа в дополнительный код.
void toComplement(int inputNumber, vector<bool> &outputBitRepresentation, int digits)
{
	toStraight(inputNumber, outputBitRepresentation, digits);
	if (outputBitRepresentation[digits - 1]) //если число отрицательное
	{
		//инвертируем
		for (int i1 = 0; i1 < digits - 1; ++i1)
		{
			outputBitRepresentation[i1] = !outputBitRepresentation[i1];
		}
		//прибавляем единицу
		int i2 = 0;
		for (i2; outputBitRepresentation[i2]; ++i2)
		{
			outputBitRepresentation[i2] = !outputBitRepresentation[i2];
		}
		outputBitRepresentation[i2] = !outputBitRepresentation[i2];
	}
}

//Вычисление суммы двух чисел в дополнительном коде.
void sumOfComplements(vector<bool> bit1, vector<bool> bit2, vector<bool> &outputBit)
{
	const int digits = bit1.size();
	outputBit.resize(digits);

	bool *isOverflow = new bool[digits + 1];
	isOverflow[0] = false;
	for (int i1 = 0; i1 < digits; ++i1)
	{
		if (bit1[i1] && bit2[i1])
		{
			outputBit[i1] = false;
			isOverflow[i1 + 1] = true;
		}
		else
		{
			outputBit[i1] = bit1[i1] + bit2[i1];
			isOverflow[i1 + 1] = false;
		}

		if (isOverflow[i1])
		{
			if (outputBit[i1] && i1 != digits - 1)
			{
				isOverflow[i1 + 1] = true;
			}
			outputBit[i1] = !outputBit[i1];
		}
	}
	delete[] isOverflow;
}

//Перевод числа в дополнительном коде в десятичное представление.
int complementToDecimal(vector<bool> inputBit)
{
	int outputDecimal = 0;
	const int digits = inputBit.size();
	for (int i1 = 0; i1 < digits - 1; ++i1)
	{
		if (inputBit[digits - 1])
		{
			inputBit[i1] = !inputBit[i1];
		}
		outputDecimal += (inputBit[i1] << i1);
	}
	if (inputBit[digits - 1])
	{
		outputDecimal = -(outputDecimal + 1);
	}
	return outputDecimal;
}

void task1()
{
	setlocale(LC_ALL, "Russian");

	int digits = 0;
	cout << "Введите число двоичных разрядов: ";
	cin >> digits;
	cout << endl;

	int number1;
	vector<bool> bit1;
	cout << "Введите первое число: ";
	cin >> number1;
	toComplement(number1, bit1, digits);
	cout << "Дополнительный код числа " << number1 << ": ";
	for (int i1 = digits; i1 > 0; --i1)
	{
		cout << bit1[i1 - 1];
	}
	cout << endl << endl;

	int number2;
	vector<bool> bit2;
	cout << "Введите второе число: ";
	cin >> number2;
	toComplement(number2, bit2, digits);
	cout << "Дополнительный код числа " << number2 << ": ";
	for (int i2 = digits; i2 > 0; --i2)
	{
		cout << bit2[i2 - 1];
	}
	cout << endl << endl;
	
	vector<bool> sumOfBits;
	sumOfComplements(bit1, bit2, sumOfBits);
	cout << "Сумма этих чисел в дополнительном коде: ";
	for (int i1 = digits; i1 > 0; --i1)
	{
		cout << sumOfBits[i1 - 1];
	}
	cout << endl << endl;

	cout << "Сумма этих чисел в десятичном представлении: " << complementToDecimal(sumOfBits) << endl;
}

//Search of the most frequent element in the file.
int fileSearch(string filePath)
{
	//filePath = "task2File.txt"
	ifstream inputFile(filePath, ios::in);
	if (inputFile.is_open())
	{
		int sizeOfOutputArray = 0;
		vector<int> outputArray;
		while (!inputFile.eof())
		{
			int buffer = 0;
			inputFile >> buffer;
			outputArray.push_back(buffer);
			++sizeOfOutputArray;
		}
		inputFile.close();
		return search(outputArray, sizeOfOutputArray);
	}
	else
	{
		cout << "Input file not found." << endl;
		return 0;
	}
}


//Counting of nonempty strings in the file.
int task3()
{
	ifstream inputFile("task3File.txt", ios::in);
	if (inputFile.is_open())
	{
		int numberOfNonemptyStrings = 0;
		while (!inputFile.eof())
		{
			string buffer;
			getline(inputFile, buffer);

			//inputFile.operator>>.getline(buffer);
			//inputFile >> buffer;
			if (!buffer.empty())
			{
				for (char const &symbol : buffer)
				{
					if (symbol != ' ' || symbol != '\t')
					{
						++numberOfNonemptyStrings;
						break;
					}
				}
			}
		}
		//cout << "Number of nonempty strings in the file: " << endl;
		return numberOfNonemptyStrings;
	}
	else
	{
		cout << "Input file not found." << endl;
		return 0;
	}
}

void main()
{
	cout << task3() << endl;
}