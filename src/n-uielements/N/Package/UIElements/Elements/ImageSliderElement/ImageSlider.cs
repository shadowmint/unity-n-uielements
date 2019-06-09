using System;
using System.Collections.Generic;
using N.Package.Flow;
using N.Package.UiTools.Utility;
using N.Package.UiTools.Utility.Model;
using N.Package.UIElements.Infrastructure;
using UnityEngine;

namespace N.Package.UIElements.Elements.ImageSliderElement
{
  public class ImageSlider : UiElementComponent<ImageSliderState, ImageSliderProps>
  {
    private readonly RectTransformService _service;
    
    private RectTransformState _idleState;
    private RectTransformState _activeState;
    private RectTransformState _maskState;

    public ImageSlider(ImageSliderState state) : base(state)
    {
      _service = new RectTransformService();
    }

    public override void OnComponentRender()
    {
      UpdateDisabledState();

      var size = _service.GetSize(_idleState);
      var offset = CalculateAbsoluteOffset(size, State.OffsetEdge, 1f - State.Offset);
      UpdateOffsets(offset, State.OffsetEdge);
    }

    private float CalculateAbsoluteOffset(Vector2 size, RectTransformEdge edge, float offset)
    {
      Debug.Log(offset);
      Debug.Log(size);
      switch (State.OffsetEdge)
      {
        case RectTransformEdge.Left:
          return offset * size.x;
        case RectTransformEdge.Right:
          return offset * size.x;
        case RectTransformEdge.Top:
          return offset * size.y;
        case RectTransformEdge.Bottom:
          return offset * size.y;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private void UpdateOffsets(float offset, RectTransformEdge edge)
    {
      Debug.Log(offset);
      switch (edge)
      {
        case RectTransformEdge.Left:
          break;
        case RectTransformEdge.Right:
          break;
        case RectTransformEdge.Top:
          _activeState.Transform.offsetMin = Vector3.zero;
          _maskState.Transform.offsetMin = Vector3.zero;
          _activeState.Transform.offsetMax = new Vector2(0f, -offset);
          _maskState.Transform.offsetMax = new Vector2(0f, offset);
          break;
        case RectTransformEdge.Bottom:
          _activeState.Transform.offsetMax = Vector3.zero;
          _maskState.Transform.offsetMax = Vector3.zero;
          _activeState.Transform.offsetMin = new Vector2(0f, offset);
          _maskState.Transform.offsetMin = new Vector2(0f, -offset);
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private void UpdateDisabledState()
    {
      if (State.Disabled)
      {
        SetVisible(Properties.Idle, false);
        SetVisible(Properties.Active, false);
        SetVisible(Properties.ActiveMask, false);
        SetVisible(Properties.Disabled, true);
      }
      else if (!State.Disabled)
      {
        SetVisible(Properties.Idle, true);
        SetVisible(Properties.Active, true);
        SetVisible(Properties.ActiveMask, true);
        SetVisible(Properties.Disabled, false);
      }
    }

    private void SetVisible(CanvasGroup target, bool visible)
    {
      if (visible)
      {
        target.alpha = 1f;
        target.interactable = true;
        target.blocksRaycasts = true;
      }
      else
      {
        target.alpha = 0f;
        target.interactable = false;
        target.blocksRaycasts = false;
      }
    }

    public override void OnComponentDidMount(FlowComponentProperties props, bool justMounted)
    {
      base.OnComponentDidMount(props, justMounted);
      _idleState = _service.StateFrom(Properties.Idle.GetComponent<RectTransform>());
      _activeState = _service.StateFrom(Properties.Active.GetComponent<RectTransform>());
      _maskState = _service.StateFrom(Properties.ActiveMask.GetComponent<RectTransform>());
    }

    public override IEnumerable<IFlowComponent> OnComponentLayout()
    {
      yield break;
    }
  }
}