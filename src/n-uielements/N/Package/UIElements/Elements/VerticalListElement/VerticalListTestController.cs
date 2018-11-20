using N.Package.Flow;
using N.Package.UIElements.Demo.DummyElement;

namespace N.Package.UIElements.Elements.VerticalListElement
{
    public class VerticalListTestController : FlowController<VerticalListTestControllerState>
    {
        protected override IFlowComponent OnComponentLayout()
        {
            return new VerticalList<DummyState>(new VerticalListState<DummyState>()
            {
                Container = () => gameObject,
                Build = state => new Dummy(state),
                Data = State.Data
            });
        }
    }
}