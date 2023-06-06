// Este script se encarga de cargar una escena de forma as�ncrona en Unity, mostrando una pantalla de carga.
// Proporciona un m�todo p�blico "LoadScene" que recibe un �ndice de escena como par�metro y se encarga de iniciar la carga de la escena de forma as�ncrona.
// Se requiere la inclusi�n de los m�dulos UnityEngine.SceneManagement y UnityEngine.UI para utilizar las clases SceneManager y UI.

using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject cube;

    // Este m�todo carga una escena de forma as�ncrona.
    // Recibe un �ndice de escena como par�metro.
    public void LoadScene(int levelIndex)
    {
        cube.SetActive(false);
        Destroy(cube);
        StartCoroutine(LoadSceneAsynchronously(levelIndex));
    }

    IEnumerator LoadSceneAsynchronously(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);

        cube.SetActive(false);
        Destroy(cube);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            yield return null;
        }
    }
}