using System.Runtime.InteropServices;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MapleGatorBot
{
	// early win10 versions acrylic styling may not work //
	// works in 99% of cases //

	public static class Styling
	{
		public static int PANEL_ALPHA = 64;
		public static Color PANEL_COLOR = Color.Black;
		public static bool ACRYLIC_STYLING = true;
		public static byte STYLING_ALPHA = 24;
		public static Color COLOR_ON = Color.FromArgb(128, 255, 128);
		public static Color COLOR_OFF = Color.FromArgb(255, 128, 128);

		public static void SetModernStyling(IntPtr handle)
		{
			var accent = new AccentPolicy 
			{ 
				AccentState = AccentState.ACCENT_ENABLE_ACRYLICBLURBEHIND 
			};

			accent.GradientColor = ARGB(STYLING_ALPHA, 0, 0, 0);

			var accentStructSize = Marshal.SizeOf(accent);

			var accentPtr = Marshal.AllocHGlobal(accentStructSize);
			Marshal.StructureToPtr(accent, accentPtr, false);

			var data = new WindowCompositionAttributeData
			{
				Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,
				SizeOfData = accentStructSize,
				Data = accentPtr
			};


			User32.SetWindowCompositionAttribute(handle, ref data);
			Marshal.FreeHGlobal(accentPtr);
		}

		public static void ToggleButton(bool enabled, Button btn)
		{
			btn.Image = enabled ? Properties.Resources.gator_toggle_on : Properties.Resources.gator_toggle_off;
			btn.FlatAppearance.BorderColor = enabled ? COLOR_ON : COLOR_OFF;
		}

		public static void ToggleLabel(bool enabled, Label lbl)
		{
			lbl.ForeColor = enabled ? COLOR_ON : COLOR_OFF;
			lbl.Text = enabled ? "ON" : "OFF";
		}

		public static void HideFormWithoutFlicker(Form f)
		{
			if (!f.IsHandleCreated)
				_ = f.Handle;

			f.TopMost = false;
			f.Enabled = false;
			f.Visible = true;
			f.Opacity = 0;
		}

		public static void ShowFormWithoutFlicker(Form f)
		{
			f.Opacity = 1;
			f.Enabled = true;
			f.TopMost = true; // Optional: restore if needed
		}

		static int ARGB(byte a, byte r, byte g, byte b) =>
			unchecked((int)((uint)(a << 24 | r << 16 | g << 8 | b)));
	}

	internal enum AccentState
	{
		ACCENT_DISABLED = 0,
		ACCENT_ENABLE_GRADIENT = 1,
		ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
		ACCENT_ENABLE_BLURBEHIND = 3,
		ACCENT_ENABLE_ACRYLICBLURBEHIND = 4,
		ACCENT_INVALID_STATE = 5,
	}

	internal enum WindowCompositionAttribute
	{
		WCA_ACCENT_POLICY = 19
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct AccentPolicy
	{
		public AccentState AccentState;
		public int AccentFlags;
		public int GradientColor;
		public int AnimationId;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct WindowCompositionAttributeData
	{
		public WindowCompositionAttribute Attribute;
		public IntPtr Data;
		public int SizeOfData;
	}

	internal static class User32
	{
		[DllImport("user32.dll")]
		internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);
	}
}