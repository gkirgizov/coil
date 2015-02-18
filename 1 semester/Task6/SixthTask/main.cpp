#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include "myLists.h"
#include "myDict.h"

using namespace std;

//Задание 1. Телефонный справочник. (использует модуль "myDict.h")
void phonebase()
{
	setlocale(LC_ALL, "Russian");
	
	Dict *phonebase = initDict();
	cout << "ТЕЛЕФОННЫЙ СПРАВОЧНИК" << endl << endl;
	cout << "Введите путь к файлу." << endl << "Если файла не существует, введите все, что ваша душа пожелает." << endl;
	string filePath;
	cin.sync();
	getline(cin, filePath);

	//шоб не париться, не входит в конечный ход
	//filePath = "dict.txt";
	
	readDict(phonebase, filePath);
	string switcher;
	while (true)
	{
		cout << "Вам доступны действия: " << endl;
		cout << "0 - выйти" << endl;
		cout << "1 - добавить запись" << endl;
		cout << "2 - найти телефон по имени" << endl;
		cout << "3 - найти имя по телефону" << endl;
		cout << "4 - сохранить текущие данные в файл" << endl;
		cout << "-> ";
		cin.sync();
		cin >> switcher;
		cout << endl;

		if (switcher == "0")
		{
			break;
		}
		else if (switcher == "1")
		{
			cout << "Добавление новой записи." << endl;
			cout << "Введите телефон: ";
			string addedPhone;
			cin.sync();
			getline(cin, addedPhone);
			cout << "Введите имя: ";
			string addedName;
			cin.sync();
			getline(cin, addedName);
			cout << endl;
			addElement(phonebase, addedName, addedPhone);
		}
		else if (switcher == "2")
		{
			cout << "Поиск телефона по имени. Введите имя: ";
			string name;
			cin.sync();
			getline(cin, name);
			string result = findPhoneByName(phonebase, name);
			if (result == "")
			{
				result = "Данные не найдены.";
			}
			cout << endl << "Результат поиска: " << result << endl << endl;
		}
		else if (switcher == "3")
		{
			cout << "Поиск имени по телефону. Введите телефон: ";
			string phone;
			cin.sync();
			getline(cin, phone);
			string result = findNameByPhone(phonebase, phone);
			if (result == "")
			{
				result = "Данные не найдены.";
			}
			cout << endl << "Результат поиска: " << result << endl << endl;
		}
		else if (switcher == "4")
		{
			cout << "Введите путь к файлу." << endl;
			string filePath;
			cin.sync();
			getline(cin, filePath);
			cout << endl;

			//шоб не париться, не входит в конечный ход
			//filePath = "outputDict.txt";

			printDictToFile(phonebase, filePath);
		}
		else
		{
			cout << "Неверный ввод." << endl << endl;
		}
	}
	deleteDict(phonebase);
}

//Задание 2. Интерактивный список. (использует модуль "myLists.h")
void taskTwo()
{
	setlocale(LC_ALL, "Russian");

	List *list = initList();
	string switcher;

	cout << "Под вашим контролем список. Вам дан выбор. " << endl;
	while (true)
	{
		cout << "Ваш выбор: " << endl;
		cout << "0 - выйти" << endl;
		cout << "1 - добавить значение в сортированный список " << endl;
		cout << "2 - удалить значение из списка" << endl;
		cout << "3 - распечатать список" << endl;
		cout << "-> ";
		cin.sync();
		cin >> switcher;
		cout << endl;

		if (switcher == "0")
		{
			break;
		}
		else if (switcher == "1")
		{
			cout << "Введите целочисленное значение для добавление в список: ";
			int addedValue = 0;
			cin.sync();
			cin >> addedValue;
			cout << endl;
			addElement(list, addedValue);
		}
		else if (switcher == "2")
		{
			cout << "Введите значение для удаления из списка: ";
			int deletedValue = 0;
			cin.sync();
			cin >> deletedValue;
			cout << endl;
			deleteElement(list, deletedValue);
		}
		else if (switcher == "3")
		{
			cout << "Список: " << endl;
			printList(list);
			cout << endl;
		}
		else
		{
			cout << "Неверный ввод." << endl << endl;
		}
	}
	deleteList(list);
}

//Задание 3. Иосиф Флавий и воины-самоубийцы. (использует модуль "myLists.h")
int taskThree(int numberOfWarriors, int numberOfEveryKilled)
{
	List *list = initList();
	for (int n1 = 0; n1 < numberOfWarriors; ++n1)
	{
		push(list, n1 + 1);
	}

	for (int n2 = numberOfEveryKilled - 1; getSize(list) > 1; n2 += numberOfEveryKilled - 1)
	{
		deleteElementByIndex(list, n2);
	}

	int warriorOne = getElement(list, 0);
	deleteCycleList(list);
	return warriorOne;
}

//Задание 4*. Перебор перестановок длины n.

void generate(int k, int lengthOfP, vector<int> &permutation)
{
	if (k == lengthOfP)
	{
		for (int i = 0; i < lengthOfP; ++i)
		{
			cout << permutation[i] << " ";
		}
		cout << endl;
	}
	else
	{
		for (int j = k; j < lengthOfP; ++j)
		{
			swap(permutation[k], permutation[j]);
			generate(k + 1, lengthOfP, permutation);
			swap(permutation[k], permutation[j]);
		}
	}
}

void printPermutations(unsigned int lengthOfP)
{
	vector<int> permutation;
	for (unsigned int i = 0; i < lengthOfP; ++i)
	{
		permutation.push_back(i + 1);
	}
	generate(0, lengthOfP, permutation);
}

void main()
{
	//int n = 0;
	//cin >> n;
	//phonebase();

//ПРОВЕРКА sortMerge()
	//Dict *dict = initDict();
	//string path = "dict.txt";
	//readDict(dict, path);
	//cout << "printed:" << endl;
	//printDict(dict);
	//dict = sortMerge(dict, false);
	//cout << "sorted:" << endl;
	//printDict(dict);
	
	//taskTwo();
	//cout << taskThree(20, 7);

	printPermutations(4);
}