#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include "myLists.h"
#include "myDict.h"

using namespace std;

//������� 1. ���������� ����������. (���������� ������ "myDict.h")
void phonebase()
{
	setlocale(LC_ALL, "Russian");
	
	Dict *phonebase = initDict();
	cout << "���������� ����������" << endl << endl;
	cout << "������� ���� � �����." << endl << "���� ����� �� ����������, ������� ���, ��� ���� ���� ��������." << endl;
	string filePath;
	cin.sync();
	getline(cin, filePath);

	//��� �� ��������, �� ������ � �������� ���
	//filePath = "dict.txt";
	
	readDict(phonebase, filePath);
	string switcher;
	while (true)
	{
		cout << "��� �������� ��������: " << endl;
		cout << "0 - �����" << endl;
		cout << "1 - �������� ������" << endl;
		cout << "2 - ����� ������� �� �����" << endl;
		cout << "3 - ����� ��� �� ��������" << endl;
		cout << "4 - ��������� ������� ������ � ����" << endl;
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
			cout << "���������� ����� ������." << endl;
			cout << "������� �������: ";
			string addedPhone;
			cin.sync();
			getline(cin, addedPhone);
			cout << "������� ���: ";
			string addedName;
			cin.sync();
			getline(cin, addedName);
			cout << endl;
			addElement(phonebase, addedName, addedPhone);
		}
		else if (switcher == "2")
		{
			cout << "����� �������� �� �����. ������� ���: ";
			string name;
			cin.sync();
			getline(cin, name);
			string result = findPhoneByName(phonebase, name);
			if (result == "")
			{
				result = "������ �� �������.";
			}
			cout << endl << "��������� ������: " << result << endl << endl;
		}
		else if (switcher == "3")
		{
			cout << "����� ����� �� ��������. ������� �������: ";
			string phone;
			cin.sync();
			getline(cin, phone);
			string result = findNameByPhone(phonebase, phone);
			if (result == "")
			{
				result = "������ �� �������.";
			}
			cout << endl << "��������� ������: " << result << endl << endl;
		}
		else if (switcher == "4")
		{
			cout << "������� ���� � �����." << endl;
			string filePath;
			cin.sync();
			getline(cin, filePath);
			cout << endl;

			//��� �� ��������, �� ������ � �������� ���
			//filePath = "outputDict.txt";

			printDictToFile(phonebase, filePath);
		}
		else
		{
			cout << "�������� ����." << endl << endl;
		}
	}
	deleteDict(phonebase);
}

//������� 2. ������������� ������. (���������� ������ "myLists.h")
void taskTwo()
{
	setlocale(LC_ALL, "Russian");

	List *list = initList();
	string switcher;

	cout << "��� ����� ��������� ������. ��� ��� �����. " << endl;
	while (true)
	{
		cout << "��� �����: " << endl;
		cout << "0 - �����" << endl;
		cout << "1 - �������� �������� � ������������� ������ " << endl;
		cout << "2 - ������� �������� �� ������" << endl;
		cout << "3 - ����������� ������" << endl;
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
			cout << "������� ������������� �������� ��� ���������� � ������: ";
			int addedValue = 0;
			cin.sync();
			cin >> addedValue;
			cout << endl;
			addElement(list, addedValue);
		}
		else if (switcher == "2")
		{
			cout << "������� �������� ��� �������� �� ������: ";
			int deletedValue = 0;
			cin.sync();
			cin >> deletedValue;
			cout << endl;
			deleteElement(list, deletedValue);
		}
		else if (switcher == "3")
		{
			cout << "������: " << endl;
			printList(list);
			cout << endl;
		}
		else
		{
			cout << "�������� ����." << endl << endl;
		}
	}
	deleteList(list);
}

//������� 3. ����� ������ � �����-����������. (���������� ������ "myLists.h")
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

//������� 4*. ������� ������������ ����� n.

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

//�������� sortMerge()
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