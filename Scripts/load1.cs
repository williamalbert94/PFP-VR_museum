// Este script se encarga de cargar una escena espec�fica en Unity.
// Proporciona un m�todo p�blico "scene1" que carga la escena "museo" cuando se llama.
// Se requiere la inclusi�n del m�dulo UnityEngine.SceneManagement para utilizar la clase SceneManager.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load1 : MonoBehaviour
{
    // Este m�todo carga la escena "museo".
    public void scene1()
    {
        SceneManager.LoadScene("museo");
    }
}
