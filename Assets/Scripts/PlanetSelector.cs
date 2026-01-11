using UnityEngine;
using UnityEngine.UI;

public class PlanetSelector : MonoBehaviour
{
    public Image planetImage;
    public Sprite[] planetSprites;
    public Transform[] planetTransforms;

    private int currentIndex = 0;

    void Start()
    {
        UpdatePlanet();
    }

    public void NextPlanet()
    {
        currentIndex++;
        if (currentIndex >= planetSprites.Length)
            currentIndex = 0;

        UpdatePlanet();
    }

    public void PreviousPlanet()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = planetSprites.Length - 1;

        UpdatePlanet();
    }

    void UpdatePlanet()
    {
        planetImage.sprite = planetSprites[currentIndex];
    }

    public void AcceptPlanet()
    {
        Debug.Log("Planeta elegido: " + currentIndex);
        Debug.Log("Planeta elegido POSICION: " + planetTransforms[currentIndex].position);
        // Aquí luego instancias el planeta 3D
        PlanetApproach planetApproach = FindFirstObjectByType<PlanetApproach>();
        if (planetApproach != null)
        {
            foreach(Transform pt in planetTransforms)
            {
                if(pt != planetTransforms[currentIndex])
                {
                    pt.gameObject.SetActive(false);
                }
            }
            planetApproach.ComenzarAcercamiento(planetTransforms[currentIndex]);
        }
    }


    public void FinishExplanation()
    {
        PlanetApproach planetApproach = FindFirstObjectByType<PlanetApproach>();
        if (planetApproach != null)
        {
            planetApproach.ComenzarRegreso();
        }

    }

    public void ActivarTodos()
    {
        foreach (Transform pt in planetTransforms)
        {
            pt.gameObject.SetActive(true);
        }
    }
}
