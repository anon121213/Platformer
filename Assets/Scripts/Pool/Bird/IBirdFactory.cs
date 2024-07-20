using Birds;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Pool
{
    public interface IBirdFactory
    {
        UniTask Warmup();
        Bird CreateBird(Vector2 position, Transform root, Quaternion rotation);
    }
}