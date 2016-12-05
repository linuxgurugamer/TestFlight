using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestFlight.Failure_Modules
{
    public class TestFlightFailure_WheelMotor : TestFlightFailureBase_Wheel
    {
        private bool state;

        public override void DoFailure()
        {
            base.DoFailure();
            this.state = base.wheelMotor.motorEnabled; // current state (disabled/enabled)
            base.wheelMotor.motorEnabled = false; // disable motor
            base.wheelMotor.enabled = false; // Break module
            base.wheelMotor.Fields["motorEnabled"].guiActive = false; // Hide UI button)
            // Despite best efforts "burned" motor still provides uncontrollable throttle :(
        }

        public override float DoRepair()
        {
            base.DoRepair();
            base.wheelMotor.motorEnabled = state; 
            base.wheelMotor.enabled = true;
            base.wheelMotor.Fields["motorEnabled"].guiActive = true;
            return 0f;
        }
    }
}
