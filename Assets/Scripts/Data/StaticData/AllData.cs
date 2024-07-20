using UnityEngine;
using UnityEngine.Serialization;

namespace Data.StaticData
{
    [CreateAssetMenu(fileName = "AllData", menuName = "ScriptableObject/AllData")]
    public class AllData: ScriptableObject
    {
        [FormerlySerializedAs("DefaultPlayerSettings")] public PlayerSettings playerSettings;
        public AssetsReferences AssetsReferences;
        public BulletSettings BulletSettings;
    }
}