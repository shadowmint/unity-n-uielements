using System.Collections.Generic;
using System.Linq;
using N.Package.Flow;
using N.Package.UIElements.Elements.VerticalListElement.Internal;
using N.Package.UIElements.Infrastructure;
using UnityEngine;

namespace N.Package.UIElements.Elements.VerticalListElement
{
    public class VerticalList<TValue> : UiElementComponent<VerticalListState<TValue>, VerticalListProps>
        where TValue : FlowComponentState, IElementLayoutState
    {
        public VerticalList(VerticalListState<TValue> state) : base(state)
        {
        }

        public override void OnComponentRender()
        {
            Properties.Container.Layout.applyLayout = true;
            Properties.Container.Layout.collectChildren = true;
        }

        public override IEnumerable<IFlowComponent> OnComponentLayout()
        {
            var distinctStates = State.Data.Select(i => i.Identity).Distinct().ToList();
            if (distinctStates.Count() != State.Data.Count)
            {
                Debug.LogWarning($"Invalid attempt render children in object without unique identity states! {string.Join(", ", distinctStates)}");
                yield break;
            }

            foreach (var child in State.Data)
            {
                yield return new VerticalListItem(new VerticalListItemState()
                {
                    Identity = child.Identity,
                    Container = () => Properties.Container.gameObject,
                    Content = State.Build(child),
                    Layout = child.ElementLayout
                });
            }
        }
    }
}