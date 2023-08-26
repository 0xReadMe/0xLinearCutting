#include "Baseboard.h";
#include "Detail.h";
#include "CuttingAlgorithm.h";
#include <iostream>
#include <vector>

void EnterFrame(int& bLength, int& d1Length, int& d1Count, int& d2Length, int& d2Count, Baseboard& baseboard, Detail& dTypeOne, Detail& dTypeTwo)
{
	std::cout << "Enter a count of details for cutting: ";
	std::cout << "Enter a baseboard length:"; std::cin >> bLength;
	std::cout << "Enter a detail length:"; std::cin >> d1Length;
	std::cout << "Enter a detail count:"; std::cin >> d1Count; 
	std::cout << ":"; std::cin >> d1Count;
	std::cout << std::endl;

	baseboard.SetLength(bLength);
	dTypeOne.SetLength(d1Length);
	dTypeOne.SetCount(d1Count);
	dTypeTwo.SetLength(d2Length);
	dTypeTwo.SetCount(d2Count);
}

int main()
{
	Detail				detailTypeOne	{};		// деталь первого типа
	Detail				detailTypeTwo	{};		// деталь второго типа
	Baseboard			baseboard		{};		// плинтус
	int					refuse			{};		// отход
	CuttingAlgorithm	cut				{};		// инициализация класса алгоритмов раскроя
	int					detailCount		{};
	std::vector<Detail> details			{};

	int bLength	{};								//__
	int d1Length{};								//  |
	int d2Length{};								//   > переменные для ввода с консоли и установки значений через setter
 	int d1Count	{};								//  |
	int d2Count	{};								//--
	
	EnterFrame(bLength, d1Length, d2Length, d1Count, d2Count, baseboard, detailTypeOne, detailTypeTwo);
	
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
				baseboard.SetCount(cut.SimpleCutting(detailTypeOne, detailTypeTwo, baseboard, refuse));
				std::cout << "\nYou need to buy a " << baseboard.GetCount() << " baseboards. \n";
				std::cout << "Your refuse: " << refuse << "\n\n";
				break;

			case 2:
				cut.GreedyCutting(detailTypeOne, baseboard, refuse);
				cut.GreedyCutting(detailTypeTwo, baseboard, refuse);
				std::cout << "\nYou need to buy a " << baseboard.GetCount() << " baseboards. \n";
				std::cout << "Your refuse: " << refuse << "\n\n";

			case 3:
				std::cout << "Not realized!";
				break;

			case 4:
				EnterFrame(bLength, d1Length, d2Length, d1Count, d2Count, baseboard, detailTypeOne, detailTypeTwo);
				break;

			default:
				break;
		}
	}
}




