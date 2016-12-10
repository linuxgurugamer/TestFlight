using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestFlight.Failure_Modules
{
    public class TestFlightFailure_WheelSteer : TestFlightFailureBase_Wheel
    {
        private bool state;

        public override void DoFailure()
        {
            base.DoFailure();

            // It seems to me it is enough to break steering, GUI can't change its value anymore
            // In case if you need it is KSPField, not action or event. (same is true for motors)
            if (base.wheelSteering != null)
            {
                base.wheelSteering.enabled = false;
            }

            if (base.wheelMotorSteering != null)
            {
                this.state = base.wheelMotorSteering.steeringEnabled;
                base.wheelMotorSteering.steeringEnabled = false;
                base.wheelMotorSteering.Fields["steeringEnabled"].guiActive = false;
            }

        }

        public override float DoRepair()
        {
            base.DoRepair();
            if (base.wheelSteering != null)
            {
                base.wheelSteering.enabled = true;
            }

            if (base.wheelMotorSteering != null)
            {
                base.wheelMotorSteering.steeringEnabled = state;
                base.wheelMotorSteering.Fields["steeringEnabled"].guiActive = true;
            }
            return 0f;
        }
    }
}
