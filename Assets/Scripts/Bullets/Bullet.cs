using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Boolets
{
    public class Bullet : MonoBehaviour
    {
        public event Action<Bullet> OnDisabled;

        private readonly CancellationTokenSource _cts = new();

        public void Enable(float timer)
        {
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