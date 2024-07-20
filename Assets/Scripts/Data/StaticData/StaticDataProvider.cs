namespace Data.StaticData
{
    public class StaticDataProvider : IStaticDataProvider
    {
        public StaticDataProvider(AllData allData)
        {
            AssetsReferences = allData.AssetsReferences;
            PlayerSettings = allData.playerSettings;
            BulletSettings = allData.BulletSettings;
        }

        public AssetsReferences AssetsReferences { get; }
        public PlayerSettings PlayerSettings { get; }
        public BulletSettings BulletSettings { get; }
    }
}