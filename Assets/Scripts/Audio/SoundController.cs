using UnityEngine;

public class SoundController : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip hoverSound, clickSound;
    public static SoundController instance;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayHoverSound()
    {
        audioSource.PlayOneShot(hoverSound);
    }
    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
