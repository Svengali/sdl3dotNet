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

using SDL3;

namespace Create_Window;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        SDL.SetLogPriorities(SDL.LogPriority.Trace);

        var init = SDL.CreateWindowAndRenderer("SDL3 Create Window", 800, 600, 0, out var window, out var renderer);

        if (!init)
        {
            if (window == IntPtr.Zero)
                Console.WriteLine($"Window could not be created! SDL Error: {SDL.GetError()}");
            
            if (renderer == IntPtr.Zero) 
                Console.WriteLine($"Renderer could not be created! SDL Error: {SDL.GetError()}");
            
            return;
        }

        var rect1 = new SDL.Rect()
        {
            X = 0, Y = 0, H = 100, W = 100
        };

        var rect2 = new SDL.Rect()
        {
            X = 200, H = 100, W = 100, Y = 200
        };

        var hasIntersection = SDL.HasRectIntersection(rect1, rect2);

        SDL.SetRenderDrawColor(renderer, 100, 149, 237, 0);
        
        var loop = true;
        
        while (loop)
        {
            
            while (SDL.PollEvent(out var e))
            {
                if (e.Type == SDL.EventType.Quit)
                {
                    loop = false;
                }
            }

            SDL.RenderClear(renderer);
            SDL.RenderPresent(renderer);
        }

        SDL.DestroyRenderer(renderer);
        SDL.DestroyWindow(window);
        
        SDL.Quit();
    }
}