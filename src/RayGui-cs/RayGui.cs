using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Raylib_cs;

[assembly:DisableRuntimeMarshalling]

namespace RayGui_cs;

public static partial class RayGui
{
    public const int VersionMajor = 4;
    public const int VersionMinor = 0;
    public const int VersionPatch = 0;

    public static readonly Version Version = new Version(VersionMajor, VersionMajor, VersionPatch);

    public const string LibraryName = "raygui";

    public const int IconSize = 16;
    public const int MaxIcons = 256;
    public const int MaxNameLength = 32;
    public const int IconDataElements = IconSize * IconSize / 32;

    public const int IconsArraySize = MaxIcons * IconDataElements;

    public const int MaxControls = 16;
    public const int MaxPropsBase = 16;
    public const int MaxPropsExtended = 8;
    
    [LibraryImport(LibraryName)]
    public static partial void GuiEnable();
    
    [LibraryImport(LibraryName)]
    public static partial void GuiDisable();

    [LibraryImport(LibraryName)]
    public static partial void GuiLock();

    [LibraryImport(LibraryName)]
    public static partial void GuiUnlock();

    [LibraryImport(LibraryName)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool GuiIsLocked();

    [LibraryImport(LibraryName)]
    public static partial void GuiSetAlpha(float alpha);

    [LibraryImport(LibraryName)]
    public static partial void GuiSetState(GuiState state);

    [LibraryImport(LibraryName)]
    public static partial GuiState GuiGetState();

    [LibraryImport(LibraryName)]
    public static partial void GuiSetFont(Font font);

    [LibraryImport(LibraryName)]
    public static partial Font GuiGetFont();

    [LibraryImport(LibraryName)]
    public static partial void GuiSetStyle(int control, int property, int value);

    [LibraryImport(LibraryName)]
    public static partial int GuiGetStyle(int control, int property);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial void GuiLoadStyle(string fileName);

    [LibraryImport(LibraryName)]
    public static partial void GuiLoadStyleDefault();

    [LibraryImport(LibraryName)]
    public static partial void GuiEnableTooltip();

    [LibraryImport(LibraryName)]
    public static partial void GuiDisableTooltip();

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial void GuiSetTooltip(string tooltip);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    [return: MarshalAs(UnmanagedType.LPUTF8Str)]
    public static partial string GuiIconText(int iconId, string text);

    [LibraryImport(LibraryName)]
    public static partial void GuiSetIconScale(int scale);

    [LibraryImport(LibraryName)]
    public static unsafe partial uint* GuiGetIcons();

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static unsafe partial byte** GuiLoadIcons(string fileName, [MarshalAs(UnmanagedType.I1)] bool loadIconsName);

    [LibraryImport(LibraryName)]
    public static partial void GuiDrawIcon(int iconId, int posX, int posY, int pixelSize, Color color);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiWindowBox(Rectangle bounds, string title);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiGroupBox(Rectangle bounds, string text);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiLine(Rectangle bounds, string text);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiPanel(Rectangle bounds, string text);

    [LibraryImport(LibraryName)]
    public static unsafe partial int GuiTabBar(Rectangle bounds, sbyte** text, int count, ref int active);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiScrollPanel(Rectangle bounds, string text, Rectangle content,
        ref Vector2 scroll, ref Rectangle view);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiLabel(Rectangle bounds, string text);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiButton(Rectangle bounds, string text);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiLabelButton(Rectangle bounds, string text);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiToggle(Rectangle bounds, string text, [MarshalAs(UnmanagedType.I1)] ref bool active);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiToggleGroup(Rectangle bounds, string text, ref int active);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiToggleSlider(Rectangle bounds, string text, ref int active);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiCheckBox(Rectangle bounds, string text, [MarshalAs(UnmanagedType.I1)] ref bool @checked);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiComboBox(Rectangle bounds, string text, ref int active);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiDropdownBox(Rectangle bounds, string text, ref int active, [MarshalAs(UnmanagedType.I1)] bool editMode);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiSpinner(Rectangle bounds, string text, ref int value, int minValue,
        int maxValue, [MarshalAs(UnmanagedType.I1)] bool editMode);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiValueBox(Rectangle bounds, string text, ref int value, int minValue,
        int maxValue, [MarshalAs(UnmanagedType.I1)] bool editMode);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiTextBox(Rectangle bounds, ref string text, int textSize, [MarshalAs(UnmanagedType.I1)] bool editMode);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiSlider(Rectangle bounds, string textLeft, string textRight, ref float value,
        float minValue, float maxValue);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiSliderBar(Rectangle bounds, string textLeft, string textRight, ref float value,
        float minValue, float maxValue);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiProgressBar(Rectangle bounds, string textLeft, string textRight,
        ref float value, float minValue, float maxValue);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiStatusBar(Rectangle bounds, string text);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiDummyRec(Rectangle bounds, string text);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiGrid(Rectangle bounds, string text, float spacing, int subdivs,
        ref Vector2 mouseCell);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiListView(Rectangle bounds, string text, out int scrollIndex, ref int active);

    [LibraryImport(LibraryName)]
    public static unsafe partial int GuiListViewEx(Rectangle bounds, sbyte** text, int count, ref int scrollIndex,
        ref int active, ref int focus);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiMessageBox(Rectangle bounds, string title, string message, string buttons);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiTextInputBox(Rectangle bounds, string title, string message, string buttons,
        ref string text, int textMaxSize, [MarshalAs(UnmanagedType.I1)] ref bool secretViewActive);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiColorPicker(Rectangle bounds, string text, ref Color color);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiColorPanel(Rectangle bounds, string text, ref Color color);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiColorBarAlpha(Rectangle bounds, string title, ref float alpha);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiColorBarHue(Rectangle bounds, string text, ref float value);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiColorPickerHSV(Rectangle bounds, string text, ref Vector3 colorHsv);

    [LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int GuiColorPanelHSV(Rectangle bounds, string text, ref Vector3 colorHsv);
}
