using System.Collections.Generic;
using N.Package.Flow;
using N.Package.UiTools.Components;
using N.Package.UIElements.Infrastructure;

namespace N.Package.UIElements.Elements.TemplateElement
{
    public class Template : UiElementComponent<TemplateState, TemplateProps>
    {
        public Template(TemplateState state) : base(state)
        {
        }

        public override void OnComponentRender()
        {
        }

        public override IEnumerable<IFlowComponent> OnComponentLayout()
        {
            yield break;
        }
    }
    
    public class TemplateProps : FlowComponentProperties
    {
    }
    
    [System.Serializable]
    public class TemplateState : FlowComponentState
    {
    }
    
    public class TemplateTestController : UiTestController<Template, TemplateState>
    {
    }
}