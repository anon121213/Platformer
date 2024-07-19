namespace Data.StaticData
{
    public class StaticDataProvider : IStaticDataProvider
    {
        public StaticDataProvider(AllData allData)
        {
            AssetsReferences = allData.AssetsReferences;
            DefaultPlayerSettings = allData.DefaultPlayerSettings;
            BulletSettings = allData.BulletSettings;
        }

        public AssetsReferences AssetsReferences { get; }
        public DefaultPlayerSettings DefaultPlayerSettings { get; }
        public BulletSettings BulletSettings { get; }
    }
}