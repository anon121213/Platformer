using DG.Tweening;
using UnityEngine;

namespace Animations
{
    public class DoAnchor : IDoAnchor
    {
        public void DoAnchorPosition(RectTransform transform, Vector2 endPosition,
            float duration, bool snapping) =>
            transform.DOAnchorPos(endPosition, duration, snapping).SetUpdate(true);

        public void DoAnchorPositionX(RectTransform transform, float endPosition,
            float duration, bool snapping) =>
            transform.DOAnchorPosX(endPosition, duration, snapping).SetUpdate(true);

        public void DoAnchorPositionY(RectTransform transform, float endPosition,
            float duration, bool snapping) =>
            transform.DOAnchorPosY(endPosition, duration, snapping).SetUpdate(true);
    }
}