#include <iostream>
#include <fstream>
#include <sstream>
#include <map>
#include <string>
#include <functional>
#include <ctype.h>
#include <regex>

using namespace std;

string stringToLower(string chars)
{
	for (size_t i = 0; i < chars.length(); i++)
	{
		chars[i] = tolower(chars[i]);
	}
	return chars;
}

int main(int argc, char* argv[])
{
	const int PAIRSPERLINE = 9;

	fstream file;
	if (argc > 2)
	{
		cout << "too many arguments" << endl;
		return -1;
	}
	else if (argc == 2)
	{
		file.open(argv[1]);
		if (!file.good())
		{
			cout << "invalid file name or file not found" << endl;
			return -2;
		}
	}
	else if (argc == 1)
	{
		string fileName;
		do
		{
			cout << "Please enter the name of the file to be read: ";
			cin >> fileName;
			file.open(fileName);
			if (!file.good())
			{
				cout << "invalid file name or file not found" << endl;;
			}
		} while (!file.good());
	}


	string line, word;
	int lineNum = 0, maxWordLength = 0;



	auto funComp = [](const string& left, const string& right)
	{
		string tempLeft = left;
		string tempRight = right;
		tempLeft = stringToLower(tempLeft);
		tempRight = stringToLower(tempRight);
		if (tempLeft != tempRight)
			return tempLeft < tempRight;
		else
		{
			return left < right;
		}
	};
	map<string, map<int, int>, decltype(funComp) > crossRef(funComp);


	while (getline(file, line))
	{
		//use regex to filter out symbols but keep 's and 're and stuff like that

		//if (regex_match(line, "[a-zA-Z][a-zA-Z]* || [a-zA-Z][a-zA-z]*\\'[a-zA-Z]"))
		//{
		//	cout << line;
		//}

		lineNum++;
		istringstream words(line);
		while (words >> word)
		{
			crossRef[word][lineNum] += 1;
			if (word.length() > maxWordLength)
			{
				maxWordLength = word.length();
			}
		}
	}
	for (auto [key, value] : crossRef)
	{
		cout << key;
		for (size_t i = key.length(); i < maxWordLength; i++)
		{
			cout << " ";
		}
		cout << " : ";
		int pairs = 0;
		for (auto [k, v] : crossRef[key])
		{
			cout << k << ":" << v << ", ";//dont print comma if last (k,v) pair in value
			pairs++;
			if (pairs == PAIRSPERLINE)
			{
				pairs = 0;
				cout << endl;
				for (size_t j = 0; j < maxWordLength; j++)
				{
					cout << " ";
				}
				cout << " : ";
			}
		}
		cout << endl;
	}

	return 0;
}