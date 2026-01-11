using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VRInteractor : MonoBehaviour
{
    public Transform rayStart;
    public LineRenderer lineRenderer; // Arrastra el Line Renderer aquí
    public float rayDistance = 200f;

    void Update()
    {
        Vector3 origin = rayStart.position;
        Vector3 direction = rayStart.forward;

        RaycastHit hitInfo;
        Vector3 endPosition = origin + direction * rayDistance;

        if (Physics.Raycast(origin, direction, out hitInfo, rayDistance))
        {
            endPosition = hitInfo.point; // rayo termina en el objeto
            Debug.Log("hit");

            // Verifica si el objeto tiene el script XRButtonSound
            XRButtonSound buttonSound = hitInfo.transform.GetComponent<XRButtonSound>();
            if (buttonSound != null)
            {
                // Si existe, llama a la función PlaySound()
                buttonSound.PlaySound();
            }
        }

        // Actualiza Line Renderer
        lineRenderer.SetPosition(0, origin);
        lineRenderer.SetPosition(1, endPosition);
    }
}
