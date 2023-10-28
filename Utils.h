#pragma once
#include <string>
#include <fstream>

class Utils
{
public:
	Utils() = default;

	void FillStr(std::string& string, std::string text);
	std::string GetDetailCount(std::string& allStrings);
	std::string GetDetailLength(std::string& allStrings);
	auto ReadFile(std::string path) -> std::string;
};