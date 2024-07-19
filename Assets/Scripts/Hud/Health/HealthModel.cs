using Data.StaticData;
using UnityEngine;
using UniRx;

namespace Hud.Health
{
    public class HealthModel : IHealthModel
    {
        private int _fullHp;
        private ReactiveProperty<int> _hp;

        public IReadOnlyReactiveProperty<int> Hp => _hp;
        
        public int FullHp
        { 
            get => _fullHp;
            set => _fullHp = Mathf.Clamp(value, 0, int.MaxValue);
        }

        public HealthModel(IStaticDataProvider staticDataProvider)
        {
            _fullHp = staticDataProvider.DefaultPlayerSettings.HP;
            _hp = new ReactiveProperty<int>(_fullHp);
        }

        public void TakeDamage(int damage) =>
            _hp.Value -= damage;
    }
}
