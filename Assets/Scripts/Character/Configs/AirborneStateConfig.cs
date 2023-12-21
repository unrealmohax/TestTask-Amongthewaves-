using System;
using UnityEngine;

namespace Assets.Character.Configs
{
    [Serializable]
    internal class AirborneStateConfig
    {
        [SerializeField] private JumpingStateConfig _jumpingStateConfig;
        [SerializeField, Range(0, 100)] private float _speed;

        internal JumpingStateConfig JumpingStateConfig => _jumpingStateConfig;
        internal float Speed => _speed;
    }
}