using Couchcoding.Logbert.Gui.Controls;
using Couchcoding.Logbert.Helper;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Couchcoding.Logbert.Theme.Interfaces;
using Couchcoding.Logbert.Theme;
using Couchcoding.Logbert.Theme.Themes;

namespace Couchcoding.Logbert.Controls
{
  /// <summary>
  /// Implements a themable <see cref="ListBoxEx"/> control.
  /// </summary>
  public sealed class ThemedListBoxEx : ListBoxEx, IThemable
  {
    #region Public Methods

    /// <summary>
    /// Applies the current theme to the <see cref="Control"/>.
    /// </summary>
    /// <param name="theme">The <see cref="BaseTheme"/> instance to apply.</param>
    public void ApplyTheme(BaseTheme theme)
    {
      BackColor = theme.ColorPalette.ContentBackground;
    }

    #endregion

    #region Overridden Methods

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.ListBox.DrawItem"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DrawItemEventArgs"/> that contains the event data.</param>
    protected override void OnDrawItem(DrawItemEventArgs e)
    {
      if (Items.Count == 0 || e.Index > Items.Count)
      {
        return;
      }

      e.Graphics.FillRectangle(GdiCache.GetBrushFromColor(ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground), e.Bounds);

      if (Items[e.Index] is Seperator)
      {
        DrawSeperator(e);
        return;
      }

      bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
      bool isHover    = mMouseIndex != -1 && e.Index == mMouseIndex;

      if (isSelected)
      {
        DrawItemSelected(e, isHover);

        if (Focused && ShowFocusCues)
        {
          ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(
              e.Bounds.X + 1
            , e.Bounds.Y + 1
            , e.Bounds.Width  - 2
            , e.Bounds.Height - 2));
        }
      }

      if (isHover)
      {
        DrawItemHighlighted(e, isSelected);
      }
      
      DrawItemText(e);
    }

    /// <summary>
    /// Handles the item drawing of a non selected item.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DrawItemEventArgs"/> that contains the event data.</param>
    /// <param name="selected">Determines wheter the item is currently selected.</param>
    protected override void DrawItemHighlighted(DrawItemEventArgs e, bool selected)
    {
      e.Graphics.FillRectangle(
          GdiCache.GetBrushFromColor(selected 
          ? ThemeManager.CurrentApplicationTheme.ColorPalette.SelectionBackgroundFocused 
          : ThemeManager.CurrentApplicationTheme.ColorPalette.SelectionBackground)
        , 0
        , e.Bounds.Top
        , e.Bounds.Width - 0
        , e.Bounds.Height - 0);
    }

    /// <summary>
    /// Handles the item drawing of a selected item.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DrawItemEventArgs"/> that contains the event data.</param>
    /// <param name="hover">Determines whether the cursor is currently hovering over the item.</param>
    protected override void DrawItemSelected(DrawItemEventArgs e, bool hover)
    {
        e.Graphics.FillRectangle(
            GdiCache.GetBrushFromColor(ThemeManager.CurrentApplicationTheme.ColorPalette.SelectionBackgroundFocused)
          , 0
          , e.Bounds.Top
          , e.Bounds.Width - 0
          , e.Bounds.Height - 0);
    }

    /// <summary>
    /// Handles the drawing of the item text.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DrawItemEventArgs"/> that contains the event data.</param>
    protected override void DrawItemText(DrawItemEventArgs e)
    {
      e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

      e.Graphics.DrawString(
          Items[e.Index].ToString()
        , Font
        , GdiCache.GetBrushFromColor((e.State & DrawItemState.Selected) == DrawItemState.Selected 
          ? Focused 
            ? ThemeManager.CurrentApplicationTheme.ColorPalette.SelectionForegroundFocused 
            : ThemeManager.CurrentApplicationTheme.ColorPalette.SelectionForeground 
          : ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForeground)
        , new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Width - 4, e.Bounds.Height - 4)
        , mStringFormat);
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="ThemedListBoxEx"/> control.
    /// </summary>
    public ThemedListBoxEx()
    {
      ThemeManager.ApplyTo(this);
    }

    #endregion
  }
}
