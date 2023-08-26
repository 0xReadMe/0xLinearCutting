#include "Baseboard.h";
#include "Detail.h";
#include "CuttingAlgorithm.h";
#include <iostream>
#include <vector>
#include <fstream>

void EnterFrame(int& detailCount, Baseboard& baseboard, std::fstream& fout)
{
	int					choice			{};
	int					bLength			{};
	std::string			choice_str		{};
	std::string			foutWriteString	{};

	std::cout << "Select the data input method: \n 1 - console \n 2 - file:"; std::cin >> choice;
	switch (choice)
	{
		case 1:
			std::cout << "Enter a count of details for cutting: "; std::cin >> detailCount;
			std::cout << "Enter a baseboard length:"; std::cin >> bLength;

			break;

		case 2:
			std::cout << "Enter a count of details for cutting: "; std::cin >> detailCount;
			std::cout << "Enter a baseboard length:"; std::cin >> bLength;
			foutWriteString = "Baseboard length >> " + bLength; foutWriteString += ";";
			fout << foutWriteString + "\n";

			for (int i = 0; i <= detailCount; i++) 
			{
				foutWriteString = "Detail " + i; foutWriteString += " count: 0;";
				fout << foutWriteString + "\n";
			}
			for (int i = 0; i <= detailCount; i++)
			{
				foutWriteString = "Detail " + i; foutWriteString += " length: 0;";
				fout << foutWriteString + "\n";
			}

			std::cout << "We create a file in main .exe directory.\nPlease, open it and write data for each detail, and then go back to this windows and enter +: \n>>"; std::cin >> choice_str;
			if (choice_str == "+") 
			{
			
			}
			else 
			{
				std::cout << "You enter incorrect data in console window. \nPlease, start again.";
			}
			break;

		default:
			break;
	}
	

	std::cout << std::endl;
	baseboard.SetLength(bLength);
	
}

int main()
{
	std::fstream fout("data.txt", std::ios::out | std::ios::trunc);

	Baseboard			baseboard		{};		// плинтус
	CuttingAlgorithm	cut				{};		// инициализация класса алгоритмов раскроя
	int					refuse			{};		// отход
	int					detailCount		{};
	std::vector<Detail> details			{};

	
	EnterFrame(detailCount, baseboard, fout);
	
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
				//baseboard.SetCount(cut.SimpleCutting(detailTypeOne, detailTypeTwo, baseboard, refuse));
				std::cout << "\nYou need to buy a " << baseboard.GetCount() << " baseboards. \n";
				std::cout << "Your refuse: " << refuse << "\n\n";
				break;

			case 2:
				//cut.GreedyCutting(detailTypeOne, baseboard, refuse);
				//cut.GreedyCutting(detailTypeTwo, baseboard, refuse);
				std::cout << "\nYou need to buy a " << baseboard.GetCount() << " baseboards. \n";
				std::cout << "Your refuse: " << refuse << "\n\n";

			case 3:
				std::cout << "Not realized!";
				break;

			case 4:
				EnterFrame(detailCount, baseboard, fout);
				break;

			default:
				break;
		}
	}
}




