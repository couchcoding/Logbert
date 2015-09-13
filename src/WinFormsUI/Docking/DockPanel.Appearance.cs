using System;
using System.ComponentModel;

namespace WeifenLuo.WinFormsUI.Docking
{
  public partial class DockPanel
  {
    #region Private Fields

    private DockPanelSkin m_dockPanelSkin = VS2012LightTheme.CreateVisualStudio2012Light();

    private ThemeBase m_dockPanelTheme = new VS2012LightTheme();

    #endregion

    #region Public Properties
    
    [LocalizedCategory("Category_Docking")]
    [LocalizedDescription("DockPanel_DockPanelSkin")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal DockPanelSkin Skin
    {
      get
      {
        return m_dockPanelSkin;
      }
      set
      {
        m_dockPanelSkin = value;
      }
    }

    
    [LocalizedCategory("Category_Docking")]
    [LocalizedDescription("DockPanel_DockPanelTheme")]
    public ThemeBase Theme
    {
      get
      {
        return m_dockPanelTheme;
      }
      set
      {
        if (value == null)
        {
          return;
        }

        m_dockPanelTheme = value;
        m_dockPanelTheme.Apply(this);
      }
    }

    #endregion
  }
}
