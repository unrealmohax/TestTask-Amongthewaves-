using System;
using UnityEngine;

namespace Assets.Character.Configs
{
    [Serializable]
    internal class TackleStateConfig
    {
        [SerializeField, Range(0, 100)] private float _speed;
        [SerializeField, Range(0, 100)] private float _duraction;

        internal float Speed => _speed;
        internal float TackleDuraction => _duraction;
    }
}