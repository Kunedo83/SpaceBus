using UnityEngine;
namespace SpaceBus
{
    public class ControlInterior : PartModule
    {
        private Animation anim = null;
        private readonly string marion = "marijuana";
        private readonly string marioff = "marijuana2";
        public bool encendidaboton = false;
        public override void OnStart(StartState state)
        {
            base.OnStart(state);
            if (HighLogic.LoadedSceneIsFlight && FlightGlobals.ActiveVessel == part.vessel)
            {
                Init();
            }
        }
        private void Init()
        {
            anim = part.internalModel.gameObject.GetChild("pot-neon").GetComponent<Animation>();                        
        }
        private void Update()
        {
            if (HighLogic.LoadedSceneIsFlight && FlightGlobals.ActiveVessel == part.vessel)
            {
                if (anim == null)
                {
                    Init();
                }
                if (anim != null)
                {
                    if (part.vessel.GetComponent<ModuleLight>().isOn != encendidaboton)
                    {
                        if (part.vessel.GetComponent<ModuleLight>().isOn)
                        {
                            anim.Play(marion);
                        }
                        if (!part.vessel.GetComponent<ModuleLight>().isOn)
                        {
                            anim.Play(marioff);
                        }
                        vessel.ActionGroups.SetGroup(KSPActionGroup.Light,part.vessel.GetComponent<ModuleLight>().isOn);
                        encendidaboton = part.vessel.GetComponent<ModuleLight>().isOn;
                    }                    
                }
            }
        }        
    }
}
