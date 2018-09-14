using System.Collections.Generic;
using System.Drawing;

namespace Couchcoding.Logbert.Theme.Resources
{
  public sealed class VisualStudioDarkResources : ThemeResources
  {
    #region Public Properties

    public override Dictionary<string, Bitmap> Images => new Dictionary<string, Bitmap>
    {
      { "FrmMainTbNew",            Properties.VisualStudioDarkResource.FrmMainTbNew_Dark            },
      { "FrmMainTbOpen",           Properties.VisualStudioDarkResource.FrmMainTbOpen_Dark           },
      { "FrmMainTbCloseAll",       Properties.VisualStudioDarkResource.FrmMainTbCloseAll_Dark       },
      { "FrmMainTbSearch",         Properties.VisualStudioDarkResource.FrmMainTbSearch_Dark         },
      { "FrmMainTbSettings",       Properties.VisualStudioDarkResource.FrmMainTbSettings_Dark       },
      { "FrmMainTbAbout",          Properties.VisualStudioDarkResource.FrmMainTbAbout_Dark          },
      { "FrmMainTbSave",           Properties.VisualStudioDarkResource.FrmMainTbSave_Dark           },
      { "FrmMainTbFilter",         Properties.VisualStudioDarkResource.FrmMainTbFilter_Dark         },
      { "FrmMainTbTrace",          Properties.VisualStudioDarkResource.FrmMainTbTrace_Dark          },
      { "FrmMainTbDebug",          Properties.VisualStudioDarkResource.FrmMainTbDebug_Dark          },
      { "FrmMainTbInfo",           Properties.VisualStudioDarkResource.FrmMainTbInfo_Dark           },
      { "FrmMainTbWarn",           Properties.VisualStudioDarkResource.FrmMainTbWarn_Dark           },
      { "FrmMainTbError",          Properties.VisualStudioDarkResource.FrmMainTbError_Dark          },
      { "FrmMainTbFatal",          Properties.VisualStudioDarkResource.FrmMainTbFatal_Dark          },
      { "FrmMainTbStart",          Properties.VisualStudioDarkResource.FrmMainTbStart_Dark          },
      { "FrmMainTbTop",            Properties.VisualStudioDarkResource.FrmMainTbTop_Dark            },
      { "FrmMainTbBottom",         Properties.VisualStudioDarkResource.FrmMainTbBottom_Dark         },
      { "FrmMainTbTraceLog",       Properties.VisualStudioDarkResource.FrmMainTbTraceLog_Dark       },
      { "FrmMainTbBookmark",       Properties.VisualStudioDarkResource.FrmMainTbBookmark_Dark       },
      { "FrmMainTbZoomIn",         Properties.VisualStudioDarkResource.FrmMainTbZoomIn_Dark         },
      { "FrmMainTbZoomOut",        Properties.VisualStudioDarkResource.FrmMainTbZoomOut_Dark        },
      { "FrmMainTbReload",         Properties.VisualStudioDarkResource.FrmMainTbRefresh_Dark        },
      { "FrmMainTbClear",          Properties.VisualStudioDarkResource.FrmMainTbClear_Dark          },
      { "FrmMainTbDetails",        Properties.VisualStudioDarkResource.FrmMainTbDetails_Dark        },
      { "FrmMainTbLogTree",        Properties.VisualStudioDarkResource.FrmMainTbLogtree_Dark        },
      { "FrmMainTbBookmarks",      Properties.VisualStudioDarkResource.FrmBookmarks_Dark            },
      { "FrmMainTbStatistic",      Properties.VisualStudioDarkResource.FrmMainTbStatistic_Dark      },
      { "FrmMainTbTimeshift",      Properties.VisualStudioDarkResource.FrmMainTbTimeshift_Dark      },
      { "FrmBookmarksTbRemove",    Properties.VisualStudioDarkResource.FrmBookmarksTbRemove_Dark    },
      { "FrmBookmarksTbPrevious",  Properties.VisualStudioDarkResource.FrmBookmarksTbPrevious_Dark  },
      { "FrmBookmarksTbNext",      Properties.VisualStudioDarkResource.FrmBookmarksTbNext_Dark      },
      { "FrmFilterTbAdd",          Properties.VisualStudioDarkResource.FrmFilterTbAdd_Dark          },
      { "FrmFilterTbEdit",         Properties.VisualStudioDarkResource.FrmFilterTbEdit_Dark         },
      { "FrmFilterTbRemove",       Properties.VisualStudioDarkResource.FrmFilterTbRemove_Dark       },
      { "FrmScriptTbCopy",         Properties.VisualStudioDarkResource.FrmScriptTbCopy_Dark         },
      { "FrmScriptTbCut",          Properties.VisualStudioDarkResource.FrmScriptTbCut_Dark          },
      { "FrmScriptTbPaste",        Properties.VisualStudioDarkResource.FrmScriptTbPaste_Dark        },
      { "FrmScriptTbUndo",         Properties.VisualStudioDarkResource.FrmScriptTbUndo_Dark         },
      { "FrmScriptTbRedo",         Properties.VisualStudioDarkResource.FrmScriptTbRedo_Dark         },
      { "FrmScriptTbStart",        Properties.VisualStudioDarkResource.FrmScriptTbStart_Dark        },
      { "FrmScriptTbStop",         Properties.VisualStudioDarkResource.FrmScriptTbStop_Dark         },
      { "FrmScriptTbClear",        Properties.VisualStudioDarkResource.FrmScriptTbClearLog_Dark     },
      { "FrmScriptTbWordWrap",     Properties.VisualStudioDarkResource.FrmScriptTbWordWrap_Dark     },
      { "FrmStatisticTbLegend",    Properties.VisualStudioDarkResource.FrmStatisticTbLegend_Dark    },
      { "FrmMainTbSync",           Properties.VisualStudioDarkResource.FrmMainTbSync_Dark           },
      { "FrmLogTreeNodeCollapsed", Properties.VisualStudioDarkResource.FrmLogTreeNodeCollapsed_Dark },
      { "FrmLogTreeNodeExpanded",  Properties.VisualStudioDarkResource.FrmLogTreeNodeExpanded_Dark  },
      { "FrmLogBookmark",          Properties.VisualStudioDarkResource.FrmLogBookmark_Dark          },
    };

    #endregion
  }
}
