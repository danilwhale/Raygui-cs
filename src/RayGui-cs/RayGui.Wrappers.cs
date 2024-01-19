using System.Runtime.InteropServices;
using Raylib_cs;

namespace RayGui_cs;

public static partial class RayGui
{
    public static unsafe ReadOnlySpan<uint> GuiGetIconsAsSpan()
    {
        return new ReadOnlySpan<uint>(GuiGetIcons(), IconsArraySize);
    }
    
    public static unsafe int GuiTabBar(Rectangle bounds, string[] text, ref int active)
    {
        using var nativeArray = text.GetNativeArray();
        return GuiTabBar(bounds, nativeArray, text.Length, ref active);
    }

    public static unsafe int GuiListViewEx(Rectangle bounds, string[] text, ref int scrollIndex, ref int active,
        ref int focus)
    {
        using var nativeArray = text.GetNativeArray();
        return GuiListViewEx(bounds, nativeArray, text.Length, ref scrollIndex, ref active, ref focus);
    }
}