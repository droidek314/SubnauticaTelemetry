﻿namespace SubnauticaTeslasuit.ForceFeedback
{
    struct ForceFeedbackEvent
    {
        public ForceFeedbackType Type;
        public float Multiplier;
        public bool Replay;

        public ForceFeedbackEvent(ForceFeedbackType type, float multiplier, bool replay)
        {
            Type = type;
            Multiplier = multiplier;
            Replay = replay;
        }

        public override string ToString()
        {
            return $"Type: {Type}, Multiplier: {Multiplier}, Replay: {Replay}";
        }
    }
}
