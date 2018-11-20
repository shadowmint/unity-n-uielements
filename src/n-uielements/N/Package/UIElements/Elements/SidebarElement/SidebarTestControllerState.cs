using N.Package.Flow;
using N.Package.UiTools.Utility;
using N.Package.UIElements.Demo.DummyElement;
using UnityEngine;

namespace N.Package.UIElements.Elements.SidebarElement
{
  [System.Serializable]
  public class SidebarTestControllerState : FlowComponentState
  {
    public RectTransformEdge SidebarLayout;
    public bool Collapsed;
    public DummyState Data;
  }
}