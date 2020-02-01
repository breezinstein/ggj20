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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
    }

    IEnumerator Spawn()
    {
        Instantiate(trashPrefabs[0], spawnLocation.position, Quaternion.Euler(0f, 0f, Random.Range(0, 365)));
        yield return new WaitForSeconds(_duration);
        StartCoroutine(Spawn());
    }
}
