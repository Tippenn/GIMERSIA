using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : PersistentSingleton<AudioManager>
{
    [Header("Mixer")]
    public AudioMixer mixer;
    [SerializeField] private string masterVolumeParam = "MasterParam";
    [SerializeField] private string bgmVolumeParam = "BGMParam";
    [SerializeField] private string sfxVolumeParam = "SFXParam";
    [SerializeField] private string fileLocation = "AudioSettings";

    [Header("Source")]
    public AudioSource BGM;
    public AudioSource SFX;

    [Header("Clip")]
    [Header("BGM")]
    [Header("SFX")]
    public bool biarGaError;


    public string FileLocation => fileLocation;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        LoadAudioSettings();
    }

    public void LoadAudioSettings()
    {
        SaveObject_VolumeSettings audio_SaveObject = SaveSystem.LoadObject<SaveObject_VolumeSettings>(fileLocation);
        if (audio_SaveObject != null)
        {
            Debug.Log("Audio Setting Loaded\n" +
                    "Master: " + audio_SaveObject.masterVolume +
                    "\nBGM: " + audio_SaveObject.BGMVolume +
                    "\nSFX: " + audio_SaveObject.SFXVolume);
            SetMasterVolume(audio_SaveObject.masterVolume);
            SetBGMVolume(audio_SaveObject.BGMVolume);
            SetSFXVolume(audio_SaveObject.SFXVolume);
        }
        else
        {
            Debug.Log("Audio not found");
            SetMasterVolume(1f);
            SetBGMVolume(1f);
            SetSFXVolume(1f);
        }
    }

    public void PlaySFXOneShot(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
    public void PauseBGM()
    {
        BGM.Pause();
    }
    public void UnPauseBGM()
    {
        BGM.UnPause();
    }
    public void ChangeBGM(AudioClip audioClip)
    {
        if (BGM.clip == audioClip) return;

        BGM.clip = audioClip;
        BGM.Play();
    }

    public void SetVolume(string parameter, float normalizedVolume) // 0–1 range
    {
        float dB;
        if (normalizedVolume == 0f)
        {
            dB = -80f;
        }
        else
        {
            dB = Mathf.Log10(normalizedVolume) * 20; // Convert to decibels
        }
        mixer.SetFloat(parameter, dB);
    }

    public void SetMasterVolume(float value) => SetVolume(masterVolumeParam, value);
    public void SetBGMVolume(float value) => SetVolume(bgmVolumeParam, value);
    public void SetSFXVolume(float value) => SetVolume(sfxVolumeParam, value);
}

