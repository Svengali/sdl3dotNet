﻿#region License
/* SDL3# - C# Wrapper for SDL3
 *
 * Copyright (c) 2024 Eduard Gushchin.
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
 *
 * Eduard "edwardgushchin" Gushchin <eduardgushchin@yandex.ru>
 *
 */
#endregion

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3;

public static partial class SDL
{
    /// <summary>
    /// Information about the version of SDL in use.
    /// </summary>
    /// <remarks>
    /// Represents the library's version as three levels: major revision (increments with massive changes,
    /// additions, and enhancements), minor revision (increments with backwards-compatible changes to the
    /// major revision), and patchlevel (increments with fixes to the minor revision).
    /// </remarks>
    /// <seealso cref="GetVersion"/>
    [StructLayout(LayoutKind.Sequential)]
    public struct Version
    {
        public byte Major;
        public byte Minor;
        public byte Patch;
        
        public static bool operator ==(Version v1, Version v2)
        {
            return v1.Major == v2.Major && v1.Minor == v2.Minor && v1.Patch == v2.Patch;
        }
        
        public static bool operator !=(Version v1, Version v2)
        {
            return !(v1 == v2);
        }
        
        public override bool Equals(object? obj)
        {
            if (obj is not Version version) return false;
            return this == version;
        }
        
        public override int GetHashCode()
        {
            return HashCode.Combine(Major, Minor, Patch);
        }

        public override string ToString()
        {
            return $"{Major}.{Minor}.{Patch}";
        }
    }
    
    
    /// <summary>
    /// Wrapper version compatible with SDL3 version.
    /// </summary>
    /// <remarks>
    /// Ideally, the version of the connected SDL3 and this wrapper should match
    /// </remarks>
    public static readonly Version WrapperVersion = new()
    {
        Major = 3,
        Minor = 1,
        Patch = 2
    };


    [LibraryImport(SDLLibrary)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr SDL_GetRevision();
    /// <summary>
    /// Get the code revision of SDL that is linked against your program.
    /// </summary>
    /// <returns>Returns an arbitrary string, uniquely identifying the exact revision of the SDL
    /// library in use.</returns>
    /// <remarks>
    /// <para>This value is the revision of the code you are linked with and may be different from the code you are
    /// compiling with, which is found in the constant SDL_REVISION.</para>
    /// <para>The revision is arbitrary string (a hash value) uniquely identifying the exact revision of the
    /// SDL library in use, and is only useful in comparing against other revisions. It is NOT an
    /// incrementing number.</para>
    /// <para>If SDL wasn't built from a git repository with the appropriate tools,
    /// this will return an empty string.</para>
    /// <para>You shouldn't use this function for anything but logging it for debugging purposes.
    /// The string is not intended to be reliable in any way.</para>
    /// <para>The returned string follows the <see cref="GetStringRule"/>.</para>
    /// </remarks>
    public static string? GetRevision()
    {
        return UTF8_ToManaged(SDL_GetRevision());
    }
    
    
    [LibraryImport(SDLLibrary)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial int SDL_GetVersion();

    /// <summary>
    /// Get the version of SDL that is linked against your program.
    /// </summary>
    /// <returns>Returns the version of the linked library.</returns>
    /// <remarks>This function may be called safely at any time, even before <see cref="Init"/>.</remarks>
    /// <seealso cref="Version"/>
    public static Version GetVersion()
    {
        var version = SDL_GetVersion();
        return new Version
        {
            Major = (byte)VersionNumMajor(version),
            Minor = (byte)VersionNumMinor(version),
            Patch = (byte)VersionNumMicro(version)
        };
    }

    private static int VersionNumMajor(int version) => version / 1000000;
    
    private static int VersionNumMinor(int version) => version / 1000 % 1000;
    
    private static int VersionNumMicro(int version) => version % 1000;
    
    

}