using Cysharp.Threading.Tasks;
using Data.StaticData;
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

        [Inject]
        private void Inject(IBulletFactory bulletsFactory,
            IStaticDataProvider staticDataProvider,
            ICalculateBulletSpawnPosition calculateBulletSpawnPosition)
        {
            _bulletFactory = bulletsFactory;
            _staticDataProvider = staticDataProvider;
            _calculateBulletSpawnPosition = calculateBulletSpawnPosition;
        }

        private async void Start()
        {
            await _bulletFactory.Warmup();
            await CreateBullet();
        }

        private async UniTask CreateBullet()
        {
            while (createBullets)
            {
                await UniTask.WaitForSeconds(_staticDataProvider.BulletSettings.BulletCreateDelay);
                
                Bullet bullet = _bulletFactory.CreateBullet(_calculateBulletSpawnPosition.Calculate(), bulletRoot, quaternion.identity);
                bullet.Enable(player, _staticDataProvider.BulletSettings.Speed, _staticDataProvider.BulletSettings.BulletLifeTime);
            }
        }
    }
}