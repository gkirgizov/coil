#include <iostream>
#include <string>

using namespace std;

int naiveSearch(const string &text, const string &substring)
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
	return -1;
}

unsigned int hashFunction(const string &substring, char prevSymbol = 0, bool isPrevExist = true, unsigned int prevHash = 0, unsigned int primeFundament = 11)
{
	unsigned int hash = prevHash;
	if (!isPrevExist)
	{
		unsigned int subIndex = substring.size() - 1;
		for (unsigned int i = 0; i < substring.size(); ++i)
		{
			hash += substring[i] * static_cast<int>(pow(primeFundament, subIndex));
			--subIndex;
		}
	}
	else
	{
		unsigned int lastIndex = substring.size() - 1;
		hash -= prevSymbol * static_cast<int>(pow(primeFundament, lastIndex));
		hash *= primeFundament;
		hash += substring[lastIndex];
	}
	return hash;
}

int rabinKarp(const string &text, const string &substring)
{
	unsigned int n = text.size();
	unsigned int m = substring.size();

	unsigned int hashSub = hashFunction(substring, 0, false);
	string textSubstring = text.substr(0, m);
	unsigned int hashTextSub = hashFunction(textSubstring, 0, false);

	unsigned int i = 0;
	while (true)
	{
		if (hashTextSub == hashSub)
		{
			if (textSubstring.compare(substring) == 0)
			{
				return i;
			}
		}
		++i;
		if (i > n - m)
		{
			break;
		}
		textSubstring = text.substr(i, m);
		hashTextSub = hashFunction(textSubstring, text[i - 1], true, hashTextSub);
	}
	return -1;
}