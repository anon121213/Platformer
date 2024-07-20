using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Hud.Health;
using UnityEngine;

namespace Bullets
{
    public class Bullet : MonoBehaviour
    {
        public event Action<Bullet> OnDisabled;

        [SerializeField] private Rigidbody2D _rb;
        
        private readonly CancellationTokenSource _cts = new();
        private Vector2 _direction;
        private HealthPresentor _healthPresentor;

        public void Constructor(GameObject player, HealthPresentor healthPresentor, float speed, float timer)
        {
            _healthPresentor = healthPresentor;
            
            SetTransform(player, speed);
            StartTimer(timer).AttachExternalCancellation(_cts.Token);
        }

        private void FixedUpdate() =>
            _rb.velocity = _direction;

        private void OnTriggerEnter2D(Collider2D other)
        {
            other.gameObject.TryGetComponent(out Player.Player player);

            if (player?.isDamageble != true)
                return;
            
            _healthPresentor.TakeDamage();
            OnDisabled?.Invoke(this);
        }

        private void SetTransform(GameObject player, float speed)
        {
            _direction = (player.transform.position - transform.position).normalized * speed;
            
            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + 90);
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