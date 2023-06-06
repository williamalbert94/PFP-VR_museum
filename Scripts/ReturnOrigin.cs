// Este script se encarga de devolver un objeto a su posición y rotación original cuando es soltado por un XRBaseInteractable.
// Requiere la inclusión del módulo UnityEngine.XR.Interaction.Toolkit para utilizar la clase XRBaseInteractable y el evento SelectExitEventArgs.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReturnOrigin : MonoBehaviour
{
    [SerializeField] XRBaseInteractable grabbedObjetc;
    private Pose _OriginPoint;
    private Rigidbody rb;

    private void OnEnable() => grabbedObjetc.selectExited.AddListener(ObjectReleased);
    private void OnDisable() => grabbedObjetc.selectExited.RemoveListener(ObjectReleased);

    private void Awake()
    {
        _OriginPoint.position = this.transform.position;
        _OriginPoint.rotation = this.transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    private void ObjectReleased(SelectExitEventArgs arg0)
    {
        rb.Sleep();
        GetComponent<Collider>().enabled = false;
        this.transform.position = _OriginPoint.position;
        this.transform.rotation = _OriginPoint.rotation;
        rb.WakeUp();
        GetComponent<Collider>().enabled = false;
    }
}