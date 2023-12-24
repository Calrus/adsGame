using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public GameObject terrainChunkPrefab;
    public GameObject enemyPrefab; // Prefab for your enemy
    public int numberOfEnemies = 5; // Number of enemies to spawn in each terrain chunk
    public Transform player;
    public float generationDistance = 50f;
    public float generationOffset = 10f;
    private bool firstTerrainChunkGenerated = false;

    private GameObject currentTerrainChunk;

    void Start()
    {
        GenerateTerrainChunk();
    }

    void Update()
    {
        // Check if the player has moved into a new generation zone
        if (player.position.z > currentTerrainChunk.transform.position.z + generationDistance)
        {
            Debug.Log("Generating New Terrain Chunk");
            GenerateTerrainChunk();
        }
    }

    void GenerateTerrainChunk()
    {
        // Determine the position to instantiate the new terrain chunk
        Vector3 newPosition = currentTerrainChunk != null
            ? new Vector3(0, 0, currentTerrainChunk.transform.position.z + generationOffset)
            : new Vector3(0, 0, player.position.z + generationOffset);

        // Instantiate a new terrain chunk prefab
        GameObject newTerrainChunk = Instantiate(terrainChunkPrefab, newPosition, Quaternion.identity);

        // Instantiate enemies within the new terrain chunk
        if(firstTerrainChunkGenerated){
            SpawnEnemies(newTerrainChunk.transform);
        }
        else{
            firstTerrainChunkGenerated = true;
        }
            



        // Update the current terrain chunk reference
        currentTerrainChunk = newTerrainChunk;
    }

    void SpawnEnemies(Transform terrainChunkTransform)
    {
        // Example: Spawn enemies at random positions within the terrain chunk
        for (int i = 0; i < Random.Range(0f, numberOfEnemies); i++) // Adjust the number of enemies as needed
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-5f, 5f), // Adjust the range based on the size of your terrain chunk
                1f, // Adjust the Y position based on the terrain or ground level
                Random.Range(terrainChunkTransform.position.z - 5, terrainChunkTransform.position.z + 5)
            );

            // Instantiate the enemy prefab at the random position
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity, terrainChunkTransform);
        }
    }
}
