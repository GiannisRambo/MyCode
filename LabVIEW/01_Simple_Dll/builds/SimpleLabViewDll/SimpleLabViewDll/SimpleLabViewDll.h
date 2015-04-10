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

MgErr __cdecl LVDLLStatus(char *errStr, int errStrLen, void *module);

#ifdef __cplusplus
} // extern "C"
#endif

#pragma pack(pop)

