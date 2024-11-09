﻿#region License
/* Copyright (c) 2024 Eduard Gushchin.
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. If you use this software in a
 * product, an acknowledgment in the product documentation would be
 * appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not be
 * misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source distribution.
 */
#endregion

namespace SDL3;

public static partial class SDL
{
    public enum Colorspace : uint
    { 
        Unknown = 0,
        
        /// <summary>
        /// sRGB is a gamma corrected colorspace, and the default colorspace for SDL rendering and 8-bit RGB surfaces.
        /// Equivalent to DXGI_COLOR_SPACE_RGB_FULL_G22_NONE_P709
        /// </summary>
        SRGB = 0x120005a0u,
        
        /// <summary>
        /// This is a linear colorspace and the default colorspace for floating point surfaces.
        /// On Windows this is the scRGB colorspace, and on Apple platforms this is
        /// kCGColorSpaceExtendedLinearSRGB for EDR content.
        /// Equivalent to DXGI_COLOR_SPACE_RGB_FULL_G10_NONE_P709
        /// </summary>
        SRGBLinear = 0x12000500u,

        /// <summary>
        /// HDR10 is a non-linear HDR colorspace and the default colorspace for 10-bit surfaces
        /// Equivalent to DXGI_COLOR_SPACE_RGB_FULL_G2084_NONE_P2020
        /// </summary>
        HDR10 = 0x12002600u,

        /// <summary>
        /// Equivalent to DXGI_COLOR_SPACE_YCBCR_FULL_G22_NONE_P709_X601
        /// </summary>
        JPEG = 0x220004c6u,

        /// <summary>
        /// Equivalent to DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P601
        /// </summary>
        BT601Limited = 0x211018c6u,

        /// <summary>
        /// Equivalent to DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P601
        /// </summary>
        BT601Full = 0x221018c6u,

        /// <summary>
        /// Equivalent to DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P709
        /// </summary>
        BT709Limited = 0x21100421u,
        
        /// <summary>
        /// Equivalent to DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P709
        /// </summary>
        BT709Full = 0x22100421u,
        
        /// <summary>
        /// Equivalent to DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P2020
        /// </summary>
        BT2020Limited = 0x21102609u,

        /// <summary>
        /// Equivalent to DXGI_COLOR_SPACE_YCBCR_FULL_G22_LEFT_P2020
        /// </summary>
        BT2020Full = 0x22102609u 
    }
}