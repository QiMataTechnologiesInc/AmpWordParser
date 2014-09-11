// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the QIMATADATASHEETAMPWORDPARSER_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// QIMATADATASHEETAMPWORDPARSER_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef QIMATADATASHEETAMPWORDPARSER_EXPORTS
#define QIMATADATASHEETAMPWORDPARSER_API __declspec(dllexport)
#else
#define QIMATADATASHEETAMPWORDPARSER_API __declspec(dllimport)
#endif

// This class is exported from the QiMata.Datasheet.AmpWordParser.dll
class QIMATADATASHEETAMPWORDPARSER_API CQiMataDatasheetAmpWordParser {
public:
	CQiMataDatasheetAmpWordParser(void);
	// TODO: add your methods here.
};

extern QIMATADATASHEETAMPWORDPARSER_API int nQiMataDatasheetAmpWordParser;

QIMATADATASHEETAMPWORDPARSER_API int fnQiMataDatasheetAmpWordParser(void);



namespace QiMata
{
	namespace Datasheet
	{
		namespace AmpWordParser
		{
			
		}
	}
}
