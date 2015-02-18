#pragma once

#include <string>

struct DictElement;

struct Dict;

Dict* initDict();

int getSize(Dict *dict);

void addElement(Dict *dict, const std::string &addedName, const std::string &addedPhone);

void deleteElement(Dict *dict, int indexOfElement);

//std::string getHead(Dict *dict, int key);

void printDict(Dict *dict);

void printDictToFile(Dict *dict, const std::string &filePath);

void deleteDict(Dict *dict);

//������������ ����� � �������� � ������ �������� ����� '-'; � ����� ������ ���� ������.
void readDict(Dict *dict, const std::string &inputFilePath);

//Key = true: sort by name; key = false: sort by phone.
Dict* sortMerge(Dict *dict, bool key);

//����� ����������� � ���� ������������� ������� ������, ��������� ���� ������ ���.����������.
std::string findPhoneByName(Dict *dict, const std::string &name);

std::string findNameByPhone(Dict *dict, const std::string &phone);