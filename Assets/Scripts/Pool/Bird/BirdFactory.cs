using Birds;
using Bullets;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace Pool
{
    public class BirdFactory : IBirdFactory
    {
        private readonly BirdPool _bulletPool;
        private readonly IObjectResolver _resolver;

        public BirdFactory(BirdPool bulletPool,
            IObjectResolver resolver)
        {
            _bulletPool = bulletPool;
            _resolver = resolver;
        }

        public async UniTask Warmup() =>
            await _bulletPool.Warmup();

        public Bird CreateBird(Vector2 position, Transform root, Quaternion rotation)
        {
            Bird bird = _bulletPool.GetObjectFromPool(position, root, rotation);
            bird.transform.position = position;
            _resolver.Inject(bird);

            bird.OnDisabled += ReturnToPool;
            return bird;
        }

        private void ReturnToPool(Bird bird)
        {
            _bulletPool.ReturnObject(bird);
            bird.OnDisabled -= ReturnToPool;
        }
    }
}