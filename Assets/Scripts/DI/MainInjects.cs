using Animations;
using AssetLoader;
using Birds;
using Bootstrap;
using Bullets;
using Data.Services;
using Data.StaticData;
using Factories;
using FSM;
using FSM.States;
using Hud.Health;
using Player;
using Player.Abilities;
using Player.Input;
using Player.Move;
using Pool;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DI
{
    public class MainInjects: LifetimeScope
    {
        [SerializeField] private AllData _allData;
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterFsm(builder);
            RegisterServices(builder);
            RegisterFactory(builder);
            RegisterMVP(builder);
            RegisterAnimations(builder);
        }
        
        private void RegisterServices(IContainerBuilder builder)
        {
            builder.Register<ILoadAssetService, LoadAssetServiceService>(Lifetime.Singleton);

            builder.Register<IDisposeService, DisposeService>(Lifetime.Singleton);

            builder.Register<IStaticDataProvider, StaticDataProvider>(Lifetime.Singleton).WithParameter(_allData);
            
            builder.Register<IInput, InputService>(Lifetime.Singleton);

            builder.Register<IMoveService, MoveService>(Lifetime.Singleton);

            builder.Register<ICalculateBulletSpawnPosition, CalculateBulletSpawnPosition>(Lifetime.Singleton);

            builder.Register<ICalculateBirdSpawnPosition, CalculateBirdSpawnPosition>(Lifetime.Singleton);

            builder.Register<IAbility, Invisible>(Lifetime.Singleton);

            builder.Register<SceneLoader>(Lifetime.Singleton);
        }

        private void RegisterMVP(IContainerBuilder builder)
        {
            builder.Register<IHealthModel, HealthModel>(Lifetime.Singleton);

            builder.Register<HealthPresentor>(Lifetime.Singleton);
        }
        
        private void RegisterFsm(IContainerBuilder builder)
        {
            builder.Register<GameStateMachine>(Lifetime.Scoped);

            builder.Register<LoadLevelState>(Lifetime.Singleton);

            builder.Register<BootstrapState>(Lifetime.Singleton);

            builder.Register<CreateGameObjectsState>(Lifetime.Scoped);
        }
        
        private void RegisterFactory(IContainerBuilder builder)
        {
            builder.Register<IGameFactory, GameFactory>(Lifetime.Singleton);

            builder.Register<IBulletFactory, BulletFactory>(Lifetime.Singleton);

            builder.Register<IBirdFactory, BirdFactory>(Lifetime.Singleton);

            builder.Register<BirdPool>(Lifetime.Singleton);

            builder.Register<BulletPool>(Lifetime.Singleton);
        }

        private void RegisterAnimations(IContainerBuilder builder)
        {
            builder.Register<IFadeAnim, FadeAnim>(Lifetime.Singleton);
        }
    }
}