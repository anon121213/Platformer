using UnityEngine;
using DG.Tweening;

namespace Animations
{
    public class DoScale : IDoScale
    {
        public void DoScaleAnim(GameObject target, Vector3 targetScale, float duration) =>
            target.transform.DOScale(targetScale, duration).SetUpdate(true);
    }
}