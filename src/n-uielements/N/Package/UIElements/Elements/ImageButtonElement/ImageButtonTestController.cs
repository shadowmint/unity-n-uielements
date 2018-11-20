using N.Package.UiTools.Components;

namespace N.Package.UIElements.Elements.ImageButtonElement
{
  public class ImageButtonTestController : UiTestController<ImageButton, ImageButtonState>
  {
    protected override object MapState(ImageButtonState state)
    {
      state.OnClick = () => { UnityEngine.Debug.Log("Clicked!"); };
      return state;
    }
  }
}