#pragma once
#include<string>
#include "Detail.h"
#include "Baseboard.h"

class CuttingAlgorithm
{
public:
	CuttingAlgorithm() = default;

	void GreedyCutting(
		Detail& detail,
		Baseboard& baseboard,
		int& refuse);

	int SimpleCutting(
		Detail& detailTypeOne, 
		Detail& detailTypeTwo,
		Baseboard& baseboard,
		int& refuse);
	
private:

};

