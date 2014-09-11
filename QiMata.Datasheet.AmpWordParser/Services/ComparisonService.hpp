#ifndef __QIMATA__DATASHEET__AMPWORDPARSER__SERVICES__COMPARISONSERVICE__H__
#define __QIMATA__DATASHEET__AMPWORDPARSER__SERVICES__COMPARISONSERVICE__H__

#include <vector>

#include "../Models/FlattenedDatasheet.hpp"

namespace QiMata
{
	namespace Datasheet
	{
		namespace AmpWordParser
		{
			namespace Services
			{
				class ComparisonService
				{
				public:
					std::vector<Models::StringSectionMatch> ComapreStringSections(Models::FlattenedDatasheet datasheet);
				};
			}
		}
	}
}

#endif //__QIMATA__DATASHEET__AMPWORDPARSER__SERVICES__COMPARISONSERVICE__H__