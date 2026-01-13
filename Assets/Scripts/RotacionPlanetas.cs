using UnityEngine;

public class RotacionPlanetas : MonoBehaviour
{
    [SerializeField] private Transform centro; //Centro de rotación
    [SerializeField] private float velocidad = 20f; //Grados por segundo

    void LateUpdate()
    {
        //Rota el planeta alrededor de un centro en el eje Y a una velocidad constante
        transform.RotateAround(centro.position, Vector3.up, velocidad * Time.deltaTime); 
    }
}
