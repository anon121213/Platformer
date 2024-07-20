using System;
using Data.StaticData;
using UniRx;

namespace Hud.Health
{
    public class HealthPresentor: IDisposable
    {
        private readonly IHealthModel _healthModel;
        private readonly IStaticDataProvider _staticDataProvider;

        private HealthVeiw _healthVeiw;
        private IDisposable _hpSubscription;
        
        public HealthPresentor(IHealthModel healthModel,
            IStaticDataProvider staticDataProvider)
        {
            _healthModel = healthModel;
            _staticDataProvider = staticDataProvider;
        }

        public void Constructor(HealthVeiw veiw)
        {
            _healthVeiw = veiw;
            _hpSubscription = _healthModel.Hp.Subscribe(_ => UpdateUI());
        }

        public void TakeDamage() =>
            _healthModel.TakeDamage(_staticDataProvider.BulletSettings.Damage);

        private void UpdateUI() =>
            _healthVeiw.UpdateHealthBar(_healthModel.Hp.Value, _healthModel.FullHp);

        public void Dispose() =>
            _hpSubscription.Dispose();
    }
}