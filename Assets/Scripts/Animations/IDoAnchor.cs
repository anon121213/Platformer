using UnityEngine;

namespace Animations
{
    public interface IDoAnchor
    {
        void DoAnchorPosition(RectTransform transform, Vector2 endPosition, float duration, bool snapping);
        void DoAnchorPositionX(RectTransform transform, float endPosition, float duration, bool snapping);
        void DoAnchorPositionY(RectTransform transform, float endPosition, float duration, bool snapping);
    }
}