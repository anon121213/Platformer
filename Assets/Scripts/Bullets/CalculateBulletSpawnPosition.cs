using UnityEngine;

namespace Bullets
{
    public class CalculateBulletSpawnPosition : ICalculateBulletSpawnPosition
    {
        public Vector3 Calculate()
        {
            int side = Random.Range(0, 3);
            
            Vector3 spawnPosition = Vector3.zero;

            float halfHeight = Screen.height / 2;

            switch (side)
            {
                case 0: // Up
                    spawnPosition =
                        new Vector3(
                            Random.Range(Camera.main!.ScreenToWorldPoint(new Vector3(0, 0, 0)).x,
                                Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x),
                            Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y, 1.5f);
                    break;

                case 1: // Left
                    spawnPosition = new Vector3(Camera.main!.ScreenToWorldPoint(new Vector3(0, 0, 0)).x,
                        Random.Range(Camera.main.ScreenToWorldPoint(new Vector3(0, halfHeight, 0)).y,
                            Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y), 1.5f);
                    break;

                case 2: // Right
                    spawnPosition = new Vector3(Camera.main!.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x,
                        Random.Range(Camera.main.ScreenToWorldPoint(new Vector3(0, halfHeight, 0)).y,
                            Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y), 1.5f);
                    break;
            }

            return spawnPosition;
        }
    }
}