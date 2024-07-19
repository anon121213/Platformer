using System;
using System.Collections.Generic;

namespace Data.Services
{
    public class DisposeService: IDisposable, IDisposeService
    {
        private List<IDisposable> _disposibleObjects = new();

        public void AddDisposableObject(IDisposable dosposable) =>
            _disposibleObjects.Add(dosposable);

        public void Dispose()
        {
            foreach (IDisposable dosposable in _disposibleObjects)
                dosposable.Dispose();
        }
    }
}