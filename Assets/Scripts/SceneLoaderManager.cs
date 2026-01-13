using UnityEngine;

public class SceneLoaderManager : MonoBehaviour
{

    public static SceneLoaderManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persiste entre escenas
        }
        else
        {
            Destroy(gameObject); // evitar duplicados
        }
    }

    public string SceneToLoad;
}
