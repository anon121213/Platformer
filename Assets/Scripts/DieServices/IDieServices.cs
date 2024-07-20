using UnityEngine;

namespace DieServices
{
    public interface IDieServices
    {
        void IsDie();
        void Constructor(DieView view, GameObject player);
    }
}