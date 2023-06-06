// Este script se encarga de cargar una escena específica en Unity.
// Proporciona un método público "scene1" que carga la escena "museo" cuando se llama.
// Se requiere la inclusión del módulo UnityEngine.SceneManagement para utilizar la clase SceneManager.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load1 : MonoBehaviour
{
    // Este método carga la escena "museo".
    public void scene1()
    {
        SceneManager.LoadScene("museo");
    }
}
