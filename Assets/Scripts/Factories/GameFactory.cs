using AssetLoader;
using Cysharp.Threading.Tasks;
using Data.Services;
using Data.StaticData;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IObjectResolver _resolver;
        private readonly IDisposeService _disposebleService;
        private readonly ILoadAssetService _loadAssetService;
        
        private readonly AssetsReferences _assets;

        private GameObject _hud;

        public GameFactory(IObjectResolver resolver,
            IStaticDataProvider dataProvider,
            IDisposeService disposeService,
            ILoadAssetService loadAssetService)
        {
            _disposebleService = disposeService;
            _loadAssetService = loadAssetService;
            _resolver = resolver;
            _assets = dataProvider.AssetsReferences;
        }

        public async UniTask<GameObject> CreatePlayer()
        {
            GameObject player = await _loadAssetService.GetAsset<GameObject>(_assets.Player);
            
            _resolver.Instantiate(player);

            return player;
        }
    }
}