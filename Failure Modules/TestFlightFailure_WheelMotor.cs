using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestFlight.Failure_Modules
{
    public class TestFlightFailure_WheelMotor : TestFlightFailureBase_Wheel
    {
        private bool state;
        private bool motorSteeringFailed;

        public override void DoFailure()
        {
            base.DoFailure();
            this.state = base.wheelMotor.motorEnabled; // current state (disabled/enabled)
            base.wheelMotor.motorEnabled = false; // disable motor
            base.wheelMotor.Fields["motorEnabled"].guiActive = false; // Hide UI button)

            // If wheel has "motor steering" it should break too! (or it will use motor, which is, obviously, should not work...)
            if (base.wheelMotorSteering != null)
            {
                TestFlightFailure_WheelSteer steeringFailureModule = this.part.FindModuleImplementing<TestFlightFailure_WheelSteer>();
                if (steeringFailureModule != null)
                {
                    motorSteeringFailed = steeringFailureModule.Failed; // Just to not "fix" it magically when motor is repaired.
                    if (!motorSteeringFailed)
                    {
                        steeringFailureModule.DoFailure();
                    }
                }
            }
        }

        public override float DoRepair()
        {
            base.DoRepair();
            base.wheelMotor.motorEnabled = state; 
            base.wheelMotor.enabled = true;
            base.wheelMotor.Fields["motorEnabled"].guiActive = true;

            if (base.wheelMotorSteering != null && !motorSteeringFailed)
            {
                TestFlightFailure_WheelSteer steeringFailureModule = this.part.FindModuleImplementing<TestFlightFailure_WheelSteer>();
                if (steeringFailureModule != null)
                {
                    steeringFailureModule.DoRepair();
                }
            }
            return 0f;
        }
    }
}
