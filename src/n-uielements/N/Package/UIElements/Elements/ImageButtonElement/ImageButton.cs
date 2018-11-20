using System.Collections.Generic;
using N.Package.Flow;
using N.Package.UiTools.Utility;
using N.Package.UIElements.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace N.Package.UIElements.Elements.ImageButtonElement
{
  public class ImageButton : UiElementComponent<ImageButtonState, ImageButtonProps>
  {
    private readonly RectTransformService _service;

    public ImageButton(ImageButtonState state) : base(state)
    {
      _service = new RectTransformService();
    }

    public override void OnComponentRender()
    {      
      if (Properties.Button == null) return;
      Properties.ButtonClickAction = State.OnClick;
      
      var button = Properties.Button;
      button.colors = State.Colors;

      if (Properties.ButtonGraphic != null)
      {
        var buttonGraphic = Properties.ButtonGraphic;
        buttonGraphic.sprite = State.ButtonGraphic;
        buttonGraphic.type = Image.Type.Sliced;
      }

      if (Properties.Graphic != null)
      {
        var graphic = Properties.Graphic;
        graphic.sprite = State.Graphic;
        graphic.type = Image.Type.Simple;
        
        if (State.GraphicLayout != null)
        {
          _service.ApplyTransform(State.GraphicLayout, graphic.gameObject);  
        }
      }
 
      if (State.ButtonLayout != null)
      {
        _service.ApplyTransform(State.ButtonLayout, button.gameObject);  
      }

      button.interactable = !State.Disabled;
    }

    public override IEnumerable<IFlowComponent> OnComponentLayout()
    {
      yield break;
    }
  }
}