using System;
using System.Collections.Generic;
using N.Package.Flow;

namespace N.Package.UIElements.Elements.VerticalListElement
{
    [System.Serializable]
    public class VerticalListState<TValue> : FlowComponentState
    {
        /// <summary>
        /// The set of actual data values.
        /// </summary>
        public List<TValue> Data;

        /// <summary>
        /// Returns an instance of the component to use TValue.
        /// </summary>
        public Func<TValue, IFlowComponent> Build;
    }
}