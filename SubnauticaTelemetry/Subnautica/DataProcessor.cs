﻿using SubnauticaTelemetry.ForceFeedback;
using System.Collections.Generic;

namespace SubnauticaTelemetry.Subnautica
{
    class DataProcessor
    {
        public bool running { get; set; } = true;
        List<IForceFeedbackProcessor> Processors = new List<IForceFeedbackProcessor>();
        public void ProcessPlayerDepth(float depth)
        {
            if (!running)
                return;
            if (!Main.Config.enableWaterPressureEffect)
                return;
            depth = Normalize(depth, Consts.MinOceanDepth, Consts.MaxOceanDepth);
            float depthPrecent = CalculateDepthPrecent(depth);
            ForceFeedbackEvent forceFeedbackEvent = new ForceFeedbackEvent(ForceFeedbackType.WaterPressure, depthPrecent, true);
            foreach (var processor in Processors)
            {
                processor.ProcessEvent(forceFeedbackEvent);
            }
        }

        public void AddForceFeedbackProcessor(IForceFeedbackProcessor processor)
        {
            Processors.Add(processor);
        }

        public void StopAllEvents()
        {
            foreach (var processor in Processors)
            {
                processor.StopAllEvents();
            }
        }

        private float CalculateDepthPrecent(float depth)
        {
            return (depth - Consts.MinOceanDepth) / (Consts.MaxOceanDepth - Consts.MinOceanDepth);
        }

        private float Normalize(float value, float min, float max)
        {
            if (value > max)
                return max;
            if (value < min)
                return min;
            return value;
        }
    }
}
