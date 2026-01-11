
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
                PlanetSelector planetSelector = FindFirstObjectByType<PlanetSelector>();
                if (planetSelector != null)
                {
                    planetSelector.FinishExplanation();
                }
            }
            else
            {
                PlanetSelector planetSelector = FindFirstObjectByType<PlanetSelector>();
                if (planetSelector != null)
                {
                    planetSelector.AcceptPlanet();
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
