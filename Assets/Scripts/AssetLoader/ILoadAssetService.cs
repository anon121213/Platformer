using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AssetLoader
{
    public interface ILoadAssetService
    {
        UniTask<TObject> GetAsset<TObject>(AssetReference path) where TObject : Object;
    }
}