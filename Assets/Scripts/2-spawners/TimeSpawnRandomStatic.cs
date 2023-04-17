using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSpawnRandomStatic : MonoBehaviour
{
    [SerializeField] GameObject prefabToSpawn;
    [SerializeField] Vector3 velocityOfSpawnedObject;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 1f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 3f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")] [SerializeField] float maxXDistance = 3f;

    void Start() {
         this.StartCoroutine(SpawnRoutine());    // co-routines
        // _ = SpawnRoutine();                   // async-await
    }

    IEnumerator SpawnRoutine() {    // co-routines
    // async Task SpawnRoutine() {  // async-await
        while (true) {
            float timeBetweenSpawnsInSeconds = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawnsInSeconds);       // co-routines
            // await Task.Delay((int)(timeBetweenSpawnsInSeconds*1000));       // async-await
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                transform.position.y,
                transform.position.z);
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);
            if (newObject is Mover)
            {
                newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
            }
        }
    }
}


