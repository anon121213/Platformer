using Bullets;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Pool
{
    public interface IBulletFactory
    {
        Bullet CreateBullet(Vector2 position, Transform root, Quaternion rotation);
        UniTask Warmup();
    }
}