using UnityEngine;

namespace Birds
{
    public interface ICalculateBirdSpawnPosition
    {
        Vector3 Calculate();
        int GetSide();
    }
}