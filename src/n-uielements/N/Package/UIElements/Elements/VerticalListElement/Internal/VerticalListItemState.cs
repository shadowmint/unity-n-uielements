using N.Package.Flow;
using UnityEngine;

namespace N.Package.UIElements.Elements.VerticalListElement.Internal
{
    [System.Serializable]
    public class VerticalListItemState : FlowComponentState
    {
        public IFlowComponent Content;
        public RectTransform Layout;
    }
}