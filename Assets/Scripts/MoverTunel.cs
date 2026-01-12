using UnityEngine;

public class MoverTunel : MonoBehaviour
{

    public float velocidad = 50f; // unidades por segundo

    void Update()
    {
        // mover el túnel hacia la nave en X negativo
        transform.Translate(Vector3.right * velocidad * Time.deltaTime, Space.World);
    }
}



