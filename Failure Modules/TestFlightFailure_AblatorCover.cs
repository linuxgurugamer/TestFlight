using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestFlightAPI;
using KSP;

namespace TestFlight
{
    public class TestFlightFailure_AblatorCover : TestFlightFailureBase
    {
        [KSPField]
        public int minDegradation = 5;
        [KSPField]
        public int maxDegradation = 10;
        [KSPField]
        bool isFailing = false;
         
        private double baseConductivity;
        private double ablatorConductivity;
        private double ablationTempThresh;
        private ModuleAblator ablator;
        private double conductivityRange;
        private double initialAblative;

        public override void OnStart(StartState state)
        {
            base.OnStart(state);
            this.baseConductivity = this.part.heatConductivity;
            this.ablator = this.part.FindModuleImplementing<ModuleAblator>();
          
            if (this.ablator != null)
            {
                this.ablatorConductivity = this.ablator.reentryConductivity;
                this.ablationTempThresh = this.ablator.ablationTempThresh;
                this.conductivityRange = this.part.heatConductivity - this.ablator.reentryConductivity;
                this.initialAblative = base.part.Resources[this.ablator.ablativeResource].amount;
            }
        }
        public override void DoFailure()
        {
            base.DoFailure();
            DoLocalFailure(true);
        }

        void DoLocalFailure(bool initial)
        {
            if (this.ablator != null)
            {
                isFailing = true;
                double total = this.baseConductivity - this.ablatorConductivity;
                double remains = total - (this.ablator.reentryConductivity - this.ablatorConductivity);
                if (remains > 0)
                {
                    Random ran = new Random();
                    double degrade = (double)ran.Next(this.minDegradation, this.maxDegradation + 1) * 0.01;
                    if (!initial)
                        degrade /= 200;
                    //this.ablator.reentryConductivity += Math.Min(remains, total * degrade);
                    this.ablator.reentryConductivity += Math.Min(remains, conductivityRange * degrade);

                    if (this.ablator.ablativeResource != string.Empty && base.part.Resources.Contains(this.ablator.ablativeResource))
                    {
                        PartResource res = base.part.Resources[this.ablator.ablativeResource];
                        
                        res.amount -= initialAblative * degrade;
                        if (res.amount < 0)
                            res.amount = 0;
                    }
                }
            }
        }
        public void FixedUpdate()
        {
            if (HighLogic.LoadedSceneIsFlight && isFailing)
            {
                if (part.skinTemperature > ablationTempThresh)
                    DoLocalFailure(false);
            }
        }

        public override float DoRepair()
        {
            base.DoRepair();
            isFailing = false;
            if (this.ablator != null)
            {
                this.ablator.reentryConductivity = this.ablatorConductivity;
            }
            return 0F;
        }
    }
}