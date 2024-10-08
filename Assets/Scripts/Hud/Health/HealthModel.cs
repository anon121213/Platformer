﻿using Data.StaticData;
using UnityEngine;
using UniRx;

namespace Hud.Health
{
    public class HealthModel : IHealthModel
    {
        private int _fullHp;
        private ReactiveProperty<int> _hp;

        public IReadOnlyReactiveProperty<int> Hp => _hp;

        public int FullHp =>
            _fullHp;

        public HealthModel(IStaticDataProvider staticDataProvider)
        {
            _fullHp = staticDataProvider.PlayerSettings.Hp;
            _hp = new ReactiveProperty<int>(_fullHp);
        }

        public void TakeDamage(int damage) =>
                _hp.Value = Mathf.Clamp(_hp.Value - damage, 0, int.MaxValue);
    }
}
