#include "Utils.h"

void Utils::FillStr(std::string& string, std::string text)
{
	string.append(text);
}

auto Utils::ReadFile(std::string path) -> std::string {
	constexpr auto read_size = std::size_t(4096);

	auto stream = std::ifstream(path.data());
	stream.exceptions(std::ios_base::badbit);

	if (not stream)
	{
		throw std::ios_base::failure("file does not exist");
	}

	auto out = std::string();
	auto buf = std::string(read_size, '\0');

	while (stream.read(&buf[0], read_size))
	{
		out.append(buf, 0, stream.gcount());
	}

	out.append(buf, 0, stream.gcount());
	return out;
}

std::string Utils::GetDetailCount(std::string& allStrings)
{
	std::string findString{ ":" };
	std::string findString2{ ";" };
	std::string countDetail{};
	int			firstIndex{};
	int			lastIndex{};

	firstIndex = allStrings.find(findString);
	lastIndex = allStrings.find(findString2);
	countDetail = allStrings.substr(firstIndex + 1, lastIndex - (firstIndex + 1));
	countDetail.erase(remove_if(countDetail.begin(), countDetail.end(), isspace), countDetail.end());

	allStrings.erase(0, lastIndex + 1);
	return countDetail;
}

std::string Utils::GetDetailLength(std::string& allStrings)
{
	std::string findString{ ":" };
	std::string findString2{ ";" };
	int			firstIndex{};
	int			lastIndex{};

	std::string findZone{ "==== LENGTH ZONE ====" };
	std::string lengthDetail{};
	int			zoneIndex{};

	zoneIndex = allStrings.find(findZone);
	zoneIndex += 21;
	firstIndex = allStrings.find(findString, zoneIndex);
	lastIndex = allStrings.find(findString2, zoneIndex);
	lengthDetail = allStrings.substr(firstIndex + 1, lastIndex - (firstIndex + 1));
	lengthDetail.erase(remove_if(lengthDetail.begin(), lengthDetail.end(), isspace), lengthDetail.end());
	allStrings.erase(zoneIndex, lastIndex - zoneIndex + 1);
	return lengthDetail;
}