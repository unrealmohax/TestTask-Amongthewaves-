using System;
using UnityEngine;

namespace Assets.Character.Configs
{
    [Serializable]
    internal class PushingStateConfig
    {
        [SerializeField, Range(0, 100)] private float _speedPushingLowMassObject;
        [SerializeField, Range(0, 100)] private float _speedPushingMiddleMassObject;
        [SerializeField, Range(0, 100)] private float _speedPushingBigMassObject;

        internal float SpeedPushingLowMassObject => _speedPushingLowMassObject;
        internal float SpeedPushingMiddleMassObject => _speedPushingMiddleMassObject;
        internal float SpeedPushingBigMassObject => _speedPushingBigMassObject;
    }
}
