using AssetLoader;
using Data.Services;
using Data.StaticData;
using UnityEngine;
using VContainer;

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
    }
}