// Este script se encarga de cargar una escena espec�fica en Unity.
// Proporciona un m�todo p�blico "start" que carga la escena "Cultural Art" cuando se llama.
// Se requiere la inclusi�n del m�dulo UnityEngine.SceneManagement para utilizar la clase SceneManager.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load3 : MonoBehaviour
{
    // Este m�todo carga la escena "Cultural Art".
    public void start()
    {
        SceneManager.LoadScene("Cultural Art");
    }
}