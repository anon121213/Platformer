using Bootstrap;
using UnityEngine.AddressableAssets;

namespace FSM.States
{
    public class LoadLevelState: IPayloadedState<AssetReference>
    {
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public async void Enter(AssetReference nextScene)
        {
            await _sceneLoader.Load(nextScene);
        }

        public void Exit() { }
    }
}