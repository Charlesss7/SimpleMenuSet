using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerGroupVolume : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] string param;
    [SerializeField,Range(-80,0f)] float volume;

    private void Update()
    {
        audioMixer.SetFloat(param,volume);
    }

    public void ShowVolume(AudioSource audio)
    {
        Debug.Log("Audio: "+audio.volume);
    }
}
