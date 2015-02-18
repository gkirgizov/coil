#include <cstdio>
#include <fstream>
#include <iostream>
#include <vector>
#include <string>

using namespace std;

//Is number1 > number2 ? (1 - yes / 0 - no)
bool task1(bool number1[], bool number2[])
{
	int ctrlDigit1 = 0;
	for (int i = 0; !number1[i]; ++i)
	{
		++ctrlDigit1;
	}
	int ctrlDigit2 = 0;
	for (int i = 0; !number2[i]; ++i)
	{
		++ctrlDigit2;
	}

	for (ctrlDigit1; number1[ctrlDigit1] == number2[ctrlDigit2]; ++ctrlDigit1)
	{
		++ctrlDigit2;
	}
	
	cout << number1[ctrlDigit1] << endl;

	if (number1[ctrlDigit1])
	{
		return true;
	} else
	{			
		return false;	
	}
}
/*test
in
{1,0,1}, {1,0,0}
out
1

in
{1,0,0}, {1,1,0}
out
0

in
{0, 1, 0, 0}, {1, 1, 0}
out
0
*/

//Hello. It is bubble sort.
void task2(int inputArray[], int sizeOfInputArray)
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

//Replacing of sequences of repeating elements by one element.
void task3()
{
	ifstream file("test.txt", ios::in);

	vector<string> data;
	
	while (!file.eof())
	{
		string buffer;
		file >> buffer;

		for (unsigned int i1 = 0; i1 < buffer.length(); ++i1)
		{
			for (unsigned int i2 = i1; buffer[i2 + 1] == buffer[i2] && i2 < buffer.length() - 1; ++i2)
			{
				++i1;
			}
			cout << buffer[i1];
		}
		printf("\n");
	}
	file.close();
}
/*test
in
"aaaaaaaaaa
ffffffff
dsfdf
sdssssd"

out
"a
f
dsfdf
sdsd"

in
"aafgbba"

out
"afgba"

in
""
out
""

*/

void main()
{
	bool n1[] = { 1, 0, 0 };
	bool n2[] = { 1, 0, 0 };
	cout << task1(n1, n2) << endl;
}