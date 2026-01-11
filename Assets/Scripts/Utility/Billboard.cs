using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera cam;
    private Renderer renderingComponent;

    private void Start()
    {
        cam = Camera.main;
        renderingComponent = GetComponent<Renderer>();

    }
    public void Update()
    {
        if (renderingComponent != null && !renderingComponent.isVisible) return;

        if(cam != null)
            this.transform.LookAt(cam.transform);
        else
        {
            cam = Camera.main;
        }
    }
}
