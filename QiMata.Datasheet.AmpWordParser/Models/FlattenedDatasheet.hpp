#ifndef __QIMATA__DATASHEET__AMPWORDPARSER__MODELS__FLATTENEDDATASHEET__H__
#define __QIMATA__DATASHEET__AMPWORDPARSER__MODELS__FLATTENEDDATASHEET__H__

#include <vector>
#include <algorithm>


#include "FlattenedSection.hpp"

namespace QiMata
{
	namespace Datasheet
	{
		namespace AmpWordParser
		{
			namespace Models
			{
				struct FlattenedDatasheet
				{
					int DataSheetId;
					std::vector<FlattenedSection> FlattenedSections;
				};

				void AddToDatasheet(FlattenedDatasheet& datasheet, int sectionId, std::string& sectionText, int stringHash, int stringLength, _GUID id)
				{
					auto section = std::find_if(datasheet.FlattenedSections.begin(), datasheet.FlattenedSections.end(), [&](FlattenedSection& tempSection){
						return tempSection.SectionId == sectionId;
					});

					if (section != datasheet.FlattenedSections.end()) {
						section->StringSections.push_back({ id, stringHash, stringLength, datasheet.DataSheetId, sectionId, std::move(sectionText) });
					}
					else {
						StringSection newStringSection = { id, stringHash, stringLength, datasheet.DataSheetId, sectionId, std::move(sectionText) };
						datasheet.FlattenedSections.push_back({ datasheet.DataSheetId, sectionId, { newStringSection } });
					}
				}

				class ComparingDatasheetWrapper
				{
				public:
					void SetDatasheetIds(int datasheet1Id, int datasheet2Id)
					{
						_datasheet1.DataSheetId = datasheet1Id;
						_datasheet2.DataSheetId = datasheet2Id;
					}

					void AddSection(int datasheetId, int sectionId, std::string& sectionText, int stringHash, int stringLength, _GUID id)
					{
						if (_datasheet1.DataSheetId == datasheetId)
						{
							AddToDatasheet(_datasheet1,sectionId, sectionText, stringHash, stringLength, id);
						}
						else if (_datasheet2.DataSheetId == datasheetId)
						{
							AddToDatasheet(_datasheet2, sectionId, sectionText, stringHash, stringLength, id);
						}
					}

					FlattenedDatasheet& Datasheet1()
					{
						return _datasheet1;
					}

					FlattenedDatasheet& Datasheet2()
					{
						return _datasheet2;
					}
				private:
					FlattenedDatasheet _datasheet1;
					FlattenedDatasheet _datasheet2;
				};
			}
		}
	}
}

#endif //__QIMATA__DATASHEET__AMPWORDPARSER__MODELS__FLATTENEDDATASHEET__H__