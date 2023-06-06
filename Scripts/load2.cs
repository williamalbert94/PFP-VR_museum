// Este script se encarga de cargar una escena espec�fica en Unity.
// Proporciona un m�todo p�blico "start" que carga la escena "Street Art" cuando se llama.
// Se requiere la inclusi�n del m�dulo UnityEngine.SceneManagement para utilizar la clase SceneManager.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load2 : MonoBehaviour
{
    // Este m�todo carga la escena "Street Art".
    public void start()
    {
        SceneManager.LoadScene("Street Art");
    }
}
