/*
~ vector
~ string
! ctrl + k + c - закомментировать
! ctrl + k + u - откоммментировать
*/

/* Header files

создаем заголовочный, в нем код.
пишем инклюд.

создаем цпп с таким же именем как и заголовочный.
в заголовочном не мешает страж включения.
в цпп подключаем заголовочный
*/
#include "testIncludeFactorial.h"

/* Структуры.*/
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
	number2->re = 5; // (*number2).re  вообще это только если есть поля

	number2->im = 6;
	/*
	new - выделяет память на куче
	??...
	*/
}


/* Файлы */
#include <stdio.h>

void main2()
{
	FILE *file = fopen("test.txt", "r"); 
	//r - read
	//w = write
	//a - append
	//r+ - чтение и запись с сохранением
	//w+ - то же самое, но грохает содержимое
	//a+ - 

	if (!file) //если nullptr ?? в общем -  если не нашелся файл.
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
		//?? заклинание "%[^\n]" позволяет не считывать пробелы как конец строки. (вместо "%s")
		//если fscanf не смог прочитать ничего, то возвращает -1.
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
	//удалим память
	for (int i1 = 0; i1 < linesRead; ++i1)
	{
		delete[] data[i1];
	}
	//закроем файл
	fclose(file);
}

//теперь через C++ API (stream)
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
		string buffer; //int buffer = 0; поток сам позаботится о том чтобы считать именно то что нам нужно.
		//getline(file, buffer); //считать строку целиком.
		file >> buffer;
		data.push_back(buffer);
	}

	file.close();

	for (string const &line : data)
		//обойти все зн-я из контейнера дата последовательно присваивая в лайн.
		//конст лайн - чтобы нельзя было менять значения контейнера. КОНСТ.
	{
		cout << line << endl;
	}
}