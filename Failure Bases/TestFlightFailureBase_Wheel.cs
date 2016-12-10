using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestFlightAPI;

namespace TestFlight
{
    public class TestFlightFailureBase_Wheel : TestFlightFailureBase
    {
        protected ModuleWheelBase module;

        protected ModuleWheels.ModuleWheelMotor wheelMotor;
        protected ModuleWheels.ModuleWheelDamage wheelDamage;
        // ModuleWheelMotorSteering is rarely used for tank-style steering (like with biggest stock rover wheel). 
        // Rest use ModuleWheelSteering, I think it is worth implementing it in first place instead.
        protected ModuleWheels.ModuleWheelSteering wheelSteering;
        protected ModuleWheels.ModuleWheelMotorSteering wheelMotorSteering;
        protected ModuleWheels.ModuleWheelBrakes wheelBrakes;

        public override void OnStart(StartState state)
        {
            base.OnStart(state);
            this.module = base.part.FindModuleImplementing<ModuleWheelBase>();
            this.wheelDamage = base.part.FindModuleImplementing<ModuleWheels.ModuleWheelDamage>();
            this.wheelMotor = this.part.FindModuleImplementing<ModuleWheels.ModuleWheelMotor>();
            this.wheelSteering = this.part.FindModuleImplementing<ModuleWheels.ModuleWheelSteering>();
            this.wheelMotorSteering = this.part.FindModuleImplementing<ModuleWheels.ModuleWheelMotorSteering>();
            this.wheelBrakes = this.part.FindModuleImplementing<ModuleWheels.ModuleWheelBrakes>();
        }
    }
}
