using System.Collections.Generic;
using N.Package.Flow;
using N.Package.UIElements.Demo.DummyElement;

namespace N.Package.UIElements.Elements.VerticalListElement
{
    [System.Serializable]
    public class VerticalListTestControllerState : FlowComponentState
    {
       public List<DummyState> Data;
    }
}