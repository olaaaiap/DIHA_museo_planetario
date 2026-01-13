using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MandosNave : MonoBehaviour
{

    public TextMeshPro shipText;

    private void Start()
    {
        shipText.text = "SELECCIONA TU DESTINO";
    }

    public void LoadScene(string sceneName)
    {
        FindAnyObjectByType<SceneLoaderManager>().SceneToLoad = sceneName;

        StartCoroutine(ShipScreen());
    }

    private IEnumerator ShipScreen()
    {
        yield return new WaitForSeconds(1);

        shipText.text = "COMENZANDO DESPEGUE \n 3";

        yield return new WaitForSeconds(1);

        shipText.text = "COMENZANDO DESPEGUE \n 2";

        yield return new WaitForSeconds(1);

        shipText.text = "COMENZANDO DESPEGUE \n 1";

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("FlyingScene");
    }
}
