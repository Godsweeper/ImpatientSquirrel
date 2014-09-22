using UnityEngine;
using System.Collections;

public class AudioManager : MonoSingleton<AudioManager> 
{

    public bool musicOn = true, sfxOn = true, pNOn = true;
    public Transform Audio;
    public AudioSource backgroundMusic;
    public bool backgroundPlaying;

    public void DontDestroyOnLoad()
    {
        DontDestroyOnLoad(Audio.gameObject);
    }

    void Update()
    {
        if (musicOn == false)
        {
            backgroundMusic.mute = true;
        }
        if (sfxOn == false)
        {
            
        }        
    }
}
