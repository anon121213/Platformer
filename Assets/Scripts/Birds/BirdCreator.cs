using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Data.StaticData;
using Pool;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;

namespace Birds
{
    public class BirdCreator: MonoBehaviour
    {
        public bool createBullets = true;
        public Transform birdRoot;
        
        private IBirdFactory _birdFactory;
        private IStaticDataProvider _staticDataProvider;
        private ICalculateBirdSpawnPosition _calculateBirdSpawnPosition;

        private readonly CancellationTokenSource _cts = new();

        [Inject]
        private void Inject(IBirdFactory birdFactory,
            IStaticDataProvider staticDataProvider,
            ICalculateBirdSpawnPosition calculateBirdSpawnPosition)
        {
            _birdFactory = birdFactory;
            _staticDataProvider = staticDataProvider;
            _calculateBirdSpawnPosition = calculateBirdSpawnPosition;
        }
        
        private async void Start()
        {
            await _birdFactory.Warmup();
            await CreateBird().AttachExternalCancellation(_cts.Token);
        }
        
        private async UniTask CreateBird()
        {
            while (createBullets)
            {
                await UniTask.WaitForSeconds(_staticDataProvider.BirdSettings.Delay);

                Vector2 spawnPosition = _calculateBirdSpawnPosition.Calculate();
                
                Quaternion angle = Quaternion.identity;
                
                float speed = _staticDataProvider.BirdSettings.Speed;

                float lifeTime = _staticDataProvider.BirdSettings.LifeTime;

                if (_calculateBirdSpawnPosition.GetSide() == 1)
                    speed = -speed;
                
                Bird bird = _birdFactory.CreateBird(spawnPosition,
                    birdRoot, angle);
                
                bird.Constructor(speed, lifeTime);
            }
        }

        private void OnDestroy() =>
            _cts.Dispose();
    }
}