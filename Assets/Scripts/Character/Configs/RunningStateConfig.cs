using System;
using UnityEngine;

namespace Assets.Character.Configs
{
    [Serializable]
    internal class RunningStateConfig
    {
        [SerializeField, Range(0, 100)] private float _speed;

        internal float Speed => _speed;
    }
}