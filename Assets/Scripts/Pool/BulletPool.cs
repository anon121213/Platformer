using AssetLoader;
using Boolets;
using Cysharp.Threading.Tasks;
using Data.StaticData;
using UnityEngine;

namespace Pool
{
    public class BulletPool : ObjectPool<Bullet>
    {
        private readonly IStaticDataProvider _dataProvider;
        private readonly ILoadAssetService _loadAsset;

        private GameObject _bullet;
        
        public BulletPool(IStaticDataProvider dataProvider, ILoadAssetService loadAssetService)
        {
            _dataProvider = dataProvider;
            _loadAsset = loadAssetService;
        }
        
        public async UniTask Warmup()
        {
            if (!_bullet)
                _bullet = await _loadAsset.GetAsset<GameObject>(_dataProvider.AssetsReferences.Bullet);

            Prefab = _bullet.GetComponent<Bullet>();
        }
    }
}