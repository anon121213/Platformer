using System;

namespace Data.Services
{
    public interface IDisposeService
    {
        void AddDisposableObject(IDisposable presentor);
    }
}