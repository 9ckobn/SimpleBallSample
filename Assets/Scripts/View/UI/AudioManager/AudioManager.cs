using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip ObstaclePassSound;
    public AudioClip DefeatedSound;
    public AudioClip UIClicked;

    AudioSource source;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        source = GetComponent<AudioSource>();

        Game.AudioHandler = this;
    }

    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
