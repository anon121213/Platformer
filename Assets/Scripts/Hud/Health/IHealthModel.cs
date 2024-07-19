using UniRx;

namespace Hud.Health
{
    public interface IHealthModel
    {
        IReadOnlyReactiveProperty<int> Hp { get; }
        int FullHp { get; set; }

        void TakeDamage(int damage);
    }
}