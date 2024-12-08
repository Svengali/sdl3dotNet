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
    /// <summary>
    /// <para>Function interface for <see cref="Storage"/>.</para>
    /// <para>Apps that want to supply a custom implementation of <see cref="Storage"/> will fill
    /// in all the functions in this struct, and then pass it to <see cref="OpenStorage"/> to
    /// create a custom <see cref="Storage"/> object.</para>
    /// <para>It is not usually necessary to do this; SDL provides standard
    /// implementations for many things you might expect to do with an <see cref="Storage"/>.</para>
    /// </summary>
    /// <since>This struct is available since SDL 3.0.0.</since>
    public struct StorageInterface
    {
        public UInt32 Version;
        public CloseDelegate Close;
        public ReadyDelegate Ready;
        public EnumerateDelegate Enumerate;
        public InfoDelegate Info;
        public ReadFileDelegate ReadFile;
        public WriteFileDelegate WriteFile;
        public MkdirDelegate Mkir;
        public RemoveDelegate Remove;
        public RenameDelegate Rename;
        public SpaceRemainingDelegate SpaceRemaining;
    }
}