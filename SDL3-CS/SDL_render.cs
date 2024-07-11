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

using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace SDL3;

public static partial class SDL
{
    [LibraryImport(SDLLibrary)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe partial Render SDL_CreateRenderer(Window window,  byte* name);
    
    /// <summary>
    /// Create a 2D rendering context for a window.
    /// </summary>
    /// <param name="window">the window where rendering is displayed.</param>
    /// <param name="name">
    /// the name of the rendering driver to initialize,
    /// or <see cref="IntPtr.Zero"/> to initialize the first one supporting the requested flags.
    /// </param>
    /// <returns>
    /// Returns a valid rendering context or <see cref="IntPtr.Zero"/> if there was an error;
    /// call <see cref="GetError"/> for more information.
    /// </returns>
    /// <remarks>
    /// <para>If you want a specific renderer, you can specify its name here. A list of available renderers can be
    /// obtained by calling <see cref="GetRenderDriver"/> multiple times, with indices from 0 to
    /// <see cref="GetNumRenderDrivers"/>-1. If you don't need a specific renderer, specify <see cref="nint.Zero"/>
    /// and SDL will attempt to choose the best option for you, based on what is available on the user's system.</para>
    /// <para>By default the rendering size matches the window size in pixels, but you can call
    /// <see cref="SetRenderLogicalPresentation"/> to change the content size and scaling options.</para>
    /// </remarks>
    /// <seealso cref="CreateRendererWithProperties"/>
    /// <seealso cref="CreateSoftwareRenderer"/>
    /// <seealso cref="DestroyRenderer"/>
    /// <seealso cref="GetNumRenderDrivers"/>
    /// <seealso cref="GetRenderDriver"/>
    /// <seealso cref="GetRendererName"/>
    public static unsafe Render CreateRenderer(Window window, string? name)
    {
        var utf8TitleBufSize = UTF8Size(name);
        var utf8Title = stackalloc byte[utf8TitleBufSize];
        return SDL_CreateRenderer(window, UTF8Encode(name, utf8Title, utf8TitleBufSize));
    }


    [LibraryImport(SDLLibrary)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void SDL_SetRenderDrawColor(Render renderer, byte r, byte g, byte b, byte a);
    
    /// <summary>
    /// Set the color used for drawing operations.
    /// </summary>
    /// <param name="renderer">the rendering context.</param>
    /// <param name="r">the red value used to draw on the rendering target.</param>
    /// <param name="g">the green value used to draw on the rendering target.</param>
    /// <param name="b">the blue value used to draw on the rendering target.</param>
    /// <param name="a">
    /// the alpha value used to draw on the rendering target;
    /// Use <see cref="SetRenderDrawBlendMode"/> to specify how the alpha channel is used.
    /// </param>
    /// <remarks>Set the color for drawing or filling rectangles, lines, and points,
    /// and for <see cref="RenderClear"/>.</remarks>
    /// <seealso cref="GetRenderDrawColor"/>
    /// <seealso cref="SetRenderDrawColorFloat"/>
    public static void SetRenderDrawColor(Render renderer, byte r, byte g, byte b, byte a) =>
        SDL_SetRenderDrawColor(renderer, r, g, b, a);
    
    
    [LibraryImport(SDLLibrary)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial int SDL_RenderClear(Render renderer);
    
    /// <summary>
    /// Clear the current rendering target with the drawing color.
    /// </summary>
    /// <param name="renderer">the rendering context.</param>
    /// <returns>
    /// Returns 0 on success or a negative error code on failure;
    /// call <see cref="GetError"/> for more information.
    /// </returns>
    /// <remarks>
    /// This function clears the entire rendering target, ignoring the viewport and the clip rectangle.
    /// Note, that clearing will also set/fill all pixels of the rendering target to current renderer draw color,
    /// so make sure to invoke <see cref="SetRenderDrawColor"/> when needed.
    /// </remarks>
    /// <seealso cref="SetRenderDrawColor"/>
    public static int RenderClear(Render renderer) => SDL_RenderClear(renderer);
    
    
    [LibraryImport(SDLLibrary)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial int SDL_RenderPresent(Render renderer);
    
    /// <summary>
    /// Update the screen with any rendering performed since the previous call.
    /// </summary>
    /// <param name="renderer">the rendering context.</param>
    /// <returns>
    /// Returns 0 on success or a negative error code on failure;
    /// call <see cref="GetError"/> for more information.
    /// </returns>
    /// <remarks>
    /// <para>SDL's rendering functions operate on a backbuffer; that is, calling a rendering function such as
    /// <see cref="RenderLine"/> does not directly put a line on the screen, but rather updates the backbuffer.
    /// As such, you compose your entire scene and present the composed backbuffer to the screen as a
    /// complete picture.</para>
    /// <para>Therefore, when using SDL's rendering API, one does all drawing intended for the frame, and then
    /// calls this function once per frame to present the final drawing to the user.</para>
    /// <para>The backbuffer should be considered invalidated after each present; do not assume that previous
    /// contents will exist between frames. You are strongly encouraged to call <see cref="RenderClear"/> to initialize
    /// the backbuffer before starting each new frame's drawing, even if you plan to overwrite every pixel.</para>
    /// <para>You may only call this function on the main thread.</para>
    /// </remarks>
    /// <seealso cref="RenderClear"/>
    /// <seealso cref="RenderLine"/>
    /// <seealso cref="RenderLines"/>
    /// <seealso cref="RenderPoint"/>
    /// <seealso cref="RenderPoints"/>
    /// <seealso cref="RenderRect"/>
    /// <seealso cref="RenderRects"/>
    /// <seealso cref="RenderFillRect"/>
    /// <seealso cref="RenderFillRects"/>
    /// <seealso cref="SetRenderDrawBlendMode"/>
    /// <seealso cref="SetRenderDrawColor"/>
    public static int RenderPresent(Render renderer) => SDL_RenderPresent(renderer);
    
    
    [LibraryImport(SDLLibrary)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void SDL_DestroyRenderer(Render renderer);
    
    /// <summary>
    /// Destroy the rendering context for a window and free all associated textures
    /// </summary>
    /// <remarks>
    /// This should be called before destroying the associated window.
    /// </remarks>
    /// <param name="renderer">the rendering context.</param>
    /// <seealso cref="CreateRenderer"/>
    public static void DestroyRenderer(Render renderer) => SDL_DestroyRenderer(renderer);


    [LibraryImport(SDLLibrary)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe partial IntPtr SDL_GetRenderDriver(int index);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public static string? GetRenderDriver(int index) => UTF8ToManaged(SDL_GetRenderDriver(index));
    
    
    [LibraryImport(SDLLibrary)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial int SDL_GetNumRenderDrivers();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static int GetNumRenderDrivers() => SDL_GetNumRenderDrivers();
}