
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRButtonSound : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator mercurioAnimator;


    public void PlaySound()
    {
        if (audioSource != null)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                mercurioAnimator.enabled = false;
            }
            else
            {
                SeleccionarPlaneta seleccionarPlaneta = FindFirstObjectByType<SeleccionarPlaneta>();
                if (seleccionarPlaneta != null)
                {
                    seleccionarPlaneta.AcceptPlanet();
                }
                audioSource.Play();
                mercurioAnimator.enabled = true;
                mercurioAnimator.Play("mercuryMovement");

            }
        }
    }

    public void OnSelected()
    {
        PlaySound();
    }

}
