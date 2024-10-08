using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Factories
{
    public interface IGameFactory
    {
        UniTask<GameObject> CreatePlayer();
        UniTask<GameObject> CreateHud();
        UniTask<GameObject> CreateHp();
        UniTask<GameObject> CreateBulletsCreator();
        UniTask<GameObject> CreateBirdCreator();
        UniTask<GameObject> CreateDieWindow();
    }
}