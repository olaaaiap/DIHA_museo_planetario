
using Unity.XR.CoreUtils;
using UnityEngine;


public class AcercarPlaneta : MonoBehaviour
{
    [SerializeField] private Transform objetivoTransform;  //Objetivo a donde el planeta seleccionado se acercará
    [SerializeField] private float velocidad = 1f;  //Velocidad en el que el planeta se acercará
    [SerializeField] private float distanciaDeAcercamiento = 10f;  //Distancia (eje Z) desde el objetivo donde se quedará el planeta 
    [SerializeField] private AudioSource audioSource;  //Audio source que reproducirá la explicación del planeta seleccionado
    [SerializeField] private Animator planetAnimator; //Animación de rotación (en su propio eje) del planeta seleccionado


    private bool acercando = false; //Variable para controlar si el planeta se está acercando
    private bool planetaEnPosicion = false; //Variable para controlar si el planeta está en la posición objetivo
    private bool regresando = false; //Variable para controlar si el planeta está regresando a su posición original
    private Transform planetaElegido; //Transform del planeta seleccionado
    private Vector3 posicionOriginal; //Posición original del planeta seleccionado

    


    void Update()
    {
        if (acercando)
        {
            AcercarPlanetaMovimiento();
        }
        else if (regresando)
        {
            RegresarPlaneta();
        }

        // Si el audio ha terminado, comienza el regreso
        if (audioSource != null && !audioSource.isPlaying && (planetaEnPosicion||acercando))
        {
            ComenzarRegreso();
        }
    }

    //Función que comenzará el acercamiento del planeta al objetivo (audio y animación)
    public void ComenzarAcercamiento(Transform planetaSeleccionado)
    {
        //Si se llama a esta función mientras el audio se está reproduciendo, no hacer nada
        if (audioSource.isPlaying) {
            return;
        }

        planetaElegido = planetaSeleccionado;
        posicionOriginal = planetaElegido.position;  
        
        acercando = true;  
        regresando = false;  

        //Reproducir audio de la explicación
        if (audioSource != null)
        {
            audioSource.Play();
        }

        //Empezar animación de rotación
        planetAnimator.enabled = true;
        planetAnimator.Play("planetRotation");
    }

    //Función que hará el movimiento del acercamiento
    private void AcercarPlanetaMovimiento()
    {
        //Posicionar el planeta cerca del objetivo, usando Lerp para un movimiento suave
        Vector3 objetivo = objetivoTransform.position + new Vector3(0, 8, -distanciaDeAcercamiento);
        planetaElegido.position = Vector3.Lerp(planetaElegido.position, objetivo, velocidad * Time.deltaTime);
    }

    //Función que hará el movimiento de regreso
    public void RegresarPlaneta()
    {
        acercando = false;
        //Mover el planeta en su posición inicial usando Lerp para un movimiento suave
        planetaElegido.position = Vector3.Lerp(planetaElegido.position, posicionOriginal, velocidad * Time.deltaTime);

        //Si el planeta ha vuelto a su posición inicial, detener el  regreso y activar los demás planetas
        if (Vector3.Distance(planetaElegido.position, posicionOriginal) < 2) // Un umbral más pequeño para evitar que no llegue nunca
        {
            planetaElegido.position = posicionOriginal;
            regresando = false;
            audioSource.Stop();
            planetAnimator.enabled = false;
            SeleccionarPlaneta seleccionarPlaneta = FindFirstObjectByType<SeleccionarPlaneta>();
            seleccionarPlaneta.ActivarTodos();

        }
    }

    //Función que actualiza las variables privadas para que empiece el regreso
    public void ComenzarRegreso()
    {
        planetaEnPosicion = false;
        regresando = true;
        acercando = false;
    }

}
