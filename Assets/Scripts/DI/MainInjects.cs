using AssetLoader;
using Bootstrap;
using Data.Services;
using Data.StaticData;
using Factories;
using FSM;
using FSM.States;
using Player;
using Player.Input;
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
        }
        
        private void RegisterServices(IContainerBuilder builder)
        {
            builder.Register<ILoadAssetService, LoadAssetServiceService>(Lifetime.Singleton);

            builder.Register<IDisposeService, DisposeService>(Lifetime.Singleton);

            builder.Register<IStaticDataProvider, StaticDataProvider>(Lifetime.Singleton).WithParameter(_allData);
            
            builder.Register<IInput, InputService>(Lifetime.Singleton);

            builder.Register<IMoveService, MoveService>(Lifetime.Singleton);

            builder.Register<SceneLoader>(Lifetime.Singleton);
        }
        
        private void RegisterFsm(IContainerBuilder builder)
        {
            builder.Register<GameStateMachine>(Lifetime.Scoped);

            builder.Register<LoadLevelState>(Lifetime.Singleton);

            builder.Register<BootstrapState>(Lifetime.Singleton);

            builder.Register<LoadDefaultSettingsState>(Lifetime.Singleton);

            builder.Register<CreateGameObjectsState>(Lifetime.Scoped);
        }
        
        private void RegisterFactory(IContainerBuilder builder)
        {
            builder.Register<IGameFactory, GameFactory>(Lifetime.Scoped);
        }
    }
}