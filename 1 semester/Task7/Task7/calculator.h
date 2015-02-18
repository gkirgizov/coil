#pragma once

#include <string>

bool isBracketSequenceValid(std::string const &inputString);

//Calculation of the Reverse Polish notation.
int calcRPN(std::string const &inputString);

//Calculation of the infix notation.
//int calcIN(std::string inputString);

std::string infixNotatonToRPN(std::string const &inputString);