using UnityEngine;

namespace Animations
{
    public interface IFadeAnim
    {
        void DoFadeAnim(SpriteRenderer sprite, float intencity, float duration);
    }
}