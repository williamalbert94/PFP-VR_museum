// Este script se encarga de cargar una escena de forma asíncrona en Unity sin mostrar una pantalla de carga.
// Requiere la inclusión del módulo UnityEngine.SceneManagement para utilizar la clase SceneManager.

using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sceneloader_Async : MonoBehaviour
{
    // Este método carga una escena de forma asíncrona sin mostrar una pantalla de carga.
    // Recibe un índice de escena como parámetro.
    public void LoadScene(int levelIndex)
    {
        // Inicia la carga de la escena de forma asíncrona.
        // El método LoadSceneAsync devuelve una instancia de AsyncOperation que representa la operación de carga en progreso.
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
    }
}