using Cysharp.Threading.Tasks;
using Data.StaticData;

namespace Player.Abilities
{
    public class Invisible: IAbility
    {
        private readonly IStaticDataProvider _staticDataProvider;
    
        private bool _isOnCooldown = false;
        
        public Invisible(IStaticDataProvider staticDataProvider) =>
            _staticDataProvider = staticDataProvider;

        public async UniTask UseAbility(Player player)
        {
            if (_isOnCooldown)
                return;
            
            _isOnCooldown = true;
            
            player.isDamageble = false;
            await UniTask.WaitForSeconds(_staticDataProvider.PlayerSettings.InviseLifeTime);
            player.isDamageble = true;
            
            await UniTask.WaitForSeconds(_staticDataProvider.PlayerSettings.InviseCoolDown);

            _isOnCooldown = false;
        }
    }
}