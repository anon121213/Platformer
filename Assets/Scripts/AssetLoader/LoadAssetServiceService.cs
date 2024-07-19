using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

namespace AssetLoader
{
    public class LoadAssetServiceService : ILoadAssetService
    {
        private Dictionary<AssetReference, Object> _assets = new();
        private Dictionary<AssetReference, Scene> _scenes = new();

        public async UniTask<TObject> GetAsset<TObject>(AssetReference path) where TObject : Object
        {
            if (_assets.TryGetValue(path, out Object asset))
                return asset as TObject;
            else
            {
                await LoadAsset(path);
                return await GetAsset<TObject>(path);
            }
        }
        
        private async UniTask LoadAsset(AssetReference path)
        {
            UniTaskCompletionSource<bool> utcs = new UniTaskCompletionSource<bool>();
            AsyncOperationHandle<Object> handle = Addressables.LoadAssetAsync<Object>(path);
            
            handle.Completed += oph =>
            {
                OnPrefabLoaded(oph, path);
                utcs.TrySetResult(true);
            };
            
            await utcs.Task;
        }

        private void OnPrefabLoaded(AsyncOperationHandle<Object> handle, AssetReference path)
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                if (!_assets.ContainsValue(handle.Result))
                    _assets.Add(path, handle.Result);
            }
            else
            {
                Debug.LogError("Не удалось загрузить префаб по пути: ");
            }
        }
    }
}