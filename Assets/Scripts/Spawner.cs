using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public static bool stop;
    Vector3 position;

    public List<GameObject> fruits;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 0, 2);
    }

    public void SpawnObstacle()
    {
        if(stop) return;
        var index = Random.Range(0, fruits.Count);
        var prefab = fruits[index];

        position = transform.position;
        Instantiate(prefab, position, transform.rotation);
    }
}
