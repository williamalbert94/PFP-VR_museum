// Este script se encarga de cargar una escena de forma as�ncrona en Unity sin mostrar una pantalla de carga.
// Requiere la inclusi�n del m�dulo UnityEngine.SceneManagement para utilizar la clase SceneManager.

using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sceneloader_Async : MonoBehaviour
{
    // Este m�todo carga una escena de forma as�ncrona sin mostrar una pantalla de carga.
    // Recibe un �ndice de escena como par�metro.
    public void LoadScene(int levelIndex)
    {
        // Inicia la carga de la escena de forma as�ncrona.
        // El m�todo LoadSceneAsync devuelve una instancia de AsyncOperation que representa la operaci�n de carga en progreso.
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
    }
}