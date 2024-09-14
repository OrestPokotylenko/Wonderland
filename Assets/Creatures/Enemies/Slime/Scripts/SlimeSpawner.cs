using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject slimePrefab;

    private int areaWidth = 5;
    private int areaHeight = 5;
    private int gridSize = 5;

    private void Start()
    {
        SpawnCreatures();
    }

    private void SpawnCreatures()
    {
        int numCellsX = areaWidth / gridSize;
        int numCellsY = areaHeight / gridSize;

        for (int x = 0; x < numCellsX; x++)
        {
            for (int y = 0; y < numCellsY; y++)
            {
                Vector2 cellCenter = new Vector2(
                    (x * gridSize) + (gridSize / 2),
                    (y * gridSize) + (gridSize / 2)
                );

                for (int i = 0; i < 2; i++)
                {
                    Vector2 spawnPosition = cellCenter + new Vector2(
                        Random.Range(-gridSize / 4f, gridSize / 4f),
                        Random.Range(-gridSize / 4f, gridSize / 4f)
                    );

                    Instantiate(slimePrefab, spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}