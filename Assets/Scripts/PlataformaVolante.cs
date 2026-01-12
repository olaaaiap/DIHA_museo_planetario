using UnityEngine;
using UnityEngine.InputSystem;

public class PlataformaVolante : MonoBehaviour
{
    [Header("Velocidad de vuelo")]
    public float velocidad = 2f;

    [Header("Input Actions")]
    public InputActionProperty moveAction; // joystick principal
    public InputActionProperty ascendAction; // opcional: subir/bajar

    private void Update()
    {
        // Leer joystick
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        // Movimiento relativo a la cámara
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 movimiento = forward * input.y + right * input.x;

        // Subida/bajada opcional
        if (ascendAction != null)
        {
            float ascend = ascendAction.action.ReadValue<float>();
            movimiento += Vector3.up * ascend;
        }

        // Mover la plataforma
        transform.position += movimiento * velocidad * Time.deltaTime;
    }
}
