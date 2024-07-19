using Data.StaticData;

namespace Data.Services
{
    public class LoadDefaultSettings
    {
        private readonly IStaticDataProvider _staticDataProvider;
        
        public LoadDefaultSettings(IStaticDataProvider staticDataProvider) =>
            _staticDataProvider = staticDataProvider;

        public void SetDefaultSettings(PlayerSettings playerSettings)
        {
            playerSettings.HP = _staticDataProvider.DefaultPlayerSettings.HP;
            playerSettings.Speed = _staticDataProvider.DefaultPlayerSettings.Speed;
        }
    }
}