﻿using AssetLoader;
using Bullets;
using Cysharp.Threading.Tasks;
using Data.StaticData;
using DieServices;
using Hud;
using Hud.Health;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IObjectResolver _resolver;
        private readonly ILoadAssetService _loadAssetService;
        private readonly HealthPresentor _healthPresentor;
        private readonly IDieServices _dieServices;
        private readonly AssetsReferences _assets;

        private GameObject _hud;
        private GameObject _player;
        private HudView _hudView;

        public GameFactory(IObjectResolver resolver,
            IStaticDataProvider dataProvider,
            ILoadAssetService loadAssetService,
            HealthPresentor healthPresentor,
            IDieServices dieServices)
        {
            _loadAssetService = loadAssetService;
            _healthPresentor = healthPresentor;
            _dieServices = dieServices;
            _resolver = resolver;
            _assets = dataProvider.AssetsReferences;
        }

        public async UniTask<GameObject> CreatePlayer()
        {
            _player = await _loadAssetService.GetAsset<GameObject>(_assets.Player);
            
            _player = _resolver.Instantiate(_player);

            return _player;
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

            HealthVeiw healthVeiw = hp.GetComponent<HealthVeiw>();
            
            _healthPresentor.Constructor(healthVeiw);

            return hp;
        }
        
        public async UniTask<GameObject> CreateBulletsCreator()
        {
            GameObject bulletsCreator = await _loadAssetService.GetAsset<GameObject>(_assets.BulletsCreator);
            
            bulletsCreator = _resolver.Instantiate(bulletsCreator);

            BulletsCreator creatorComponent = bulletsCreator.GetComponent<BulletsCreator>();

            creatorComponent.player = _player;

            return bulletsCreator;
        }

        public async UniTask<GameObject> CreateBirdCreator()
        {
            GameObject birdCreator = await _loadAssetService.GetAsset<GameObject>(_assets.BirdCreator);

            birdCreator = _resolver.Instantiate(birdCreator);

            return birdCreator;
        }

        public async UniTask<GameObject> CreateDieWindow()
        {
            GameObject dieWindow = await _loadAssetService.GetAsset<GameObject>(_assets.DieWindow);
            
            dieWindow = _resolver.Instantiate(dieWindow, _hudView.DieWindowRoot);

            DieView dieView = dieWindow.GetComponent<DieView>();
            
            _dieServices.Constructor(dieView, _player);
            
            return dieWindow;
        }
    }
}