using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data.StaticData
{

    [CreateAssetMenu(fileName = "AssetsReferences", menuName = "ScriptableObject/AssetsReferences")]
    public class AssetsReferences : ScriptableObject
    {
        public AssetReference MainScene;

        public AssetReference BootstrapScene;

        public AssetReference Hud;

        public AssetReference Health;

        public AssetReference Player;

        public AssetReference BulletsCreator;

        public AssetReference BirdCreator;

        public AssetReference Bullet;

        public AssetReference Bird;

        public AssetReference DieWindow;
    }
}