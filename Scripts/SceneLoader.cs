// Este script se encarga de cargar una escena de forma asíncrona en Unity, mostrando una pantalla de carga.
// Proporciona un método público "LoadScene" que recibe un índice de escena como parámetro y se encarga de iniciar la carga de la escena de forma asíncrona.
// Se requiere la inclusión de los módulos UnityEngine.SceneManagement y UnityEngine.UI para utilizar las clases SceneManager y UI.

using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject cube;

    // Este método carga una escena de forma asíncrona.
    // Recibe un índice de escena como parámetro.
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