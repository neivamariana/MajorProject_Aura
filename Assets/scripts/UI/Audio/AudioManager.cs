using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource ambienceSource;
    [SerializeField] private AudioSource sfxSource;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;

        if (musicSource.clip == clip) return;

        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlayAmbience(AudioClip clip)
    {
        if (clip == null) return;

        if (ambienceSource.clip == clip) return;

        ambienceSource.clip = clip;
        ambienceSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;

        sfxSource.PlayOneShot(clip);
    }

    public void PlayRandomMusic(AudioClip[] clips)
    {
        if (clips == null || clips.Length == 0) return;

        int index = Random.Range(0, clips.Length);
        PlayMusic(clips[index]);

    }

    public void PlayRandomAmbience(AudioClip[] clips)
    {
        if(clips == null || clips.Length == 0) return;

        int index = Random.Range(0, clips.Length);
        PlayAmbience(clips[index]);

    }

    

    public void PlayRandomSFX(AudioClip[] clips)
    {
        if(clips == null || clips.Length == 0) return;

        int index = Random.Range(0, clips.Length);
        PlaySFX(clips[index]);

    }

}
