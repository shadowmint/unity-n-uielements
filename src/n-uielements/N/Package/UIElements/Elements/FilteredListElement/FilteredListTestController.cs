using N.Package.Flow;
using N.Package.UIElements.Demo.DummyElement;
using N.Package.UIElements.Elements.VerticalListElement;

namespace N.Package.UIElements.Elements.FilteredListElement
{
  public class FilteredListTestController : FlowController<FilteredListTestControllerState>
  {
    protected override IFlowComponent OnComponentLayout()
    {
      return new FilteredList<DummyState>(new FilteredListState<DummyState>()
      {
        Container = () => gameObject,
        Build = state => new Dummy(state),
        Data = State.Data,
        Filters = State.Filters,
        SelectedFilter = State.SelectedFilter,
        ContentLayout = State.ContentLayout,
        FiltersLayout = State.FiltersLayout,
        OnSelectFilter = (filter) =>
        {
          State.SelectedFilter = State.SelectedFilter == filter.Name ? null : filter.Name;
          State.Controller.Actions.Update = true;
        }
      });
    }
  }
}