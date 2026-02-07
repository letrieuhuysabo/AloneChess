using UnityEngine;

public class SoundGameplayController : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip moveSound, landingSound, cantMoveSound;
    [SerializeField] AudioClip gainStarSound;
    [SerializeField] AudioClip reachPortalSound;
    [SerializeField] AudioClip switchPieceSound;
    [SerializeField] AudioClip showCompletePanelSound, showStar1Sound, showStar2Sound, showStar3Sound;
    public static SoundGameplayController instance;

    public AudioSource AudioSource { get => audioSource; set => audioSource = value; }

    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = SoundVolume.currentVolume;
    }
    public void PlayMoveSound()
    {
        audioSource.PlayOneShot(moveSound);
    }
    public void PlayLandingSound()
    {
        audioSource.PlayOneShot(landingSound);
    }
    public void PlayCantMoveSound()
    {
        audioSource.PlayOneShot(cantMoveSound);
    }
    public void PlayGainStarSound()
    {
        audioSource.PlayOneShot(gainStarSound);
    }
    public void PlaySwitchPieceSound()
    {
        audioSource.PlayOneShot(switchPieceSound);
    }
    public void PlayShowCompletePanelSound()
    {
        audioSource.PlayOneShot(showCompletePanelSound);
    }
    public void PlayShowStar1Sound()
    {
        audioSource.PlayOneShot(showStar1Sound);
    }
    public void PlayShowStar2Sound()
    {
        audioSource.PlayOneShot(showStar2Sound);
    }
    public void PlayShowStar3Sound()
    {
        audioSource.PlayOneShot(showStar3Sound);
    }

}
