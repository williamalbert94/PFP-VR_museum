// Este script se encarga de habilitar y destruir objetos en Unity.
// Al colisionar con un objeto con colisionador, se activar� un objeto de tipo canvas.
// Cuando se sale de la colisi�n, se destruir� el objeto canvas.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableanddestroy : MonoBehaviour
{
    // El objeto canvas que se desea habilitar
    public GameObject UiObject;
    public GameObject cube;

    void Start()
    {
        // Se desactiva el objeto canvas al inicio
        UiObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // Al colisionar con otro objeto, se activa el objeto canvas
        UiObject.SetActive(true);
    }

    void Update()
    {
        // M�todo de actualizaci�n vac�o
    }

    void OnTriggerExit(Collider other)
    {
        // Al salir de la colisi�n, se activa el objeto canvas y se destruye el objeto al que est� adjunto este script
        UiObject.SetActive(true);
        Destroy(gameObject);
    }
}
