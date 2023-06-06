// Este script se encarga de controlar el men� en Unity.
// Proporciona un m�todo p�blico "start" que carga la escena "museo" cuando se llama.
// Se requiere la inclusi�n del m�dulo UnityEngine.SceneManagement para utilizar la clase SceneManager.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load0 : MonoBehaviour
{
    // Este m�todo carga la escena "museo".
    public void start()
    {
        SceneManager.LoadScene("museo");
    }
}
