// Este script se encarga de gerenciar un objeto. para cambiar su estado a desactivo.
// Requiere la inclusión del módulo UnityEngine para utilizar la clase setobjectactive.
// El objetivo es gerenciar como se muestra un objeto.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setobjectdesactive : MonoBehaviour
{
    public GameObject UiObject;

    // Este script se encarga de desactivar un objeto UiObject en Unity.

    void Start()
    {
        // Al inicio, desactiva el objeto UiObject.
        UiObject.SetActive(false);
    }

    void OnEnable()
    {
        // Cuando este script se habilita, también desactiva el objeto UiObject.
        UiObject.SetActive(false);
    }
}