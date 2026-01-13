using UnityEngine;
using UnityEngine.UI;

public class PlanetSelector : MonoBehaviour
{
    [SerializeField] private Image imagenUIPlaneta; //Componente de imagen UI donde se enseñará el planeta seleccionado
    [SerializeField] private Sprite[] listaSpritesPlanetas; //Lista de sprites de los planetas
    [SerializeField] private Transform[] listaTransformsPlanetas; //Lista de transforms de los planetas

    private int currentIndex = 0; //Índice del planeta seleccionado

    void Start()
    {
        UpdatePlanet();
    }

    //Función que incrementa el índice y actualizar la imagen
    public void NextPlanet()
    {
        currentIndex++;
        if (currentIndex >= listaSpritesPlanetas.Length)
            currentIndex = 0;

        UpdatePlanet();
    }

    //Función que decrementa el índice y actualizar la imagen
    public void PreviousPlanet()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = listaSpritesPlanetas.Length - 1;

        UpdatePlanet();
    }

    //Función que asigna el sprite correspondiente a la imagen UI
    void UpdatePlanet()
    {
        imagenUIPlaneta.sprite = listaSpritesPlanetas[currentIndex];
    }

    //Función que acepta el planeta seleccionado y comienza el acercamiento
    public void AcceptPlanet()
    {
        //Obtener el script de PlanetApproach del planeta que se ha seleccionado
        PlanetApproach planetApproach = listaTransformsPlanetas[currentIndex].GetComponent<PlanetApproach>();

        //Null check (comprobar que el objeto tenga el componente asignado)
        if (planetApproach != null)
        {
            //Desactivar todos los planetas excepto el seleccionado
            foreach (Transform pt in listaTransformsPlanetas)
            {
                if (pt != listaTransformsPlanetas[currentIndex])
                {
                    pt.gameObject.SetActive(false);
                }
                else
                {
                    pt.gameObject.SetActive(true);
                }
            }
            //Acercar planeta seleccionado
            planetApproach.ComenzarAcercamiento(listaTransformsPlanetas[currentIndex]);

        }
    }

    //Función que activará todos los planetas
    public void ActivarTodos()
    {
        foreach (Transform pt in listaTransformsPlanetas)
        {
            pt.gameObject.SetActive(true);
        }
    }
}
