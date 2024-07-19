using AssetLoader;
using Cysharp.Threading.Tasks;
using Data.Services;
using Data.StaticData;
using Hud;
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
        private HudView _hudView;

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
            
            player = _resolver.Instantiate(player);

            return player;
        }

        public async UniTask<GameObject> CreateHud()
        {
            _hud = await _loadAssetService.GetAsset<GameObject>(_assets.Hud);

            _hud = _resolver.Instantiate(_hud);

            return _hud;
        }

        public async UniTask<GameObject> CreateHp()
        {
            GameObject hp = await _loadAssetService.GetAsset<GameObject>(_assets.Health);

            _hudView = _hud.GetComponent<HudView>();

            hp = _resolver.Instantiate(hp, _hudView.HpRoot);

            return hp;
        }
    }
}