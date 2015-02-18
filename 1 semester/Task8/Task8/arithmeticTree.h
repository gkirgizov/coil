#pragma once

#include <string>

// Build arithmetical tree. Elements of the tree are digits or arithmetical signs.
Tree* arithmeticTree(const std::string &filePath);

int calcTree(Tree *arithmeticPlant);