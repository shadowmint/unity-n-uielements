using System;
using N.Package.Flow;
using UnityEngine.UI;

namespace N.Package.UIElements.Elements.ImageButtonElement
{
  public class ImageButtonProps : FlowComponentProperties
  {
    public Button Button;

    public Image ButtonGraphic;

    public Image Graphic;
    
    public Action ButtonClickAction;

    public void OnButtonClick()
    {
      ButtonClickAction?.Invoke();
    }
  }
}