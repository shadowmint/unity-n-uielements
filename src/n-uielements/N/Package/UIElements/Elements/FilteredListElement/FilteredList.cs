using System.Collections.Generic;
using System.Linq;
using N.Package.Flow;
using N.Package.UiTools.Utility;
using N.Package.UIElements.Elements.ImageButtonElement;
using N.Package.UIElements.Elements.VerticalListElement;
using N.Package.UIElements.Infrastructure;
using UnityEngine;

namespace N.Package.UIElements.Elements.FilteredListElement
{
  public class FilteredList<TValue> : UiElementComponent<FilteredListState<TValue>, FilteredListProps> where TValue : FlowComponentState, IElementLayoutState
  {
    private readonly RectTransformService _service;

    public FilteredList(FilteredListState<TValue> state) : base(state)
    {
      _service = new RectTransformService();
    }

    public override void OnComponentRender()
    {
      if (State.FiltersLayout != null)
      {
        _service.ApplyTransform(State.FiltersLayout, Properties.FiltersContainer);
      }
      
      if (State.ContentLayout != null)
      {
        _service.ApplyTransform(State.ContentLayout, Properties.ContentContainer);
      }
    }

    public override IEnumerable<IFlowComponent> OnComponentLayout()
    {
      foreach (var filter in State.Filters)
      {
        yield return RenderFilter(filter);
      }

      yield return new VerticalList<TValue>(new VerticalListState<TValue>()
      {
        Build = State.Build,
        Container = () => Properties.ContentContainer,
        Data = FilterData(State.Data),
      });
    }

    private List<TValue> FilterData(List<TValue> stateData)
    {
      var selectedFilter = State.Filters.FirstOrDefault(i => i.Name == State.SelectedFilter);
      if (selectedFilter == null) return stateData;
      if (selectedFilter.Filter == null) return stateData;
      return stateData.Where(i => selectedFilter.Filter(i)).ToList();
    }

    private IFlowComponent RenderFilter(FilteredListFilter filter)
    {
      filter.Button.Container = () => Properties.FiltersContainer;
      filter.Button.Identity = filter.Name;
      filter.Button.OnClick = () => { SelectFilter(filter); };

      filter.Button.Colors.normalColor = State.NormalFilterColor;
      filter.Button.Colors.highlightedColor = State.NormalFilterColor;
      if (State.SelectedFilter == filter.Name)
      {
        filter.Button.Colors.normalColor = State.SelectedFilterColor;
        filter.Button.Colors.highlightedColor = State.SelectedFilterColor;
      }

      return new ImageButton(filter.Button);
    }

    private void SelectFilter(FilteredListFilter filter)
    {
      State.OnSelectFilter?.Invoke(filter);
    }
  }
}