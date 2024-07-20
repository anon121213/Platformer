using Animations;
using Cysharp.Threading.Tasks;
using Data.StaticData;

namespace Player.Abilities
{
    public class Invisible: IAbility
    {
        private readonly IStaticDataProvider _staticDataProvider;
        private readonly IFadeAnim _fadeAnim;

        private bool _isOnCooldown;
        
        public Invisible(IStaticDataProvider staticDataProvider,
            IFadeAnim fadeAnim)
        {
            _staticDataProvider = staticDataProvider;
            _fadeAnim = fadeAnim;
        }

        public async UniTask UseAbility(Player player)
        {
            if (_isOnCooldown)
                return;
            
            await SetDamageble(player);
            await SetCooldown(player);
        }

        private async UniTask SetDamageble(Player player)
        {
            _fadeAnim.DoFadeAnim(player.sprite, _staticDataProvider.PlayerSettings.FadeIntensity,
                _staticDataProvider.PlayerSettings.FadeDuration);
            
            _isOnCooldown = true;
            
            player.isDamageble = false;
            await UniTask.WaitForSeconds(_staticDataProvider.PlayerSettings.InviseLifeTime);
            player.isDamageble = true;
            
            _fadeAnim.DoFadeAnim(player.sprite, 1, 0.5f);
        }

        private async UniTask SetCooldown(Player player)
        {
            await UniTask.WaitForSeconds(_staticDataProvider.PlayerSettings.InviseCoolDown);
            
            _isOnCooldown = false;
        }
    }
}