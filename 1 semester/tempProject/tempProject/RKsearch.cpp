#include <iostream>
#include <string>

using namespace std;

int naiveSearch(string &text, string &substring)
{
	int n = text.size();
	int m = substring.size();
	for (int i = 0; i < n - m + 1; ++i)
		for (int j = 0; j < m; ++j)
		{
			if (text[i + j] != substring[j])
			{
				break;
			}
			return i;
		}
	return -1; //Not Found
}

int hashFunction(string &substring)
{
	return 1;
}

int rabinKarp(string &text, string &substring)
{
	int n = text.size();
	int m = substring.size();

	int hashSub = hashFunction(substring);
	string textSubstring = text.substr(0, m);
	int hashTextSub = hashFunction(textSubstring);

	for (int i = 0; i < n - m + 1; ++i)
		if (hashTextSub == hashSub)
		{
			textSubstring = text.substr(i, m);
			if (textSubstring.compare(substring) == 0)
			{
				return i;
			}
			int hashText = hashFunction(text.substr(0, m));
		}
	return -1; //Not Found
}