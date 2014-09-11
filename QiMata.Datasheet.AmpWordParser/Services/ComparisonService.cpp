#include <stdafx.h>
#include "ComparisonService.hpp"

using namespace QiMata::Datasheet::AmpWordParser::Models;
using namespace QiMata::Datasheet::AmpWordParser::Services;

std::vector<StringSectionMatch> ComparisonService::ComapreStringSections(FlattenedDatasheet datasheet)
{
	std::vector<StringSectionMatch> matches(datasheet.FlattenedSections.size() * datasheet.FlattenedSections[0].StringSections.size());
	
	for (auto& section : datasheet.FlattenedSections)
	{

		//TODO: make parallel
		for (auto& x : section.StringSections)
		{
			//TODO: make parallel
			for (auto& y : section.StringSections)
			{
				if (x.Id != y.Id)
				{
					if (x.StringHash == y.StringHash && x.StringLength == y.StringLength)
					{
						matches.push_back(StringSectionMatch{ x, y });
					}
				}
			}
		}
	}

	return matches;
}