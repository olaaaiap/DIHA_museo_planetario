using System.Collections;
using UnityEngine;

public class MovimientoInfinito : MonoBehaviour
{

    public float velocidad = 200f;
    public float minTime = 1f;
    public float maxTime = 4f;
    public GameObject objectPrefab;

    void Start()
    {
        //Inicializar el pool manager con 10 explosives
        PoolManager.Instance.Load(objectPrefab, 30);
    
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            //Obtener un tiempo random entre el tiempo mínimo y el máximo
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            //Spawnear un explosivo
            var objeto = PoolManager.Instance.Spawn(objectPrefab);
            if (objeto)
            {
                float spawnX = transform.position.x - 30f; // 50 unidades delante de la nave
                float spawnY = Random.Range(-5f, 15f);     // altura aleatoria
                float spawnZ = Random.Range(-20f, 20f);   // ligeramente variado para profundidad

                objeto.transform.position = new Vector3(spawnX, spawnY, spawnZ);


            }
        }
    }
}
