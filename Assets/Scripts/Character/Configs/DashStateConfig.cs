using System;
using UnityEngine;

namespace Assets.Character.Configs
{
    [Serializable]
    internal class DashStateConfig
    {
        [SerializeField, Range(0, 100)] private float _speed;
        [SerializeField, Range(0, 5)] private float _maxDashTime;
        [SerializeField, Range(0, 5)] private float _refreshDashTime;

        internal float Speed => _speed;
        internal float MaxDashTime => _maxDashTime;
        internal float RefreshDashTime => _refreshDashTime;
    }
}