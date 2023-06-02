using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject cube;
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
