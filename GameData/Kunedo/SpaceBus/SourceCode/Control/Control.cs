using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Control
{
    public class Control : PartModule
    {
        private Transform _lookTransform;
        [KSPField] public string lookTransformName = "landerTransformName";
        private Transform _look2Transform;
        [KSPField] public string look2TransformName = "cruiseTransformName";
        [KSPField(isPersistant = true, guiActive = true, guiActiveEditor = false, guiName = "Control"),
         UI_Toggle(disabledText = "Mode Cruise", enabledText = "Mode Lander")]
        public bool enableControl = false;
        [KSPAction("Toggle Control")]
        public void ToggleControl(KSPActionParam param)
        {
            enableControl = !enableControl;
        }
        public override void OnStart(StartState state)
        {
            base.OnStart(state);
            _lookTransform = FindChildRecursive(transform, lookTransformName);
            _look2Transform = FindChildRecursive(transform, look2TransformName);
        }
        public void Update()
        {
            if (!HighLogic.LoadedSceneIsEditor)
            {
                if (enableControl)
                {
                    part.SetReferenceTransform(_lookTransform);
                    vessel.SetReferenceTransform(part);
                }
                if (!enableControl)
                {
                    part.SetReferenceTransform(_look2Transform);
                    vessel.SetReferenceTransform(part);
                }
            }
        }
        public static Transform FindChildRecursive(Transform parent, string name)
        {
            return parent.gameObject.GetComponentsInChildren<Transform>().FirstOrDefault(t => t.name == name);
        }
    }
}
