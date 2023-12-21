using System;
using UnityEngine;

namespace Assets.Character.Configs
{
    [Serializable]
    internal class SlideWallStateConfig
    {
        [SerializeField, Range(-10, 0)] private float _speed;

        internal float Speed => _speed;
    }
}