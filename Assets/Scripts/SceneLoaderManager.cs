using UnityEngine;

public class SceneLoaderManager : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public string SceneToLoad;
}
