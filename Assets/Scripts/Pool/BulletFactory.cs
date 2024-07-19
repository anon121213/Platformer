using Bullets;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace Pool
{
    public class BulletFactory : IBulletFactory
    {
        private readonly BulletPool _bulletPool;
        private readonly IObjectResolver _resolver;

        public BulletFactory(BulletPool bulletPool,
            IObjectResolver resolver)
        {
            _bulletPool = bulletPool;
            _resolver = resolver;
        }

        public async UniTask Warmup() =>
            await _bulletPool.Warmup();

        public Bullet CreateBullet(Vector2 position, Transform root, Quaternion rotation)
        {
            Bullet bullet = _bulletPool.GetObjectFromPool(position, root, rotation);
            bullet.transform.position = position;
            _resolver.Inject(bullet);

            bullet.OnDisabled += ReturnToPool;
            return bullet;
        }

        private void ReturnToPool(Bullet bullet)
        {
            _bulletPool.ReturnObject(bullet);
            bullet.OnDisabled -= ReturnToPool;
        }
    }
}