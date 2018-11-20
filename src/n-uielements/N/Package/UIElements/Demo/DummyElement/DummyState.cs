using System;
using N.Package.Flow;
using N.Package.UIElements.Infrastructure;
using UnityEngine;

namespace N.Package.UIElements.Demo.DummyElement
{
    [System.Serializable]
    public class DummyState : FlowComponentState, IElementLayoutState
    {
        public string Id = Guid.NewGuid().ToString();

        public string DummyValue;
        
        public RectTransform Layout;

        public bool ApplyOwnLayout = true;

        protected override string DefaultIdentity()
        {
            return Id;
        }

        public RectTransform ElementLayout => Layout;
    }
}