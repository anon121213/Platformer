using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Player.Abilities
{
    public interface IAbility
    {
        UniTask UseAbility(Player player);
    }
}