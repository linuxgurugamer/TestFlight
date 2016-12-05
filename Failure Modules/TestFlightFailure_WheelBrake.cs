using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestFlight.Failure_Modules
{
    public class TestFlightFailure_WheelBrake : TestFlightFailureBase_Wheel
    {

        public override void DoFailure()
        {
            base.DoFailure();
            base.wheelBrakes.enabled = false;
        }
        public override float DoRepair()
        {
            base.DoRepair();
            base.wheelBrakes.enabled = true;
            return 0f;
        }
    }
}
