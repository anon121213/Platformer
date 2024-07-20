using System;
using Data.StaticData;
using DieServices;
using UniRx;

namespace Hud.Health
{
    public class HealthPresentor: IDisposable
    {
        private readonly IHealthModel _healthModel;
        private readonly IStaticDataProvider _staticDataProvider;
        private readonly IDieServices _dieServices;

        private HealthVeiw _healthVeiw;
        private IDisposable _hpSubscription;
        private IDisposable _dieSubscription;
        
        public HealthPresentor(IHealthModel healthModel,
            IStaticDataProvider staticDataProvider,
            IDieServices dieServices)
        {
            _healthModel = healthModel;
            _staticDataProvider = staticDataProvider;
            _dieServices = dieServices;
        }

        public void Constructor(HealthVeiw veiw)
        {
            _healthVeiw = veiw;
            _hpSubscription = _healthModel.Hp.Subscribe(_ => UpdateUI());
            _dieSubscription = _healthModel.Hp.
                Where(x => x == 0).
                Subscribe(_ => Die());
        }

        public void TakeDamage() =>
            _healthModel.TakeDamage(_staticDataProvider.BulletSettings.Damage);

        private void Die() =>
            _dieServices.IsDie();

        private void UpdateUI() =>
            _healthVeiw.UpdateHealthBar(_healthModel.Hp.Value, _healthModel.FullHp);

        public void Dispose() =>
            _hpSubscription.Dispose();
    }
}