using UnityEngine;

public class SoundController : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip hoverSound, clickSound;
    public static SoundController instance;

    public AudioSource AudioSource { get => audioSource; set => audioSource = value; }

    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = SoundVolume.currentVolume;
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
