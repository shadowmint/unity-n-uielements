using N.Package.Flow;
using N.Package.UiTools.Utility;
using UnityEngine;

namespace N.Package.UIElements.Elements.ImageSliderElement
{
  [System.Serializable]
  public class ImageSliderState : FlowComponentState
  {
    public bool Disabled;
    
    public RectTransformEdge OffsetEdge;
    
    [Range(0f, 1f)]
    public float Offset;
  }
}