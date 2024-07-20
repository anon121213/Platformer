using AssetLoader;
using Birds;
using Cysharp.Threading.Tasks;
using Data.StaticData;
using UnityEngine;

namespace Pool
{
    public class BirdPool: ObjectPool<Bird>
    {
        private readonly IStaticDataProvider _dataProvider;
        private readonly ILoadAssetService _loadAsset;

        private GameObject _bullet;
        
        public BirdPool(IStaticDataProvider dataProvider, ILoadAssetService loadAssetService)
        {
            _dataProvider = dataProvider;
            _loadAsset = loadAssetService;
        }
        
        public async UniTask Warmup()
        {
            if (!_bullet)
                _bullet = await _loadAsset.GetAsset<GameObject>(_dataProvider.AssetsReferences.Bird);

            Prefab = _bullet.GetComponent<Bird>();
        }
    }
}