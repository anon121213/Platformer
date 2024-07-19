using UnityEngine;

namespace Player.Move
{
    public class MoveService : IMoveService
    {
        public void Move1D(Rigidbody2D rb, float speed) =>
            rb.velocity = new Vector2(speed, rb.velocity.y);

        public void Move2D(Rigidbody2D rb, Vector2 moveVector) =>
            rb.velocity = moveVector;
    }
}