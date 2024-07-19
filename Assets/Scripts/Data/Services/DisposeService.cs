using System;
using System.Collections.Generic;

namespace Data.Services
{
    public class DisposeService: IDisposable, IDisposeService
    {
        private List<IDisposable> _disposibleObjects = new();

        public void AddDisposableObject(IDisposable presentor) =>
            _disposibleObjects.Add(presentor);

        public void Dispose()
        {
            foreach (IDisposable presentor in _disposibleObjects)
                presentor.Dispose();
        }
    }
}