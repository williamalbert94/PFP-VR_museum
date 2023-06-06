// Este script se encarga de cargar una escena específica en Unity.
// Proporciona un método público "start" que carga la escena "Cultural Art" cuando se llama.
// Se requiere la inclusión del módulo UnityEngine.SceneManagement para utilizar la clase SceneManager.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load3 : MonoBehaviour
{
    // Este método carga la escena "Cultural Art".
    public void start()
    {
        SceneManager.LoadScene("Cultural Art");
    }
}