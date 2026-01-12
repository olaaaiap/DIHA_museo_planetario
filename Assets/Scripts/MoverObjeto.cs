using UnityEngine;

public class MoverObjeto : MonoBehaviour
{
    public float velocidad = 200f;
    public float distanciaMin = 2f;  
    public float velocidadEsquivo = 50f; 
    private Transform nave;

    private void Start()
    {
        GameObject naveObj = GameObject.FindWithTag("Nave");
        if (naveObj != null)
            nave = naveObj.transform;
    }
    void Update()
    {
        if (nave != null)
        {
            // Vector hacia la nave
            Vector3 direccionNave = nave.position - transform.position;

            if (direccionNave.magnitude < distanciaMin)
            {
                // alejarse de la nave para no chocar
                transform.position -= direccionNave.normalized * velocidadEsquivo * Time.deltaTime;
            }
            else
            {
                // movimiento normal hacia la derecha
                transform.Translate(Vector3.right * velocidad * Time.deltaTime);
            }
        }
        else
        {
            // Si no hay nave, se mueve normalmente
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }


        if (transform.position.x > 10f) 
        {
            PoolManager.Instance.Despawn(gameObject);
        }
    }



}


