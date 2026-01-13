using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyingSceneLoadScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {


        yield return new WaitForSeconds(4);

        SceneManager.LoadScene(SceneLoaderManager.Instance.SceneToLoad);
    }
}
