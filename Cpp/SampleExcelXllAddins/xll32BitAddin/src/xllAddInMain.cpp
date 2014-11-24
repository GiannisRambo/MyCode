

#include <windows.h>
#include <xlcall.h>
#include <xllAddInMain.h>

#ifdef __cplusplus
extern "C"
{
#endif


BOOL __stdcall xlAutoOpen(void)
{
	static XLOPER12 xDLL;
	Excel12 ( xlGetName, &xDLL, 0 );

	Excel12 ( xlFree, 0, 1, (LPXLOPER) &xDLL );

    return 1;
}

// Called when Excel closes XLL
BOOL __stdcall xlAutoClose(void)
{
	return 1;
}

__declspec(dllexport) LPXLOPER12 WINAPI xlAutoRegister(LPXLOPER12 pxName)
{
	return NULL;
}

// Called when user activates the XLL from the Add-In Manager
__declspec(dllexport) int WINAPI xlAutoAdd(void)
{
	return 1;
}

// Called when user deactivates XLL from the Add-In Manager
__declspec(dllexport) int WINAPI xlAutoRemove(void)
{
	return 1;
}
// Called by Excel just after an XLL worksheet function returns an XLOPER12 with a flag set
// that tells it there is memory that the XLL still needs to release
// Good for returning dynamically allocated arrays, strings and external references
// to worksheet without memory leaks
__declspec(dllexport) void WINAPI xlAutoFree(LPXLOPER12 px)
{
	int free_me=0;
}

// Support for descriptive information about the add-in(s)
// You can add a new customized title for the user, but
// unfortunately, only an add-in written in Microsoft Visual Basic
// can add a description string.
__declspec(dllexport) LPXLOPER12 WINAPI xlAddInManagerInfo ( LPXLOPER12 xAction ) {

	static XLOPER12 xInfo, xIntAction;

	XLOPER12 xlInt;
	xlInt.xltype = xltypeInt;
	xlInt.val.w;
	Excel12 ( xlCoerce, &xIntAction, 2, xAction, xlInt );

	if ( xIntAction.val.w == 1) {
		xInfo.xltype = xltypeStr;
		xInfo.val.str = L"\10xll32BitAddin";
	} else {
		xInfo.xltype = xltypeErr;
		xInfo.val.err = xlerrValue;
	}

	return (LPXLOPER12) &xInfo;
}

LPXLOPER12 WINAPI FSExecuteNumber(int funcNumber, 
				LPXLOPER12 v0, LPXLOPER12 v1, LPXLOPER12 v2, LPXLOPER12 v3, LPXLOPER12 v4,
				LPXLOPER12 v5, LPXLOPER12 v6, LPXLOPER12 v7, LPXLOPER12 v8, LPXLOPER12 v9, LPXLOPER12 v10,
				LPXLOPER12 v11, LPXLOPER12 v12, LPXLOPER12 v13, LPXLOPER12 v14, LPXLOPER12 v15, LPXLOPER12 v16,
				LPXLOPER12 v17, LPXLOPER12 v18, LPXLOPER12 v19, LPXLOPER12 v20, LPXLOPER12 v21, LPXLOPER12 v22,
				LPXLOPER12 v23, LPXLOPER12 v24, LPXLOPER12 v25, LPXLOPER12 v26, LPXLOPER12 v27, LPXLOPER12 v28)
{
	LPXLOPER12 xOpers[] = {v0, v1, v2, v3, v4, v5, v6, v7, v8, v9,
						 v10, v11, v12, v13, v14, v15, v16, v17, v18, v19,
						 v20, v21, v22, v23, v24, v25, v26, v27, v28};
	LPXLOPER12 xRes = new XLOPER12;
	/*
	if (funcNumber <= all_functions.size()) {
		FUNC_INFO* fInfo = all_functions.at(funcNumber-1);
		void *func_ptr = GetProcAddress ( hCalypso2Excel, fInfo->dllFuncName );
		bool allParametersPresent = true;
		for ( int i=0; i < fInfo->numParams; i++ ) {
			if ( xOpers[i]->xltype == xltypeMissing ) {
				allParametersPresent = false;
				XLUtil::MakeString(xRes, "Missing Parameter(s)");
				return xRes;
				break;
			}
		}
		xRes = call_function ( func_ptr, fInfo->numParams, xOpers );
	} else {
		XLUtil::MakeString(xRes, "Invalid Function");
	}
*/
	return xRes;
}

#define DECLARE_EXCEL_FUNCTION(number) \
__declspec(dllexport) LPXLOPER12 WINAPI FS##number (LPXLOPER12 v0, LPXLOPER12 v1, LPXLOPER12 v2 \
	,LPXLOPER12 v3, LPXLOPER12 v4, LPXLOPER12 v5, LPXLOPER12 v6, LPXLOPER12 v7, LPXLOPER12 v8 \
	,LPXLOPER12 v9, LPXLOPER12 v10, LPXLOPER12 v11, LPXLOPER12 v12, LPXLOPER12 v13, LPXLOPER12 v14, LPXLOPER12 v15, LPXLOPER12 v16 \
	,LPXLOPER12 v17, LPXLOPER12 v18, LPXLOPER12 v19, LPXLOPER12 v20, LPXLOPER12 v21, LPXLOPER12 v22, LPXLOPER12 v23, LPXLOPER12 v24, LPXLOPER12 v25 \
	,LPXLOPER12 v26, LPXLOPER12 v27, LPXLOPER12 v28) \
{ \
	return FSExecuteNumber(number, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28); \
} 

DECLARE_EXCEL_FUNCTION(0)
DECLARE_EXCEL_FUNCTION(1)
DECLARE_EXCEL_FUNCTION(2)
DECLARE_EXCEL_FUNCTION(3)


#ifdef __cplusplus
}
#endif