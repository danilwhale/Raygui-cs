using System.Runtime.InteropServices;

namespace RayGui_cs;

[StructLayout(LayoutKind.Sequential)]
public struct GuiStyleProp
{
    public ushort ControlId;
    public ushort PropertyId;
    public int PropertyValue;
}