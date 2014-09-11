#ifndef __QIMATA__DATASHEET__AMPWORDPARSER__MODELS__FLATTENEDDATASHEET__H__
#define __QIMATA__DATASHEET__AMPWORDPARSER__MODELS__FLATTENEDDATASHEET__H__

#include <vector>


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
			}
		}
	}
}

#endif //__QIMATA__DATASHEET__AMPWORDPARSER__MODELS__FLATTENEDDATASHEET__H__