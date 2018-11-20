using System;
using N.Package.UIElements.Elements.ImageButtonElement;
using UnityEngine.UI;

namespace N.Package.UIElements.Elements.FilteredListElement
{
  [System.Serializable]
  public class FilteredListFilter
  {
    public string Name;
    public ImageButtonState Button;
    public Func<object, bool> Filter;
  }
}