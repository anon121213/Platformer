using UnityEngine;

namespace Player.Move
{
    public interface IMoveService
    {
        void Move1D(Rigidbody2D rb, float speed);
        void Move2D(Rigidbody2D rb, Vector2 moveVector);
    }
}