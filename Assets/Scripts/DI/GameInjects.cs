using AssetLoader;
using Bootstrap;
using Data.Services;
using Data.StaticData;
using FSM;
using FSM.States;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DI
{
    public class GameInjects : LifetimeScope
    {
        [SerializeField] private AllData _allData;
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterFsm(builder);
            RegisterServices(builder);

            builder.RegisterEntryPoint<GameBootstrapper>();
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.Register<ILoadAssetService, LoadAssetServiceService>(Lifetime.Singleton);

            builder.Register<IDisposeService, DisposeService>(Lifetime.Singleton);

            builder.Register<IStaticDataProvider, StaticDataProvider>(Lifetime.Singleton).WithParameter(_allData);

            builder.Register<SceneLoader>(Lifetime.Singleton);
        }
        
        private void RegisterFsm(IContainerBuilder builder)
        {
            builder.Register<GameStateMachine>(Lifetime.Singleton);

            builder.Register<LoadLevelState>(Lifetime.Singleton);

            builder.Register<BootstrapState>(Lifetime.Singleton);

            builder.Register<LoadDefaultSettingsState>(Lifetime.Singleton);
        }
    }
}