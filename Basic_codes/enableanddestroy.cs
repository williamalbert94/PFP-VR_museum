using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableanddestroy : MonoBehaviour
{
    //The canvas you want to enable
    public GameObject UiObject;
    public GameObject cube;

    void start()
    {
        UiObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        UiObject.SetActive(true);
    }

    void Update()
    {
    }
    void OnTriggerExit(Collider other)
    {
        UiObject.SetActive(true);
        Destroy(UiObject);

    }
}
