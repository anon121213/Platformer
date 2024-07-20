using DG.Tweening;
using UnityEngine;

namespace Animations
{
    public class FadeAnim : IFadeAnim
    {
        public void DoFadeAnim(SpriteRenderer sprite, float intencity, float duration) =>
            sprite.DOFade(intencity, duration);
    }
}