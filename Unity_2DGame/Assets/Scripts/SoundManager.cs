using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// 音效來源：喇叭
    /// </summary>
    private AudioSource aud;

    private void Start()
    {
        // 音效來源 = 取得元件<音效來源>()
        aud = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 播放指定音效
    /// </summary>
    /// <param name="sound">想要播放的音效</param>
    public void PlaySound(AudioClip sound)
    {
        aud.PlayOneShot(sound);     // 音效來源.播放一次(音效)
    }

    /// <summary>
    /// 播放背景音樂
    /// </summary>
    /// <param name="sound">想要播放的背景音效</param>
    /// <param name="loop">是否循環</param>
    public void PlayBGM(AudioClip sound, bool loop) 
    {
        aud.clip = sound;       // 音效來源.片段 = 參數背景音樂
        aud.loop = loop;        // 音效來源.循環 = 參數循環
        aud.Play();             // 音效來源.播放()
    }
}
