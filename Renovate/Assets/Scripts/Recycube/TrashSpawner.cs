using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] trashPrefabs = new GameObject[3];
    [SerializeField]
    private Transform spawnLocation;
    [SerializeField]
    private float _duration = 2f;

    bool isSpawning;

    // Start is called before the first frame update
    void Start()
    {
        //StartSpawning();
    }

    public void StartSpawning()
    {
        isSpawning = true;
        StartCoroutine(Spawn());

    }
    public void StopSpawning()
    {
        isSpawning = false;
        
    }
    IEnumerator Spawn()
    {
        if (isSpawning)
        {
            Instantiate(trashPrefabs[Random.Range(0, 6)], spawnLocation.position, Quaternion.Euler(0f, 0f, Random.Range(0, 365)));
        }
        yield return new WaitForSeconds(_duration);
        StartCoroutine(Spawn());
    }
}
