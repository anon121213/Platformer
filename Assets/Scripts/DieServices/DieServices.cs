using System;
using Animations;
using Bootstrap;
using Data.StaticData;
using UnityEngine;

namespace DieServices
{
    public class DieServices : IDieServices, IDisposable
    {
        private readonly IDoAnchor _doAnchor;
        private readonly IDoScale _doScale;
        private readonly IDieModel _dieModel;
        private readonly SceneLoader _sceneLoader;
        private readonly IStaticDataProvider _staticDataProvider;
        
        private DieView _view;
        private GameObject _player;

        public DieServices(IDoAnchor doAnchor,
            IDoScale doScale,
            IDieModel dieModel,
            SceneLoader sceneLoader,
            IStaticDataProvider staticDataProvider)
        {
            _doAnchor = doAnchor;
            _doScale = doScale;
            _dieModel = dieModel;
            _sceneLoader = sceneLoader;
            _staticDataProvider = staticDataProvider;
        }

        public void Constructor(DieView view,
            GameObject player)
        {
            _player = player;
            _view = view;
            _view.RestartButton.onClick.AddListener(Restart);
        }

        public void IsDie()
        {
            _doAnchor.DoAnchorPositionY(_view.dieWindow, _dieModel.EndWindowPositionValue,
                _dieModel.Duration, _dieModel.Snapping);
            
            _doScale.DoScaleAnim(_player, _staticDataProvider.PlayerSettings.DieAnimScale,
                _staticDataProvider.PlayerSettings.DieAnimDuration);
            
            Time.timeScale = 0;
        }

        private async void Restart()
        {
            await _sceneLoader.Load(_staticDataProvider.AssetsReferences.BootstrapScene);
            Time.timeScale = 1;
        }

        public void Dispose() =>
            _view.RestartButton.onClick.RemoveAllListeners();
    }
}