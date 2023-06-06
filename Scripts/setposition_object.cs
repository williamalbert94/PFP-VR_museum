// Este script se encarga de cambiar las posiciones de "a" con "b".
// Requiere la inclusión del módulo UnityEngine para utilizar la clase setobjectactive.
// El objetivo es reinicar el objeto "a" a un estado anterior "b".

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setposition_object : MonoBehaviour
{
    public Transform objectA;
    public Transform objectB;

    // Este script se encarga de establecer la posición y la relación de padre-hijo entre dos objetos en Unity.

    void Start()
    {
        // Establece la posición de objectA para que coincida con objectB.
        objectA.position = objectB.position;

        // Ahora establece objectB como padre de objectA para que siempre estén relacionados.
        objectA.parent = objectB;
    }

    void OnEnable()
    {
        // Establece la posición de objectA para que coincida con objectB.
        objectA.position = objectB.position;

        // Ahora establece objectB como padre de objectA para que siempre estén relacionados.
        objectA.parent = objectB;
    }
}