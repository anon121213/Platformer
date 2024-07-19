using Cysharp.Threading.Tasks;
using Data.StaticData;
using Pool;
using Unity.Mathematics;
using UnityEngine;
using VContainer;

namespace Boolets
{
    public class BulletsCreator: MonoBehaviour
    {
        public Transform BulletRoot;
        public bool CreateBullets = true;
        
        private IBulletFactory _bulletFactory;
        private IStaticDataProvider _staticDataProvider;

        [Inject]
        private void Inject(IBulletFactory bulletsFactory,
            IStaticDataProvider staticDataProvider)
        {
            _bulletFactory = bulletsFactory;
            _staticDataProvider = staticDataProvider;
        }

        private async void Start()
        {
            await _bulletFactory.Warmup();
            await CreateBullet();
        }

        private async UniTask CreateBullet()
        {
            while (CreateBullets)
            {
                await UniTask.WaitForSeconds(_staticDataProvider.DefaultPlayerSettings.BulletCreateDelay);
                Bullet bullet = _bulletFactory.CreateBullet(transform.position, BulletRoot, quaternion.identity);
                bullet.Enable(_staticDataProvider.DefaultPlayerSettings.BulletLifeTime);
            }
        }
    }
}