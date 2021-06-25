using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] GameObject rockPrefab;
    [SerializeField] GameObject rocksRoot;
    [SerializeField] PathCreator gamePath;
    [SerializeField] List<float> spawnPositions;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 tmpPos;
        foreach (var sPosition in spawnPositions)
        {
            tmpPos = gamePath.path.GetPointAtDistance(sPosition);
            Instantiate(rockPrefab, tmpPos, Quaternion.identity, rocksRoot.transform);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
