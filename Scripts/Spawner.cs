using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabList;
    public float spawnInterval = 2.0f;
    public float launchForce = 5.0f;
    public float horizontalForce = 2.0f;
    public float rotationSpeed = 180.0f;
    public Vector2 spawnAreaSize = new Vector2(1f, 1f);
    private void Start()
    {
        StartCoroutine(SpawnRandomPrefab());
        spawnInterval = 2.5f;
    }

    private IEnumerator SpawnRandomPrefab()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            int randomIndex = Random.Range(0, prefabList.Length);
            GameObject prefabToSpawn = prefabList[randomIndex];

            Vector3 spawnPosition = transform.position + new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
                0f
            );

            GameObject newPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            Rigidbody2D rb = newPrefab.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 launchDirection = Vector2.up;
                rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);

                float horizontalMovement = Random.Range(-1f, 1f);
                Vector2 horizontalForceVector = new Vector2(horizontalMovement, 0f);
                rb.AddForce(horizontalForceVector * horizontalForce, ForceMode2D.Impulse);
            }

            Rigidbody2D rbPrefab = newPrefab.GetComponent<Rigidbody2D>();
            if (rbPrefab != null)
            {
                rbPrefab.angularVelocity = rotationSpeed;
            }

            spawnInterval -= 0.02f;
            if (spawnInterval <= 0.5f)
            {
                spawnInterval = 0.5f;
            }
        }
    }
}
