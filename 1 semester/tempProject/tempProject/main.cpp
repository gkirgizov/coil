#include <iostream>
#include <fstream>
#include <vector>
#include "RKsearch.h"

using namespace std;

void main()
{
	ofstream of;
	of.open("kronecker_out.txt", ios::out);
	vector<int> y1 = { 1, 1, 1, 7, 17, 17 };
	vector<int> y2 = { 1, -4, -4, -4, -1, 4 };
	vector<int> y3 = { 9, 1, 9, -3, 3, 3 };
	vector<int> y4 = { 1, 1, 1, 1, -1, -1 };
	
	//vector<int> tmp;
	for (int i = 0; i < 6; ++i)
	{
		int sum1 = (-10 * y1[i] + 24 * y2[i] -15 * y3[i] + y4[i]) / 120;
		int sum2 = (10 * y1[i] - 16 * y2[i] + 5 * y3[i] + y4[i]) / 40;
		int sum3 = (20 * y1[i] -96 * y2[i] + 75 * y3[i] + y4[i]) /60;
		of << sum1 << " " << sum2 << " " << sum3 << " " << y3[i] << endl;
	}
	cout << "end" << endl;

//
	//for (const int &n1 : y1)
	//	for (const int &n2 : y2)
	//		for (const int &n3 : y3)
	//			for (const int &n4 : y4)
	//				if ((n1 == 1 && (n4 == 1 || n4 == 619)) || (n1 == -1 && (n4 == -1 || n4 == -619)) ||
	//					(n1 == 7 && (n4 == 1 || n4 == 619)) || (n1 == -7 && (n4 == -1 || n4 == -619)) ||
	//					(n1 == 17 && (n4 == -1 || n4 == -619)) || (n1 == -17 && (n4 == 1 || n4 == 619)) ||
	//					(n1 == 119 && (n4 == -1 || n4 == -619)) || (n1 == -119 && (n4 == 1 || n4 == 619)) ||
	//					(n2 == 2) || (n2 == -2) ||
	//					(n2 == 1 && (n4 == 1 || n4 == -619)) || (n2 == -1 && (n4 == -1 || n4 == 619)) ||
	//					(n2 == 4 && (n4 == -1 || n4 == 619)) || (n2 == -4 && (n4 == 1 || n4 == -619)) || 
	//					(n3 == 1 && (n4 == 1 || n4 == 619)) || (n3 == -1 && (n4 == -1 || n4 == -619)) ||
	//					(n3 == 3 && (n4 == -1 || n4 == 619)) ||	(n3 == -3 && (n4 == 1 || n4 == -619)) ||
	//					(n3 == 9 && (n4 == -1 || n4 == -619)) || (n3 == -9 && (n4 == 1 || n4 == 619)))
	//				{
	//					continue;
	//				}
	//				else
	//				{
	//					int tmpsum = -10 * n1 + 24 * n2 - 15 * n3 + n4;
	//					if (tmpsum % 120 == 0)
	//					{
	//						of << tmpsum << " = ";
	//						of << n1 << " " << n2 << " " << n3 << " " << n4 << endl;
	//					}
	//				}


}