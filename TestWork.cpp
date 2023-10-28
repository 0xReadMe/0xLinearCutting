#include "Baseboard.h"
#include "Detail.h"
#include "CuttingAlgorithm.h"
#include "Utils.h"
#include "ConsoleFrame.h"

int main()
{
	ConsoleFrame		CF				{};		// инициализация класса для работы с консольным вводом-выводом
	Utils				utils			{};
	Baseboard			baseboard		{};		// плинтус
	CuttingAlgorithm	cut				{};		// инициализация класса алгоритмов раскроя
	int					refuse			{};		// отход
	std::vector<Detail> details			{};		// vector деталей
	std::fstream		fStream;

	fStream.open("data.txt", std::ios::trunc | std::ios::out | std::ios::in);
	CF.EnterFrame(baseboard, fStream, details);
	
	while (1)
	{
		baseboard.SetCount(0);
		refuse = 0;
		int choice {};
		std::cout << "Choice an action: \n 1 -> Simple cutting algorithm \n 2 -> Greedy cutting algorithm \n 3 -> Smart cutting algorithm \n 4 -> ReEnter a data for baseboard and details" << "\n";
		std::cout << ">>"; std::cin >> choice;
		switch (choice)
		{
			case 1:
				baseboard.SetCount(cut.SimpleCutting(details, baseboard, refuse));
				std::cout << "\nYou need to buy a " << baseboard.GetCount() << " baseboards. \n";
				std::cout << "Your refuse: " << refuse << "\n\n";
				break;

			case 2:
				for (auto& detail : details) 
				{
					cut.GreedyCutting(detail, baseboard, refuse);
				}
				std::cout << "\nYou need to buy a " << baseboard.GetCount() << " baseboards. \n";
				std::cout << "Your refuse: " << refuse << "\n\n";

			case 3:
				break;

			case 4:
				CF.EnterFrame(baseboard, fStream, details);
				break;

			default:
				break;
		}
	}
}