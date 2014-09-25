#include <stdafx.h>
#include <vector>

#include "Models\FlattenedDatasheet.hpp"

using namespace QiMata::Datasheet::AmpWordParser;


Models::ComparingDatasheetWrapper wrapper;

extern "C" __declspec(dllexport) void _stdcall CreateObjects()
{
	wrapper = Models::ComparingDatasheetWrapper();
}

extern "C" __declspec(dllexport) void _stdcall SetDatasheetIds(int datasheet1Id, int datasheet2Id)
{
	wrapper.SetDatasheetIds(datasheet1Id, datasheet2Id);
}

extern "C" __declspec(dllexport) void _stdcall AddSection(int datasheetId, int sectionId, const char * sectionText, int stringHash, int stringLength, _GUID id)
{
	wrapper.AddSection(datasheetId, sectionId, std::string(sectionText), stringHash, stringLength,id);
}

extern "C" __declspec(dllexport) void _stdcall ComapreStringSections()
{
	std::vector<Models::StringSectionMatch> matches;

	for (auto& section : wrapper.Datasheet1().FlattenedSections)
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
						matches.push_back(Models::StringSectionMatch{ x, y });
					}
				}
			}
		}
	}
}