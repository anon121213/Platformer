using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Pool
{
    public abstract class ObjectPool<T>: IDisposable where T : Component
    {
        protected T Prefab;
        
        private readonly Stack<T> _inactiveInstances = new();

        public T GetObjectFromPool(Vector2 position, Transform root, Quaternion rotation) 
        {
            if (_inactiveInstances.Count == 0)
                return Object.Instantiate(Prefab, position, rotation, root);

            T spawnedGameObject = _inactiveInstances.Pop();
            spawnedGameObject.gameObject.SetActive(true);
            
            return spawnedGameObject;
        }
    
        public void ReturnObject(T toReturn) 
        {
            toReturn.gameObject.SetActive(false);
            _inactiveInstances.Push(toReturn);
        }

        public void Dispose()
        {
            _inactiveInstances.Clear();
        }
    }    
}