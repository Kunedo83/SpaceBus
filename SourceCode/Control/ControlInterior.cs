using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlInterior : InternalModule
{
    private Animation anim;
    private GameObject boto;
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
                InternalButton.Create(boto).OnTap(new InternalButton.InternalButtonDelegate(Luz));
                loaded = true;
            }            
        }        
    }
    public void Luz()
    {
        vessel.GetComponent<ModuleLight>().isOn = !vessel.GetComponent<ModuleLight>().isOn;
    }
}
