using System;
using UnityEngine;

namespace Assets.Character.Configs
{
    [Serializable]
    internal class CharacteristicsConfig
    {
        [SerializeField, Range(0, 100)] private float _health;

        internal float Health => _health;
    }
}