
using Unity.XR.CoreUtils;
using UnityEngine;

public class PlanetApproach : MonoBehaviour
{
    private bool acercando = false;
    private bool regresando = false;
    private Transform planetaElegido;
    private Vector3 posicionOriginal;

    public Transform cameraTransform;  // La cámara (XR Origin)
    public float velocidad = 1f;  // Velocidad de acercamiento
    public float velocidadRegreso = 3f;  // Velocidad de acercamiento
    public float distanciaDeAcercamiento = 10f;  // Distancia a la que el planeta se acerca
    public AudioSource audioSource;  // Componente de AudioSource para el planeta

    void Start()
    {
        // Si no se asigna manualmente, busca la cámara en el XR Origin
        if (cameraTransform == null)
        {
            cameraTransform = FindFirstObjectByType<XROrigin>().transform.GetChild(0);  // Asume que la cámara está como primer hijo del XR Origin
        }
    }

    void Update()
    {
        if (acercando)
        {
            AcercarPlaneta();
        }
        else if (regresando)
        {
            Debug.Log("Regresando UPDATE");
            RegresarPlaneta();
        }

        // Si el audio ha terminado, comienza el regreso
        if (audioSource != null && !audioSource.isPlaying && acercando)
        {
            regresando = true;
        }
    }

    public void ComenzarAcercamiento(Transform planetaSeleccionado)
    {
        planetaElegido = planetaSeleccionado;
        posicionOriginal = planetaElegido.position;  // Guarda la posición original del planeta
        Debug.Log(posicionOriginal);
        acercando = true;  // Comienza el acercamiento
        regresando = false;  // Asegúrate de que no esté regresando
    }

    // Mueve la cámara o el planeta seleccionado hacia el centro
    private void AcercarPlaneta()
    {

        Debug.Log("AcercarPlaneta");
        Vector3 objetivo = cameraTransform.position + new Vector3(0, 8, -distanciaDeAcercamiento);  // Establece la posición objetivo cerca de la cámara

        // Mueve el planeta suavemente hacia la cámara
        planetaElegido.position = Vector3.Lerp(planetaElegido.position, objetivo, velocidad * Time.deltaTime);

        // Si el planeta está suficientemente cerca de la cámara, para el movimiento
        if (Vector3.Distance(planetaElegido.position, objetivo) < 0.1f)
        {
            acercando = false;
        }
    }

    public void RegresarPlaneta()
    {   
        acercando = false;
        // Mueve el planeta de vuelta a su posición original de forma suave con Lerp
        planetaElegido.position = Vector3.Lerp(planetaElegido.position, posicionOriginal, velocidadRegreso * Time.deltaTime);

        Debug.Log("Vector3.Distance(planetaElegido.position, posicionOriginal)");
        Debug.Log(Vector3.Distance(planetaElegido.position, posicionOriginal));

        // Si el planeta ha vuelto a su posición original, detén el movimiento
        if (Vector3.Distance(planetaElegido.position, posicionOriginal) < 2) // Un umbral más pequeño para evitar que no llegue nunca
        {
            Debug.Log("Regresando false");
            planetaElegido.position = posicionOriginal;  // Asegura que llega exactamente
            regresando = false;

            PlanetSelector planetSelector = FindFirstObjectByType<PlanetSelector>();
            planetSelector.ActivarTodos();
        }
    }
    public void ComenzarRegreso()
    {
        regresando = true;  // Comienza el regreso
        acercando = false;  // Asegúrate de que no esté acercando
    }

}
