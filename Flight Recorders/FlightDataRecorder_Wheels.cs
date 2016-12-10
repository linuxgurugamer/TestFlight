using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestFlightAPI;

using UnityEngine;

namespace TestFlight.Flight_Recorders
{
    public class FlightDataRecorder_Wheels : FlightDataRecorderBase
    {
        private ModuleWheelBase wheel;
        private ModuleWheels.ModuleWheelMotor wheelMotor;
        private ModuleWheels.ModuleWheelDamage wheelDamage;
        private ModuleWheels.ModuleWheelSteering wheelSteering;
        private ModuleWheels.ModuleWheelMotorSteering wheelMotorSteering; // Wanna break all steering types
        private ModuleWheels.ModuleWheelBrakes wheelBrakes;

        public override void OnStart(PartModule.StartState state)
        {
            base.OnStart(state);
            wheel = base.part.FindModuleImplementing<ModuleWheelBase>();
            this.wheelDamage = base.part.FindModuleImplementing<ModuleWheels.ModuleWheelDamage>();
            this.wheelMotor = this.part.FindModuleImplementing<ModuleWheels.ModuleWheelMotor>();
            this.wheelSteering = this.part.FindModuleImplementing<ModuleWheels.ModuleWheelSteering>();
            this.wheelMotorSteering = this.part.FindModuleImplementing<ModuleWheels.ModuleWheelMotorSteering>();
            this.wheelBrakes = this.part.FindModuleImplementing<ModuleWheels.ModuleWheelBrakes>();
        }
        public override void OnAwake()
        {
            base.OnAwake();
        }
        public override bool IsPartOperating()
        {
            bool isGrounded = this.wheel.isGrounded;

           
            if (!isGrounded)
            {
                Debug.Log("Wheel, is not grounded");
                return false;
            }


            if ((float)base.vessel.horizontalSrfSpeed > 0f)
            {
                if (this.wheelSteering != null && !this.wheelSteering.steeringEnabled && Math.Abs(this.wheelSteering.steeringInput) > 0f)
                {
                    Debug.Log("Wheel, steering is enabled and input >0");
                    return true;
                }
                if (this.wheelMotorSteering != null && !this.wheelMotorSteering.steeringEnabled && Math.Abs(this.wheelMotorSteering.steerAxisInput.magnitude) > 0f)
                {
                    Debug.Log("Wheel, motor steering is enabled and input >0");
                    return true;
                }
                if (this.wheelBrakes.brakeInput > 0)
                {
                    Debug.Log("Wheel, brakes are on");
                    return true;
                }
                if (wheelMotor.motorEnabled && wheelMotor.state == ModuleWheels.ModuleWheelMotor.MotorState.Running )
                {
                    Debug.Log("Wheel, motor enabled and running");
                    return true;
                }
            }

            return false;
        }
    }
}

