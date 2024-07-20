using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Data.StaticData;
using Hud.Health;
using Pool;
using Unity.Mathematics;
using UnityEngine;
using VContainer;

namespace Bullets
{
    public class BulletsCreator: MonoBehaviour
    {
        public GameObject player;
        public Transform bulletRoot;
        public bool createBullets = true;

        private IBulletFactory _bulletFactory;
        private IStaticDataProvider _staticDataProvider;
        private ICalculateBulletSpawnPosition _calculateBulletSpawnPosition;
        private HealthPresentor _healthPresentor;

        private readonly CancellationTokenSource _cts = new();

        [Inject]
        private void Inject(IBulletFactory bulletsFactory,
            IStaticDataProvider staticDataProvider,
            ICalculateBulletSpawnPosition calculateBulletSpawnPosition,
            HealthPresentor healthPresentor)
        {
            _bulletFactory = bulletsFactory;
            _staticDataProvider = staticDataProvider;
            _calculateBulletSpawnPosition = calculateBulletSpawnPosition;
            _healthPresentor = healthPresentor;
        }

        private async void Start()
        {
            await _bulletFactory.Warmup();
            await CreateBullet().AttachExternalCancellation(_cts.Token);
        }

        private async UniTask CreateBullet()
        {
            while (createBullets)
            {
                await UniTask.WaitForSeconds(_staticDataProvider.BulletSettings.BulletCreateDelay);
                
                Bullet bullet = _bulletFactory.CreateBullet(_calculateBulletSpawnPosition.Calculate(),
                    bulletRoot, quaternion.identity);
                
                bullet.Constructor(player, _healthPresentor, _staticDataProvider.BulletSettings.Speed,
                    _staticDataProvider.BulletSettings.BulletLifeTime);
            }
        }

        private void OnDestroy() =>
            _cts.Dispose();
    }
}