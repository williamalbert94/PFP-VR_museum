using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setobjectdesactive : MonoBehaviour
{
    public GameObject UiObject;

    void start()
    {
        UiObject.SetActive(false);
    }

    void OnEnable()
    {
        UiObject.SetActive(false);
    }
}
