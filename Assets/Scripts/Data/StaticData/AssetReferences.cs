using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data.StaticData
{
    
    [CreateAssetMenu(fileName = "AssetsReferences", menuName = "ScriptableObject/AssetsReferences")]
    public class AssetsReferences: ScriptableObject
    {
        public AssetReference MainScene;
        
        [Space]
        public AssetReference Hud;

        public AssetReference Player;
    }
}