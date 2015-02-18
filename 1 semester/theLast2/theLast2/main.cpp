#include <iostream>
#include <vector>

using namespace std;

vector<int> readNumbers()
{
	vector<int> numbers;
	int sizeOfArray = 0;
	cout << "Enter size of array" << endl;
	cin >> sizeOfArray;
	cout << "Enter the numbers" << endl;
	for (; sizeOfArray > 0; --sizeOfArray)
	{
		int buffer = 0;
		cin >> buffer;
		numbers.push_back(buffer);
	}
	return numbers;
}

int getDigitSum(int number)
{
	int sumOfDigits = 0;
	for (; number > 0; number /= 10)
	{
		sumOfDigits += number % 10;
	}
	return sumOfDigits;
}

vector<int> getNumbersWithMaxSumOfDigits(const vector<int> &numbers)
{
	int maxSumOfDigits = getDigitSum(numbers[0]);
	vector<int> numbersWithMaxSumOfDigits;
	for (const int &number : numbers)
	{
		int sumOfDigits = getDigitSum(number);
		if (sumOfDigits > maxSumOfDigits)
		{
			maxSumOfDigits = sumOfDigits;
			numbersWithMaxSumOfDigits.clear();
			numbersWithMaxSumOfDigits.push_back(number);
		}
		else if (sumOfDigits == maxSumOfDigits)
		{
			numbersWithMaxSumOfDigits.push_back(number);
		}
	}
	return numbersWithMaxSumOfDigits;
}

void main()
{
	for (const int &number : getNumbersWithMaxSumOfDigits(readNumbers()))
	{
		cout << number << " ";
	}
	cout << endl;
}