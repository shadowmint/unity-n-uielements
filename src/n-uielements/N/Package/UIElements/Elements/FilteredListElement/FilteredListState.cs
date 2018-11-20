using System;
using System.Collections.Generic;
using N.Package.Flow;
using UnityEngine;

namespace N.Package.UIElements.Elements.FilteredListElement
{
  [System.Serializable]
  public class FilteredListState<TValue> : FlowComponentState
  {
    /// <summary>
    /// The total set of available objects
    /// </summary>
    public List<TValue> Data;

    /// <summary>
    /// The active filter
    /// </summary>
    public string SelectedFilter;

    /// <summary>
    /// The set of filters to display
    /// </summary>
    public List<FilteredListFilter> Filters;

    /// <summary>
    /// Returns an instance of the component to use TValue.
    /// </summary>
    public Func<TValue, IFlowComponent> Build;

    /// <summary>
    /// Invoked when the filter is selected.
    /// </summary>
    /// <returns></returns>
    public Action<FilteredListFilter> OnSelectFilter;

    /// <summary>
    /// The layout for the filters.
    /// </summary>
    public RectTransform FiltersLayout;

    /// <summary>
    /// The layout for the content area.
    /// </summary>
    public RectTransform ContentLayout;

    /// <summary>
    /// Normal color for filter tint.
    /// </summary>
    public Color NormalFilterColor = Color.white;

    /// <summary>
    /// Normal color for filter tint.
    /// </summary>
    public Color SelectedFilterColor = Color.cyan;
  }
}