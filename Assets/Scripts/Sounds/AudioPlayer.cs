using UnityEngine;

public class AudioPlayer : Singleton<AudioPlayer>
{
    [SerializeField, Space(10)]
    private AudioSource backgroundSound;
                       
    public void LowerVolume()
    {
        backgroundSound.volume -= backgroundSound.volume / 1.5f;
    }
}
