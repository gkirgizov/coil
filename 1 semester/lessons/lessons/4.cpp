/*
~ vector
~ string
! ctrl + k + c - ����������������
! ctrl + k + u - �����������������
*/

/* Header files

������� ������������, � ��� ���.
����� ������.

������� ��� � ����� �� ������ ��� � ������������.
� ������������ �� ������ ����� ���������.
� ��� ���������� ������������
*/
#include "testIncludeFactorial.h"

/* ���������.*/
struct ComplexNumber
{
	int re;
	int im;
};

void main()
{
	ComplexNumber number = { 1, 0 };
	number.re = 5;
	number.im = 6;

	int result = factorial(5);

	//now in the stack
	ComplexNumber *number2 = new ComplexNumber();
	number2->re = 5; // (*number2).re  ������ ��� ������ ���� ���� ����

	number2->im = 6;
	/*
	new - �������� ������ �� ����
	??...
	*/
}


/* ����� */
#include <stdio.h>

void main2()
{
	FILE *file = fopen("test.txt", "r"); 
	//r - read
	//w = write
	//a - append
	//r+ - ������ � ������ � �����������
	//w+ - �� �� �����, �� ������� ����������
	//a+ - 

	if (!file) //���� nullptr ?? � ����� -  ���� �� ������� ����.
	{
		printf("File not found");
		return;
	}
	printf("File found");


	char *data[100] = {};
	int linesRead = 0;
	while (!feof(file))
	{
		char *buffer = new char[100];
		int const bytesRead = fscanf(file, "%s", buffer);
		//?? ���������� "%[^\n]" ��������� �� ��������� ������� ��� ����� ������. (������ "%s")
		//���� fscanf �� ���� ��������� ������, �� ���������� -1.
		if (bytesRead <= 0)
		{
			break;
		}

		data[linesRead] = buffer;
		++linesRead;
	}

	for (int i1 = 0; i1 < linesRead; ++i1)
	{
		printf("%s\n", data[i1]);
	}
	//������ ������
	for (int i1 = 0; i1 < linesRead; ++i1)
	{
		delete[] data[i1];
	}
	//������� ����
	fclose(file);
}

//������ ����� C++ API (stream)
#include <fstream>
#include <iostream>
#include <vector>
#include <string>

using namespace std;

void main3()
{
	ifstream file("../test.txt", ios::in); //~ios
	if (!file.is_open())
	{
		cout << "file not found" << endl;
		return;
	}

	vector<string> data; //vector<int>

	while (!file.eof())
	{
		string buffer; //int buffer = 0; ����� ��� ����������� � ��� ����� ������� ������ �� ��� ��� �����.
		//getline(file, buffer); //������� ������ �������.
		file >> buffer;
		data.push_back(buffer);
	}

	file.close();

	for (string const &line : data)
		//������ ��� ��-� �� ���������� ���� ��������������� ���������� � ����.
		//����� ���� - ����� ������ ���� ������ �������� ����������. �����.
	{
		cout << line << endl;
	}
}