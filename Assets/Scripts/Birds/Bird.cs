using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Birds
{
    public class Bird: MonoBehaviour
    {
        public event Action<Bird> OnDisabled;
        
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private readonly CancellationTokenSource _cts = new();
        private float _speed;

        public void Constructor(float speed, float timer)
        {
            _speed = speed;
            StartTimer(timer).AttachExternalCancellation(_cts.Token);
            Flip(speed);
        }

        private void FixedUpdate() =>
            _rb.velocity = new Vector2(_speed, _rb.velocity.y);

        private void Flip(float speed)
        {
            if (speed < 0)
                _spriteRenderer.flipX = true;
        }

        private async UniTask StartTimer(float timer)
        {
            await UniTask.WaitForSeconds(timer);
            OnDisabled?.Invoke(this);
        }
        
        private void OnDestroy() =>
            _cts?.Dispose();
    }
}