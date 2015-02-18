#include "myDict.h"
#include <iostream>
#include <fstream>
#include <string>

using namespace std;

struct DictElement
{
	string name;
	string phone;
	DictElement *next = nullptr;
};

struct Dict
{
	DictElement *head = nullptr;
	DictElement *tail = nullptr;
};

Dict* initDict()
{
	return new Dict;
}

int getSize(Dict *dict)
{
	int size = 0;
	DictElement *cursor = dict->head;
	for (; cursor != nullptr; ++size)
	{
		cursor = cursor->next;
	}
	return size;
}

void addElement(Dict *dict, const string &addedName, const string &addedPhone)
{
	DictElement *addedElement = new DictElement;
	addedElement->name = addedName;
	addedElement->phone = addedPhone;
	if (dict->head != nullptr && dict->tail != nullptr)
	{
		dict->tail->next = addedElement;
		dict->tail = addedElement;
	}
	else
	{
		dict->head = addedElement;
		dict->tail = addedElement;
		//addedElement->next = dict->tail;
	}
}

void deleteElement(Dict *dict, int indexOfElement)
{
	if (indexOfElement < getSize(dict))
	{
		DictElement *cursor = dict->head;
		if (indexOfElement == 0)
		{
			if (dict->tail == dict->head)
			{
				dict->tail = nullptr;
			}
			dict->head = dict->head->next;
			delete cursor;
		}
		else
		{
			for (int n = 1; n < indexOfElement; ++n)
			{
				cursor = cursor->next;
			}
			DictElement *tempElement = cursor->next->next;
			delete cursor->next;
			cursor->next = tempElement;
		}
	}
}

string getHead(Dict *dict, int key)
{
	if (key)
	{
		return dict->head->name;
	}
	else
	{
		return dict->head->phone;
	}
}

void printDict(Dict *dict)
{
	DictElement *cursor = dict->head;
	while (cursor != nullptr)
	{
		cout << cursor->name << " - " << cursor->phone << endl;
		cursor = cursor->next;
	}
}

void printDictToFile(Dict *dict, const string &filePath)
{
	ofstream outputFile;
	outputFile.open(filePath, ios::out);
	DictElement *cursor = dict->head;
	while (cursor != nullptr)
	{
		outputFile << cursor->name << " - " << cursor->phone << endl;
		cursor = cursor->next;
	}
	outputFile.close();
}

void deleteDict(Dict *dict)
{
	while (dict->head != nullptr)
	{
		DictElement *tempElement = dict->head;
		dict->head = dict->head->next;
		delete tempElement;
	}
}

//Разделителем имени и телефона в строке является дефис '-'; в одной строке одна запись.
void readDict(Dict *dict, const string &inputFilePath)
{
	ifstream file(inputFilePath, ios::in);
	if (file.is_open())
	{
		while (!file.eof())
		{
			string name;
			string phone;
			string buffer;
			getline(file, buffer);
		
			if (buffer.find('-') != -1)
			{
				unsigned int index = 0;
				for (index; buffer[index] != '-'; ++index)
				{
					name.push_back(buffer[index]);
				}
				for (++index; buffer[index] == ' '; ++index);
				for (index; index < buffer.size(); ++index)
				{
					phone.push_back(buffer[index]);
				}
				//Удаление лишних пробелов.
				while (name[name.size() - 1] == ' ')
				{
					name.pop_back();
				}
				addElement(dict, name, phone);
			}
		}
	}
	file.close();
}


//MERGE_SORT
string upperCase(const string &inputString)
{
	string outputString = inputString;
	for (unsigned int n = 0; n < outputString.size(); ++n)
	{
		outputString[n] = toupper(outputString[n]);
	}
	return outputString;
}

Dict* merge(Dict *dictHalf1, Dict *dictHalf2, bool key)
{
	Dict *resultDict = initDict();
	while (getSize(dictHalf1) > 0 && getSize(dictHalf2) > 0)
	{
		if (upperCase(getHead(dictHalf1, key)).compare(upperCase(getHead(dictHalf2, key))) <= 0)
		{
			if (key)
			{
				addElement(resultDict, getHead(dictHalf1, key), getHead(dictHalf1, !key));
			}
			else
			{
				addElement(resultDict, getHead(dictHalf1, !key), getHead(dictHalf1, key));
			}
			deleteElement(dictHalf1, 0);
		}
		else
		{
			if (key)
			{
				addElement(resultDict, getHead(dictHalf2, key), getHead(dictHalf2, !key));
			}
			else
			{
				addElement(resultDict, getHead(dictHalf2, !key), getHead(dictHalf2, key));
			}
			deleteElement(dictHalf2, 0);
		}
	}
	while (getSize(dictHalf1) > 0)
	{
		if (key)
		{
			addElement(resultDict, getHead(dictHalf1, key), getHead(dictHalf1, !key));
		}
		else
		{
			addElement(resultDict, getHead(dictHalf1, !key), getHead(dictHalf1, key));
		}
		deleteElement(dictHalf1, 0);
	}
	while (getSize(dictHalf2) > 0)
	{
		if (key)
		{
			addElement(resultDict, getHead(dictHalf2, key), getHead(dictHalf2, !key));
		}
		else
		{
			addElement(resultDict, getHead(dictHalf2, !key), getHead(dictHalf2, key));
		}
		deleteElement(dictHalf2, 0);
	}
	return resultDict;
}

//Key = true: sort by name; key = false: sort by phone.
Dict* sortMerge(Dict *dict, bool key)
{
	const int size = getSize(dict);
	if (size <= 1)
	{
		return dict;
	}
	else
	{
		Dict *dictHalf1 = initDict();
		Dict *dictHalf2 = initDict();
		Dict *resultDict = initDict();
		DictElement *cursor = dict->head;
		for (int n = 0; n < size / 2; ++n)
		{
			addElement(dictHalf1, cursor->name, cursor->phone);
			cursor = cursor->next;
		}
		//cursor = cursor->next;
		for (int n = size / 2; n < size; ++n)
		{
			addElement(dictHalf2, cursor->name, cursor->phone);
			cursor = cursor->next;
		}
		dictHalf1 = sortMerge(dictHalf1, key);
		dictHalf2 = sortMerge(dictHalf2, key);
		resultDict = merge(dictHalf1, dictHalf2, key);
		deleteDict(dictHalf1);
		deleteDict(dictHalf2);
		return resultDict;
	}
}

//Легко реализовать и одну универсальную функцию поиска, передавая ключ поиска доп.параметром.
string findPhoneByName(Dict *dict, const string &name)
{
	string result = "";
	DictElement *cursor = dict->head;
	while ((cursor->name.compare(name) != 0 && cursor->name.size() != name.size()) 
			&& cursor->next != nullptr)
	{
		cursor = cursor->next;
	}
	if (cursor != nullptr)
	{
		result = cursor->phone;
		cursor = nullptr;
	}
	return result;
}

string findNameByPhone(Dict *dict, const string &phone)
{
	string result = "";
	DictElement *cursor = dict->head;
	while ((cursor->phone.compare(phone) != 0 && cursor->phone.size() != phone.size()) 
			&& cursor->next != nullptr)
	{
		cursor = cursor->next;
	}
	if (cursor != nullptr)
	{
		result = cursor->name;
		cursor = nullptr;
	}
	return result;
}