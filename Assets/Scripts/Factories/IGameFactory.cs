using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Factories
{
    public interface IGameFactory
    {
        UniTask<GameObject> CreatePlayer();
    }
}