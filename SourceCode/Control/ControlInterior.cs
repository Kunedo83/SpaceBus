using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlInterior : InternalModule
{
    private Animation anim;
    private GameObject boto;
    private bool repro1 = false;
    private bool repro2 = true;
    private bool loaded = false;
    
    public void Update()
    {
        
        if (HighLogic.LoadedSceneIsFlight)
        {
            
            anim = GameObject.Find("pot-neon").GetComponent<Animation>();
            anim.wrapMode = WrapMode.Clamp;
            if (anim == null)
            {
                print("Could not find a GameObject");
                return;
            }
            boto = GameObject.Find("Buttonbus");
            if (boto == null)
            {
                print("Could not find a InternalButton");
                return;
            }
            if (!loaded)
            {
                InternalButton.Create(boto).OnTap(new InternalButton.InternalButtonDelegate(EVAClick));
                loaded = true;
            }
            if (vessel.GetComponent<ModuleLight>().isOn)
            {                
                if (!repro1)
                {
                    anim.CrossFade("marijuana");
                    repro1 = true;
                    repro2 = false;
                }                
            }
            if (!vessel.GetComponent<ModuleLight>().isOn)
            {
                if (!repro2)
                {
                    anim.CrossFade("marijuana2");
                    repro2 = true;
                    repro1 = false;
                }                
            }
        }        
    }
    public void EVAClick()
    {
        vessel.GetComponent<ModuleLight>().isOn = !vessel.GetComponent<ModuleLight>().isOn;
    }
}
