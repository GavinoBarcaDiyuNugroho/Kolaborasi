using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectToSpawn : MonoBehaviour
{
    public Vector3 firstPosition;
    public float gap = 2;
    public GameObject objectToCreate;
    void Start()
    {
        Vector3 position = firstPosition;
        for (int i = 0; i < 5; i++)
        {
            Instantiate(objectToCreate, position, Quaternion.identity);
            position.x += gap;
        }
    }
}

