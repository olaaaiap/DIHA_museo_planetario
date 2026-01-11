using UnityEngine;

public class RotacionPlanetas : MonoBehaviour
{
    public Transform center;
    public float speed = 20f; // grados por segundo

    void LateUpdate()
    {
        transform.RotateAround(
            center.position,
            Vector3.up,
            speed * Time.deltaTime
        );
    }
}
