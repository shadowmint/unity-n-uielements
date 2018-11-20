using N.Package.Flow;
using N.Package.UiTools.Components;
using UnityEngine;

namespace N.Package.UIElements.Elements.VerticalListElement
{
    public class VerticalListProps : FlowComponentProperties
    {
        [Tooltip("The container to put objects into")]
        public UiVerticalLayout Container;
    }
}