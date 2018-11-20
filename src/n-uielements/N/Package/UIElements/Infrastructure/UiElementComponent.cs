using System.Collections.Generic;
using UnityEngine;
using N.Package.Flow;

namespace N.Package.UIElements.Infrastructure
{
    public abstract class UiElementComponent<TState, TProps> : FlowComponent<TState, TProps>
        where TState : FlowComponentState
        where TProps : FlowComponentProperties
    {
        protected UiElementComponent(TState state) : base(state)
        {
        }

       /* public override string ComponentResourcePath()
        {
            var here = GetType();
            var name = here.Name;
            if (here.IsGenericType)
            {
                name = name.Remove(name.IndexOf('`'));
            }
            return $"{here.Namespace}/{name}";
        }*/
    }
}