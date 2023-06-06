// Este script se encarga de controlar el menú en Unity.
// Proporciona un método público "start" que carga la escena "museo" cuando se llama.
// Se requiere la inclusión del módulo UnityEngine.SceneManagement para utilizar la clase SceneManager.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load0 : MonoBehaviour
{
    // Este método carga la escena "museo".
    public void start()
    {
        SceneManager.LoadScene("museo");
    }
}
