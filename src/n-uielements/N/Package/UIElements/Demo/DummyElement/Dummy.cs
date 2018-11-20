using System.Collections.Generic;
using N.Package.Flow;
using N.Package.UiTools.Utility;
using N.Package.UIElements.Infrastructure;

namespace N.Package.UIElements.Demo.DummyElement
{
    public class Dummy : UiElementComponent<DummyState, DummyProps>
    {
        private RectTransformService _service;

        public Dummy(DummyState state) : base(state)
        {
            _service = new RectTransformService();
        }

        public override void OnComponentRender()
        {
            Properties.Text.text = State.DummyValue;
            
            if (!State.ApplyOwnLayout) return;
            if (State.Layout == null) return;
            _service.ApplyTransform(State.Layout, Properties);
        }

        public override IEnumerable<IFlowComponent> OnComponentLayout()
        {
            yield break;
        }
    }
}