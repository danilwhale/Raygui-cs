using Raylib_cs;

namespace RayGui_cs;

public static class Utf8StringArrayUtils
{
    public static Utf8StringArray GetNativeArray(this string[] array)
    {
        return new Utf8StringArray(array);
    }

    public static unsafe string[] GetArray(sbyte** handle, int count)
    {
        using var nativeArray = new Utf8StringArray(handle, (nuint)count);
        var array = nativeArray.ToArray();
        return array;
    }
}