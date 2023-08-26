#include "CuttingAlgorithm.h"

void CuttingAlgorithm::GreedyCutting(
	Detail& detail,
	Baseboard& baseboard,
	int& refuse)
{
	int dCount = detail.GetCount();
	int dLength = detail.GetLength();
	int totalLength = 0;
	while (dCount != 0)
	{
		while (totalLength + dLength < 3000 && dCount != 0)
		{
			--dCount;
			totalLength += dLength;
		}
		baseboard.SetCount(baseboard.GetCount() + 1);
		refuse += baseboard.GetLength() - totalLength;
		totalLength = 0;
	}
}

int CuttingAlgorithm::SimpleCutting(
	Detail& dTypeOne, 
	Detail& dTypeTwo, 
	Baseboard& baseboard,
	int& refuse)
{
	int	allLengthTypeOne{};
	int	allLengthTypeTwo{};
	int	allLength		{};
	int	countBaseboard	{};

	allLengthTypeOne = dTypeOne.GetCount() * dTypeOne.GetLength();	// вычисляем общую длину всех первых деталей
	allLengthTypeTwo = dTypeTwo.GetCount() * dTypeTwo.GetLength();	// вычисляем общую длину всех вторых деталей
	allLength = allLengthTypeTwo + allLengthTypeOne;				// общая длина

	countBaseboard = allLength / baseboard.GetLength();				// количество плинтусов
	refuse = baseboard.GetLength() - (allLength -					// подсчет итогового отхода
			(countBaseboard * baseboard.GetLength()));				
	
	if (allLength % baseboard.GetLength() != 0) 
		countBaseboard += 1;
	
	return countBaseboard;
}
