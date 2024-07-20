namespace Data.StaticData
{
    public interface IStaticDataProvider
    {
        AssetsReferences AssetsReferences { get; }
        PlayerSettings PlayerSettings { get; }
        BulletSettings BulletSettings { get; }
        BirdSettings BirdSettings { get; }
    }
}