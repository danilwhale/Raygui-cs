using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace RayGui_cs;

public readonly struct Utf8StringArray : IDisposable
{
    public readonly unsafe sbyte** Handle;
    public readonly nuint Count;
    
    public unsafe Utf8StringArray(string[] array)
    {
        Count = (nuint)array.Length;
        Handle = (sbyte**)NativeMemory.Alloc(Count, (uint)sizeof(nint));

        for (nuint i = 0; i < Count; i++)
        {
            Handle[i] = (sbyte*)Marshal.StringToCoTaskMemUTF8(array[i]);
        }
    }

    public unsafe Utf8StringArray(sbyte** handle, nuint count)
    {
        Handle = handle;
        Count = count;
    }

    public unsafe string[] ToArray()
    {
        var arr = new string[Count];
        
        for (nuint i = 0; i < Count; i++)
        {
            arr[i] = Marshal.PtrToStringUTF8((IntPtr)Handle[i]) ?? string.Empty;
        }

        return arr;
    }

    public unsafe void Dispose()
    {
        for (nuint i = 0; i < Count; i++)
        {
            Marshal.FreeCoTaskMem((IntPtr)Handle[i]);
        }
        
        NativeMemory.Free(Handle);
    }

    public static unsafe implicit operator sbyte**(Utf8StringArray array) => array.Handle;
}