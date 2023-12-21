using System;
using UnityEngine;

namespace Assets.Character.Configs
{
    [Serializable]
    internal class HardLandingStateConfig
    {
        [SerializeField, Range(0, 100)] private float _speedForStartHardLanding;

        internal float SpeedForStartHardLanding => _speedForStartHardLanding;
    }
}