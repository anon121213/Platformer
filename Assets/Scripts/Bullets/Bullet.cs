using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Bullets
{
    public class Bullet : MonoBehaviour
    {
        public event Action<Bullet> OnDisabled;

        [SerializeField] private Rigidbody2D _rb;
        
        private readonly CancellationTokenSource _cts = new();
        private Vector2 _direction;
        
        private void FixedUpdate()
        {
            _rb.velocity = _direction;
        }

        public void Enable(GameObject player, float speed, float timer)
        {
            _direction = (player.transform.position - transform.position).normalized * speed;
            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + 90);
            StartTimer(timer).AttachExternalCancellation(_cts.Token);
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