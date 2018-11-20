using System.Collections.Generic;
using N.Package.Flow;
using N.Package.UIElements.Demo.DummyElement;
using UnityEngine;

namespace N.Package.UIElements.Elements.FilteredListElement
{
  [System.Serializable]
  public class FilteredListTestControllerState : FlowComponentState
  {
    public FilteredListTestController Controller; 
    
    public List<FilteredListFilter> Filters = new List<FilteredListFilter>()
    {
      new FilteredListFilter()
      {
        Filter = o => (o as DummyState)?.DummyValue.Contains("A") ?? false
      },
      new FilteredListFilter()
      {
        Filter = o => (o as DummyState)?.DummyValue.Contains("B") ?? false
      },
      new FilteredListFilter()
      {
        Filter = o => (o as DummyState)?.DummyValue.Contains("C") ?? false
      },
    };
    
    public List<DummyState> Data;

    public string SelectedFilter;

    public RectTransform FiltersLayout;

    public RectTransform ContentLayout;
  }
}