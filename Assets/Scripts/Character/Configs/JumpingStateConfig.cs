using System;
using UnityEngine;

namespace Assets.Character.Configs
{
    [Serializable]
    internal class JumpingStateConfig
    {
        [SerializeField, Range(0, 10)] private float _maxHeight;
        [SerializeField, Range(0, 100f)] private float _cooldownJumping;
        [SerializeField, Range(0, 5f)] private float _minDuractionJumping;

        internal float MaxHeight => _maxHeight;
        internal float CooldownJumping => _cooldownJumping;
        internal float MinDuractionJumping => _minDuractionJumping;
    }
}