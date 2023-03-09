using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs;

namespace RayGui_cs;

public static partial class RayGui
{
    public static readonly int SCROLLBAR_LEFT_SIDE = 0;
    public static readonly int SCROLLBAR_RIGHT_SIDE = 1;

    public static readonly int RAYGUI_ICON_SIZE = 16;
    public static readonly int RAYGUI_ICON_MAX_ICONS = 256;
    public static readonly int RAYGUI_ICON_MAX_NAME_LENGTH = 32;

    public static readonly int RAYGUI_ICON_DATA_ELEMENTS = RAYGUI_ICON_SIZE * RAYGUI_ICON_SIZE / 32;

    public static readonly int RAYGUI_MAX_CONTROLS = 16;
    public static readonly int RAYGUI_MAX_PROPS_BASE = 16;
    public static readonly int RAYGUI_MAX_PROPS_EXTENDED = 8;

    public const string NATIVELIB_NAME = "raygui";
    public const string RAYGUI_VERSION = "3.5-dev";

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiEnable();

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiDisable();

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiLock();

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiUnlock();

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool GuiIsLocked();

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiFade(float alpha);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiSetState(int state);

    public static void GuiSetState(GuiState state) => GuiSetState((int)state);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern GuiState GuiGetState();

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiSetFont(Font font);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern Font GuiGetFont();

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiSetStyle(int control, int property, int value);

    public static void GuiSetStyle(GuiStyleProp style) => GuiSetStyle(style.controlId, style.propertyId, (int)style.propertyValue);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GuiGetStyle(int control, int property);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool GuiWindowBox(Rectangle bounds, string title);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiGroupBox(Rectangle bounds, string text);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiLine(Rectangle bounds, string text);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiPanel(Rectangle bounds, string text);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiTabBar(Rectangle bounds, string text, int count, int active);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern Rectangle GuiScrollPanel(Rectangle bounds, string text, Rectangle content, Vector2 scroll);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiLabel(Rectangle bounds, string text);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool GuiButton(Rectangle bounds, string text);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool GuiLabelButton(Rectangle bounds, string text);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool GuiToggle(Rectangle bounds, string text, bool active);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GuiToggleGroup(Rectangle bounds, string text, int active);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool GuiCheckBox(Rectangle bounds, string text, bool @checked);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GuiComboBox(Rectangle bounds, string text, int active);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool GuiDropdownBox(Rectangle bounds, string text, int active, bool editMode);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool GuiSpinner(Rectangle bounds, string text, int value, int minValue, int maxValue, bool editMode);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool GuiValueBox(Rectangle bounds, string text, int value, int minValue, int maxValue, bool editMode);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool GuiTextBox(Rectangle bounds, string text, int textSize, bool editMode);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool GuiTextBoxMulti(Rectangle bounds, string text, int textSize, bool editMode);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GuiSlider(Rectangle bounds, string textLeft, string textRight, float value, float minValue, float maxValue);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GuiSliderBar(Rectangle bounds, string textLeft, string textRight, float value, float minValue, float maxValue);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GuiProgressBar(Rectangle bounds, string textLeft, string textRight, float value, float minValue, float maxValue);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiStatusBar(Rectangle bounds, string text);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiDummyRec(Rectangle bounds, string text);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GuiGrid(Rectangle bounds, string text, float spacing, int subdivs);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GuiListView(Rectangle bounds, string text, int scrollIndex, int active);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GuiListViewEx(Rectangle bounds, string text, int count, int focus, int scrollIndex, int active);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GuiMessageBox(Rectangle bounds, string title, string message, string buttons);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GuiTextInputBox(Rectangle bounds, string title, string message, string buttons, string text, int textMaxSize, int secretViewActive);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern Color GuiColorPicker(Rectangle bounds, string text, Color color);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern Color GuiColorPanel(Rectangle bounds, string text, Color color);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GuiColorBarAlpha(Rectangle bounds, string text, float alpha);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GuiColorBarHue(Rectangle bounds, string text, float value);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiLoadStyle(string fileName);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiLoadStyleDefault();

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiEnableTooltip();

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiDisableTooltip();

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiSetTooltip(string tooltip);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern string GuiIconText(int iconId, string text);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint[] GuiGetIcons();

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern string[] GuiLoadIcons(string fileName, bool loadIconsName);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiDrawIcon(int iconId, int posX, int posY, int pixelSize, Color color);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiSetIconScale(int scale);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetTextWidth(string text);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern Rectangle GetTextBounds(int control, Rectangle bounds);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern string GetTextIcon(string text, int iconId);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiDrawText(string text, Rectangle bounds, int alignment, Color tint);

    public static void GuiDrawText(string text, Rectangle bounds, GuiTextAlignment alignment, Color tint) =>
        GuiDrawText(text, bounds, (int)alignment, tint);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiDrawRectangle(Rectangle rec, int borderWidth, Color borderColor, Color color);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern string[] GuiTextSplit(string text, char delimeter, int count, int textRow);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 ConvertHSVtoRGB(Vector3 hsv);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 ConvertRGBtoHSV(Vector3 rgb);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GuiScrollBar(Rectangle bounds, int value, int minValue, int maxValue);

    [DllImport(NATIVELIB_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GuiTooltip(Rectangle controlRec);
}