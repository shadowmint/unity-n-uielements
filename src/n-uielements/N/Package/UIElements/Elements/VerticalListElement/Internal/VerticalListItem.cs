using System;
using System.Collections.Generic;
using N.Package.Flow;
using N.Package.UiTools.Utility;
using N.Package.UIElements.Infrastructure;

namespace N.Package.UIElements.Elements.VerticalListElement.Internal
{
    public class VerticalListItem : UiElementComponent<VerticalListItemState, VerticalListItemProps>
    {
        private static readonly Lazy<RectTransformService> Service = new Lazy<RectTransformService>(() => new RectTransformService());
        
        public VerticalListItem(VerticalListItemState state) : base(state)
        {
        }

        public override void OnComponentRender()
        {
            if (State.Layout == null) return;
            Service.Value.ApplyTransform(State.Layout, Properties);
        }

        public override IEnumerable<IFlowComponent> OnComponentLayout()
        {
            if (State.Content == null) yield break;
            State.Content.State.Container = () => Properties.gameObject;
            yield return State.Content;
        }
    }
}