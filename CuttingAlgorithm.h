#pragma once
#include <string>
#include "Detail.h"
#include "Baseboard.h"
#include <vector>

class CuttingAlgorithm
{
public:
	CuttingAlgorithm() = default;

	void GreedyCutting(
		Detail& detail,
		Baseboard& baseboard,
		int& refuse);

	int SimpleCutting(
		std::vector<Detail>& details,
		Baseboard& baseboard,
		int& refuse);
	
private:

};

