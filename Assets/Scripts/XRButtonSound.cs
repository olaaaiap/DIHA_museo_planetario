
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRButtonSound : MonoBehaviour
{
    public AudioSource audioSource; 

    public void PlaySound()
    {
        if (audioSource != null)
        {
            if(audioSource.isPlaying)
                audioSource.Stop();
            audioSource.Play();
        }
    }
}
