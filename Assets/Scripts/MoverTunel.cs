using UnityEngine;

public class MoverTunel : MonoBehaviour
{
    [SerializeField] private float velocidad = 50f; //Velocidad del movimiento del tunel

    void Update()
    {
        //Mover el tunel hacia x positivo
        transform.Translate(Vector3.right * velocidad * Time.deltaTime, Space.World);
    }
}



