using System;
using System.Collections.Generic;
using N.Package.Flow;
using N.Package.UiTools.Utility;
using N.Package.UIElements.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace N.Package.UIElements.Elements.SidebarElement
{
  public class Sidebar : UiElementComponent<SidebarState, SidebarProps>
  {
    private readonly RectTransformService _service;

    public Sidebar(SidebarState state) : base(state)
    {
      _service = new RectTransformService();
    }

    public override void OnComponentRender()
    {
      // Button states
      SetPanelState(Properties.CollapsePanel, State.Collapsed, State.Edge);
      SetPanelState(Properties.ExpandPanel, State.Collapsed, State.Edge);

      // Events
      Properties.OnCollapse = State.OnCollapse;
      Properties.OnExpand = State.OnExpand;

      // Layout
      var layout = GetLayoutForCurrentMode();
      _service.ApplyTransform(layout, Properties.ExpandPanel.gameObject);
      _service.ApplyTransform(layout, Properties.CollapsePanel.gameObject);
      _service.ApplyTransform(layout, Properties.ContentPanel.gameObject);

      // Size
      SetPanelSize(Properties.ExpandPanel, State.ExpandPanelWidth, State.Edge);
      SetPanelSize(Properties.CollapsePanel, State.CollapsePanelWidth, State.Edge);
      SetPanelSize(Properties.ContentPanel, State.ContentWidth, State.Edge, State.CollapsePanelWidth);

      // Visibility 
      SetVisibility(Properties.ExpandPanel, State.Collapsed);
      SetVisibility(Properties.CollapsePanel, !State.Collapsed);
      SetVisibility(Properties.ContentPanel, !State.Collapsed);
    }

    private void SetPanelState(CanvasGroup target, bool showOpen, RectTransformEdge edge)
    {
      var button = target.GetComponentInChildren<Button>();
      var text = button.GetComponentInChildren<Text>();
      switch (edge)
      {
        case RectTransformEdge.Left:
          text.text = showOpen ? ">" : "<";
          break;
        case RectTransformEdge.Right:
          text.text = showOpen ? "<" : ">";
          break;
        case RectTransformEdge.Top:
          text.text = showOpen ? "<" : ">";
          text.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
          break;
        case RectTransformEdge.Bottom:
          text.text = showOpen ? "<" : ">";
          text.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -90f));
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(edge), edge, null);
      }
    }

    private void SetPanelSize(CanvasGroup target, float width, RectTransformEdge modifier, float offset = 0f)
    {
      var state = _service.StateFrom(target.GetComponent<RectTransform>());
      _service.SetFixedSizeFromEdge(state, width, modifier, offset);
    }

    private void SetVisibility(CanvasGroup target, bool visible)
    {
      target.alpha = visible ? 1 : 0;
      target.blocksRaycasts = visible;
    }

    private RectTransform GetLayoutForCurrentMode()
    {
      switch (State.Edge)
      {
        case RectTransformEdge.Left:
          return Properties.LeftLayout;
        case RectTransformEdge.Right:
          return Properties.RightLayout;
        case RectTransformEdge.Top:
          return Properties.TopLayout;
        case RectTransformEdge.Bottom:
          return Properties.BottomLayout;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    public override IEnumerable<IFlowComponent> OnComponentLayout()
    {
      if (State.Content == null)
      {
        yield break;
      }

      State.Content.State.Container = () => Properties.Content;
      yield return State.Content;
    }
  }
}