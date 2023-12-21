using System;
using UnityEngine;

namespace Assets.Character.Configs
{
    [Serializable]
    internal class JumpingOnWallStateConfig
    {
        [SerializeField, Range(0, 10)] private float _speed;
        [SerializeField, Range(0, 10)] private float _maxHeight;
        [SerializeField, Range(0, 100f)] private float _cooldownJumping;
        [SerializeField, Range(0, 5f)] private float _minDuractionJumping;

        internal float Speed => _speed;
        internal float MaxHeight => _maxHeight;
        internal float MinDuractionJumping => _minDuractionJumping;
        internal float CooldownJumping => _cooldownJumping;
    }
}


