using System.Collections;
using UnityEngine;

public class TeletransportePlanetas : MonoBehaviour
{
    public GameObject playerRig;   // Tu XR Rig
    public Transform targetPlanet; // El planeta elegido
    public float teleportDuration = 1.5f; // Tiempo de animación
        private CharacterController characterController;

    public void OnTriggerEnter()
    {
        StartCoroutine(TeleportSmooth());
    }

    private void Start()
    {
        characterController = playerRig.GetComponent<CharacterController>();
    }
    private IEnumerator TeleportSmooth()
    {
        Vector3 startPos = playerRig.transform.position;
        Vector3 endPos = targetPlanet.position + Vector3.up * 5f; // Altura sobre el planeta
        Debug.Log(targetPlanet.position);
        Debug.Log(endPos);

        // Calculamos la posición final ajustando la altura del CharacterController
        float heightOffset = 0f;
        if (characterController != null)
            heightOffset = characterController.height / 2f;

        Vector3 endPos = targetPlanet.position + Vector3.up * heightOffset;

        //float elapsed = 0f;

        //while (elapsed < teleportDuration)
        //{
        //    playerRig.transform.position = Vector3.Lerp(startPos, endPos, elapsed / teleportDuration);
        //    elapsed += Time.deltaTime;
        //    yield return null;
        //}
        yield return null;
        // Aseguramos que termina en la posición correcta
        playerRig.transform.position = endPos;
    }
}


