using System;
using N.Package.Flow;
using UnityEngine;
using UnityEngine.UI;

namespace N.Package.UIElements.Elements.ImageButtonElement
{
  [System.Serializable]
  public class ImageButtonState : FlowComponentState
  {
    [Tooltip("The content icon for the button")]
    public Sprite Graphic;

    [Tooltip("The layout to use for the button graphic")]
    public RectTransform GraphicLayout;

    [Tooltip("The background graphic for the button background")]
    public Sprite ButtonGraphic;

    [Tooltip("The layout to use for the whole button")]
    public RectTransform ButtonLayout;

    public bool Disabled;

    public ColorBlock Colors = new ColorBlock()
    {
      colorMultiplier = 1,
      normalColor = new Color(1f, 1f, 1f, 1f),
      disabledColor = new Color(0.3f, 0.3f, 0.3f, 0.8f),
      pressedColor = new Color(0.7f, 0.7f, 0.7f, 1f),
      highlightedColor = new Color(1f, 1f, 1f, 1f),
      fadeDuration = 0.1f,
    };

    public Action OnClick;
  }
}