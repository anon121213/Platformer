using UnityEngine;

namespace Animations
{
    public interface IDoScale
    {
        void DoScaleAnim(GameObject target, Vector3 targetScale, float duration);
    }
}