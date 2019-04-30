using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetAudioLevel(float amount = 0.5f)
    {
        mixer.SetFloat("MasterAudioVolume", Mathf.Log10(amount) * 20);
    }
}
