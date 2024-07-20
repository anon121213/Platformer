namespace Data.StaticData
{
    public class StaticDataProvider : IStaticDataProvider
    {
        public StaticDataProvider(AllData allData)
        {
            AssetsReferences = allData.AssetsReferences;
            PlayerSettings = allData.playerSettings;
            BulletSettings = allData.BulletSettings;
            BirdSettings = allData.BirdSettings;
            DieWindowSettings = allData.DieWindowSettings;
        }

        public AssetsReferences AssetsReferences { get; }
        public PlayerSettings PlayerSettings { get; }
        public BulletSettings BulletSettings { get; }
        public BirdSettings BirdSettings { get; }
        public DieWindowSettings DieWindowSettings { get; }
    }
}