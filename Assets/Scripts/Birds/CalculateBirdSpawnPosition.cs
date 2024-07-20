using UnityEngine;

namespace Birds
{
    public class CalculateBirdSpawnPosition : ICalculateBirdSpawnPosition
    {
        private int _side;
        
        public Vector3 Calculate()
        {
            _side = Random.Range(0, 2);
            
            Vector3 spawnPosition = Vector3.zero;

            float halfHeight = Screen.height / 2;

            switch (_side)
            {
                case 0: // Left
                    spawnPosition = new Vector3(Camera.main!.ScreenToWorldPoint(new Vector3(0, 0, 0)).x,
                        Random.Range(Camera.main.ScreenToWorldPoint(new Vector3(0, halfHeight, 0)).y,
                            Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y), 1.5f);
                    break;

                case 1: // Right
                    spawnPosition = new Vector3(Camera.main!.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x,
                        Random.Range(Camera.main.ScreenToWorldPoint(new Vector3(0, halfHeight, 0)).y,
                            Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y), 1.5f);
                    break;
            }

            return spawnPosition;
        }

        public int GetSide() =>
            _side;
    }
}