using System;
using System.Collections.Generic;
using N.Package.Flow;
using N.Package.UiTools.Utility;
using UnityEngine;

namespace N.Package.UIElements.Elements.SidebarElement
{
  [System.Serializable]
  public class SidebarState : FlowComponentState
  {
    public float ContentWidth = 150;
    public float CollapsePanelWidth = 10;
    public float ExpandPanelWidth = 10;
    
    public RectTransformEdge Edge = RectTransformEdge.Left;
    
    public IFlowComponent Content;

    public bool Collapsed;
    public Action OnExpand { get; set; }
    public Action OnCollapse { get; set; }    
  }
}