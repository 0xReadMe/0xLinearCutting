#pragma once
#include<string>

class Detail
{
public:
	Detail() = default;

	long GetLength() { return detailLength; };
	void SetLength(long value) { detailLength = std::move(value); };

	int GetCount() { return detailCount; };
	void SetCount(int value) { detailCount = std::move(value); };

private:
	long detailLength;
	int detailCount;
};

