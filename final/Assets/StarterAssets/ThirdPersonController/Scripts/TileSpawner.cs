using UnityEngine;
using System.Collections;


public class TileSpawner : MonoBehaviour
{
    public GameObject groundTilePrefab;
    public int gridWidth = 10;
    public int gridHeight = 10;
    public float dropInterval = 150.0f;
    private Transform tileManager;

    void Start()
    {
        tileManager = transform;
        SpawnTiles();
        StartCoroutine(DropRandomTiles());
    }

    void SpawnTiles()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                Vector3 spawnPosition = new Vector3(x * 2.75f, 0, z * 2.18f); // Adjust the multiplication factor as needed
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(groundTilePrefab, spawnPosition, spawnRotation, transform);
            }
        }
    }

    IEnumerator DropRandomTiles()
    {
        yield return new WaitForSeconds(dropInterval);

        while (true)
        {
            DropRandomTile();
            DropRandomTile();
            yield return new WaitForSeconds(dropInterval);
        }
    }

    void DropRandomTile()
    {
        int randomIndex = Random.Range(0, tileManager.childCount);

        if (randomIndex < tileManager.childCount)
        {
            GameObject selectedTile = tileManager.GetChild(randomIndex).gameObject;
            GameObject planeChild = selectedTile.transform.GetChild(0).gameObject;
            // "Drop" the tile by deactivating it
            Rigidbody rb = selectedTile.GetComponent<Rigidbody>();
            if (rb == null)
            {
                MeshCollider mc = planeChild.GetComponent<MeshCollider>();
                mc.convex = true;
                rb = selectedTile.AddComponent<Rigidbody>();
                rb.useGravity = true;
                selectedTile.AddComponent<TileDestroyer>();
            }
            else
            {
                DropRandomTile();
            }

            // Optionally, you can reset the tile's position or any other properties
            // For example: tileManager.GetChild(randomIndex).position = ...;
        }
    }

}
public class TileDestroyer : MonoBehaviour
{
    void Update()
    {
        // Check if the tile has fallen below a certain Y position
        if (transform.position.y < -10f)
        {
            // If yes, destroy the GameObject
            Destroy(gameObject);
        }
    }
}