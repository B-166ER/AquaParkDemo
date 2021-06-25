using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class JumperSpawner : MonoBehaviour
{
    [SerializeField] GameObject jumperPrefab;
    [SerializeField] GameObject jumpersRoot;
    [SerializeField] PathCreator gamePath;
    [SerializeField] List<float> spawnPositions;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 tmpPos;
        foreach (var sPosition in spawnPositions)
        { 
            tmpPos = gamePath.path.GetPointAtDistance(sPosition);
            Instantiate(jumperPrefab, tmpPos, Quaternion.identity, jumpersRoot.transform);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
