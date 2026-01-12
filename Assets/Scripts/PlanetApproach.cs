
using Unity.XR.CoreUtils;
using UnityEngine;

public class PlanetApproach : MonoBehaviour
{
    private bool acercando = false;
    private bool planetaEnPosicion = false;
    private bool regresando = false;
    private Transform planetaElegido;
    private Vector3 posicionOriginal;

    public Transform objetivoTransform;  // Objetico (gameObject vacio)
    public float velocidad = 1f;  // Velocidad de acercamiento
    public float velocidadRegreso = 3f;  // Velocidad de acercamiento
    public float distanciaDeAcercamiento = 10f;  // Distancia a la que el planeta se acerca
    public AudioSource audioSource;  // Componente de AudioSource para el planeta
    public Animator planetAnimator;


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
        if (audioSource != null && !audioSource.isPlaying && (planetaEnPosicion||acercando))
        {
            ComenzarRegreso();
        }
    }

    public void ComenzarAcercamiento(Transform planetaSeleccionado)
    {
        if (audioSource.isPlaying) {
            return;
        }

        planetaElegido = planetaSeleccionado;
        posicionOriginal = planetaElegido.position;  
        
        acercando = true;  
        regresando = false;  

        //Reproducir audio
        if (audioSource != null)
        {
            audioSource.Play();
        }
        planetAnimator.enabled = true;
        planetAnimator.Play("planetRotation");
    }

    private void AcercarPlaneta()
    {
        Vector3 objetivo = objetivoTransform.position + new Vector3(0, 8, -distanciaDeAcercamiento);  // Establece la posición objetivo cerca de la cámara

        planetaElegido.position = Vector3.Lerp(planetaElegido.position, objetivo, velocidad * Time.deltaTime);
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
            audioSource.Stop();
            planetAnimator.enabled = false;
            PlanetSelector planetSelector = FindFirstObjectByType<PlanetSelector>();
            planetSelector.ActivarTodos();

        }
    }
    public void ComenzarRegreso()
    {
        planetaEnPosicion = false;
        regresando = true;  // Comienza el regreso
        acercando = false;  // Asegúrate de que no esté acercando
    }

}
