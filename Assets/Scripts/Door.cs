using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool opened;

    [SerializeField] private Animator anim;

    public void OpenDoor()
    {
        if (opened) return;
        opened = true;
        anim.SetBool("Open", true);

        StartCoroutine(CloseDoorCoroutine());
    }

    public void CloseDoor()
    {
        opened = false;
        anim.SetBool("Open", false);
    }

    private IEnumerator CloseDoorCoroutine()
    {
        yield return new WaitForSeconds(3);

        CloseDoor();
    }
}
