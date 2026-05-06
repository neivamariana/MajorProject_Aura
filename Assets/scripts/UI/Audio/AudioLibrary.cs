using UnityEngine;

[CreateAssetMenu(fileName = "AudioLibrary", menuName = "Scriptable Objects/AudioLibrary")]
public class AudioLibrary : ScriptableObject
{

    [Header("Music")]
    public AudioClip[] music;

    [Header("Ambience")]
    public AudioClip[] ambience;


    [Header("SFX")]
    public AudioClip[] sfx;


}
