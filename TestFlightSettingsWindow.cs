using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;


namespace TestFlight
{
    // HighLogic.CurrentGame.Parameters.CustomParams<TestFlightCustomParams1>()

    public class TestFlightCustomParams1 : GameParameters.CustomParameterNode
    {
        public override string Title { get { return "General"; } }
        public override GameParameters.GameMode GameMode { get { return GameParameters.GameMode.ANY; } }
        public override string Section { get { return "Test Flight"; } }
        public override int SectionOrder { get { return 1; } }
        public override bool HasPresets { get { return false; } }

        [GameParameters.CustomParameterUI("Enabled")]
        public bool SettingsEnabled = true;

        [GameParameters.CustomParameterUI("Always Max Data")]
        public bool SettingsAlwaysMaxData = false;

        [GameParameters.CustomFloatParameterUI("Flight Data Multiplier", minValue = 0.5f, maxValue = 2.0f, /* logBase = 2, */ stepCount = 100, displayFormat = "0.00", asPercentage = false,
            toolTip = "Overall difficulty slider.\n" +
                                "Increase to make all parts accumuate flight data faster.  Decrease to make them accumulate flight data slower.\n" +
                                "A setting of 1 is normal rate")]
        public float flightDataMultiplier = 1f;          // maximum distance for EVA activities

        [GameParameters.CustomFloatParameterUI("Flight Data Engineer Multiplier", minValue = 0.5f, maxValue = 2.0f, /* logBase = 2, */ stepCount = 100, displayFormat = "0.00", asPercentage = false,
            toolTip = "Overall difficulty slider\n" +
                                "Increases or decreases the bonus applied to the accumulation of flight data from having Engineers in your crew.\n" +
                                "A setting of 1 is normal difficulty.")]
        public float flightDataEngineerMultiplier = 1f;          // maximum distance for EVA activities

        [GameParameters.CustomParameterUI("Use a single scope for all data")]
        public bool singleScope = true;

#if !DEBUG
        [GameParameters.CustomParameterUI("Enable Debugging")]
#endif
        public bool debugLog = false;


        public override void SetDifficultyPreset(GameParameters.Preset preset)
        {
            switch (preset)
            {
                case GameParameters.Preset.Easy:

                    break;

                case GameParameters.Preset.Normal:

                    break;

                case GameParameters.Preset.Moderate:

                    break;

                case GameParameters.Preset.Hard:

                    break;
            }
        }

        public override bool Enabled(MemberInfo member, GameParameters parameters)
        {
            return true;
        }

        public override bool Interactible(MemberInfo member, GameParameters parameters)
        {
            //if (HighLogic.LoadedScene != GameScenes.SPACECENTER)
            //    return false;

            return true;
            //            return true; //otherwise return true
        }

        public override IList ValidValues(MemberInfo member)
        {
            return null;
        }
    }

    // HighLogic.CurrentGame.Parameters.CustomParams<TestFlightCustomParams2>()

    public class TestFlightCustomParams2 : GameParameters.CustomParameterNode
    {
        public override string Title { get { return "Flight"; } }
        public override GameParameters.GameMode GameMode { get { return GameParameters.GameMode.ANY; } }
        public override string Section { get { return "Test Flight"; } }
        public override int SectionOrder { get { return 2; } }
        public override bool HasPresets { get { return false; } }

        [GameParameters.CustomParameterUI("Show Failed Parts Only")]
        public bool showFailedPartsOnlyInMSD = false;

        [GameParameters.CustomParameterUI("Short Part Names")]
        public bool shortenPartNameInMSD = false;

        [GameParameters.CustomParameterUI("Show Flight Data")]
        public bool showFlightDataInMSD = false;

        [GameParameters.CustomParameterUI("Show MTBF")]
        public bool showMTBFStringInMSD = true;

        [GameParameters.CustomParameterUI("Show Failure Rate")]
        public bool showFailureRateInMSD = true;

        [GameParameters.CustomParameterUI("Show Part Status Text")]
        public bool showStatusTextInMSD = true;




        public override void SetDifficultyPreset(GameParameters.Preset preset)
        {
            switch (preset)
            {
                case GameParameters.Preset.Easy:

                    break;

                case GameParameters.Preset.Normal:

                    break;

                case GameParameters.Preset.Moderate:

                    break;

                case GameParameters.Preset.Hard:

                    break;
            }
        }

        public override bool Enabled(MemberInfo member, GameParameters parameters)
        {
            return true;
        }

        public override bool Interactible(MemberInfo member, GameParameters parameters)
        {
            //if (HighLogic.LoadedScene != GameScenes.SPACECENTER)
            //    return false;

            return true;
            //            return true; //otherwise return true
        }

        public override IList ValidValues(MemberInfo member)
        {
            return null;
        }
    }


}



