#pragma once
#include<string>

class Baseboard
{
public:
	Baseboard() = default;

	long GetLength() { return baseboardLength; };
	void SetLength(long value) { baseboardLength = std::move(value); };

	long GetCount() { return baseboardCount; };
	void SetCount(long value) { baseboardCount = std::move(value); };

private:
	long baseboardLength {};	//	Длина плинтуса в мм
	int baseboardCount {};	//	Количество плинтусов 
};

