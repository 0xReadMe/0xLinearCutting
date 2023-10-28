#pragma once
#include <string>
#include "Baseboard.h"
#include <vector>
#include "Detail.h"
#include <iostream>

class ConsoleFrame
{
public:
	ConsoleFrame() = default;

	void FillingFileFrame(int& detailCount, int& bLength, std::string& foutWriteString, std::fstream& fout);

	void EnterFrame(Baseboard& baseboard, std::fstream& fout, std::vector<Detail>& details);
};

