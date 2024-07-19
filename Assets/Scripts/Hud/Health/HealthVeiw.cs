using UnityEngine;
using UnityEngine.UI;

namespace Hud.Health
{
    public class HealthVeiw: MonoBehaviour
    {
        [SerializeField] private Image _healthBar;

        public void UpdateHealthBar(int currentHp, int maxHp) =>
            _healthBar.fillAmount = (float)currentHp / maxHp;
    }
}