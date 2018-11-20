using N.Package.Flow;
using N.Package.UIElements.Demo.DummyElement;

namespace N.Package.UIElements.Elements.SidebarElement
{
  public class SidebarTestController : FlowController<SidebarTestControllerState>
  {
    protected override IFlowComponent OnComponentLayout()
    {
      return new Sidebar(new SidebarState()
      {
        Container = () => gameObject,
        Edge = State.SidebarLayout,
        Content = new Dummy(State.Data),
        Collapsed = State.Collapsed,
        ExpandPanelWidth = 20,
        CollapsePanelWidth = 20,
        OnCollapse = () =>
        {
          Actions.Update = true;
          State.Collapsed = true;
        },
        OnExpand = () =>
        {
          Actions.Update = true;
          State.Collapsed = false;
        }
      });
    }
  }
}