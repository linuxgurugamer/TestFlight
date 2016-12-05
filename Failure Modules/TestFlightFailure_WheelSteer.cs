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
            this.state = base.wheelSteering.enabled;
            // It seems to me it is enough to break steering, GUI can't change its value anymore
            // In case if you need it is KSPField, not action or event. (same is true for motors)
            base.wheelSteering.enabled = false;
        }

        public override float DoRepair()
        {
            base.DoRepair();
            base.wheelSteering.enabled = true;
            return 0f;
        }
    }
}
