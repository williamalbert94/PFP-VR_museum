using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hibrido : MonoBehaviour
{
    //The canvas you want to enable
    public GameObject cube;
    public Transform objectA;
    public Transform objectB;

    void start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        objectA.position = objectB.position;

        //Now parent the object so it is always there
        objectA.parent = objectB;
    }

    void Update()
    {
    }
    void OnTriggerExit(Collider other)
    {
    }
}
