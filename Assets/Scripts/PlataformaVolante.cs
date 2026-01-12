using UnityEngine;

public class PlataformaVolante: MonoBehaviour
{
    public Transform destinoMercurio; // Lugar donde quieres que vaya el usuario
    public Transform player; // Lugar donde quieres que vaya el usuario
    public float alturaUsuario = 1f; // Altura del usuario para que no quede bajo la plataforma

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que tu VR rig tenga el tag "Player"
        {
            StartCoroutine(MoverUsuario(player));
        }
    }

    private System.Collections.IEnumerator MoverUsuario(Transform player)
    {
        // Guardamos la posición inicial
        CharacterController cc = player.GetComponent<CharacterController>();
        Vector3 startPos = player.position;
        Vector3 endPos = destinoMercurio.position + Vector3.up * alturaUsuario;
        Debug.Log(destinoMercurio.position);
        Debug.Log(endPos);
        yield return null;
        cc.enabled = false; // desactivar temporalmente para mover manualmente
        player.position = endPos;
        cc.enabled = true; // volver a activar
    }
}
