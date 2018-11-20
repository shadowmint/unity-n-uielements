using System;
using N.Package.Flow;
using UnityEngine;

namespace N.Package.UIElements.Elements.SidebarElement
{
  public class SidebarProps : FlowComponentProperties
  {
    public RectTransform LeftLayout;
    public RectTransform RightLayout;
    public RectTransform TopLayout;
    public RectTransform BottomLayout;

    public GameObject Content;
    public CanvasGroup ContentPanel;
    public CanvasGroup ExpandPanel;
    public CanvasGroup CollapsePanel;

    public Action OnCollapse;
    public Action OnExpand;

    public void OnCollapseEvent()
    {
      OnCollapse?.Invoke();
    }

    public void OnExpandEvent()
    {
      OnExpand?.Invoke();
    }
  }
}