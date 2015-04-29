#include "extcode.h"
#pragma pack(push)
#pragma pack(1)

#ifdef __cplusplus
extern "C" {
#endif

/*!
 * Get32bitInteger
 */
int32_t __cdecl Get32bitInteger(void);
/*!
 * Set32bitInteger
 */
void __cdecl Set32bitInteger(int32_t inI32);
/*!
 * Set32bitIntegerArray
 */
void __cdecl Set32bitIntegerArray(int32_t inI32Array[], int32_t len);
/*!
 * Get32bitIntegerArray
 */
void __cdecl Get32bitIntegerArray(int32_t out32biIntegerArray[], 
	int32_t *len);
/*!
 * GetError
 */
int32_t __cdecl GetError(void);

MgErr __cdecl LVDLLStatus(char *errStr, int errStrLen, void *module);

#ifdef __cplusplus
} // extern "C"
#endif

#pragma pack(pop)

