using UnityEngine;
using UnityEngine.Serialization;

namespace Data.StaticData
{
    [CreateAssetMenu(fileName = "AllData", menuName = "ScriptableObject/AllData")]
    public class AllData: ScriptableObject
    {
        public PlayerSettings playerSettings;
        public AssetsReferences AssetsReferences;
        public BulletSettings BulletSettings;
        public BirdSettings BirdSettings;
    }
}