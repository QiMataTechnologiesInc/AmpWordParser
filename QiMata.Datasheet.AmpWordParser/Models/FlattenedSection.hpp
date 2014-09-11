#ifndef __QIMATA__DATASHEET__AMPWORDPARSER__MODELS__FLATTENEDSECTION__H__
#define __QIMATA__DATASHEET__AMPWORDPARSER__MODELS__FLATTENEDSECTION__H__

#include <vector>

#include "StringSection.hpp"

namespace QiMata
{
	namespace Datasheet
	{
		namespace AmpWordParser
		{
			namespace Models
			{
				struct FlattenedSection
				{
					int DatasheetId;
					int SectionId;
					std::vector<StringSection> StringSections;
				};
			}
		}
	}
}

#endif //__QIMATA__DATASHEET__AMPWORDPARSER__MODELS__FLATTENEDSECTION__H__