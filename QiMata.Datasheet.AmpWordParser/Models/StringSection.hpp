#ifndef __QIMATA__DATASHEET__AMPWORDPARSER__MODELS__STRINGSECTION__H__
#define __QIMATA__DATASHEET__AMPWORDPARSER__MODELS__STRINGSECTION__H__

#include <Windows.h>
#include <string>

namespace QiMata
{
	namespace Datasheet
	{
		namespace AmpWordParser
		{
			namespace Models
			{
				struct StringSection
				{
					_GUID Id;

					int StringHash;

					int StringLength;

					int DatasheetId;

					int SectionId;

					std::string String;
				};

				struct StringSectionMatch
				{
					StringSection Section1;
					StringSection Section2;
				};
			}
		}
	}
}


#endif //__QIMATA__DATASHEET__AMPWORDPARSER__MODELS__STRINGSECTION__H__