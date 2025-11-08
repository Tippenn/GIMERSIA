using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;
    public void OnEnable()
    {
        LoadAudio();
    }

    public void OnDisable()
    {
        SaveAudio();
    }

    public void LoadAudio()
    {
        SaveObject_VolumeSettings volumeSave = SaveSystem.LoadObject<SaveObject_VolumeSettings>(AudioManager.Instance.FileLocation);
        if(volumeSave != null)
        {
            masterSlider.value = volumeSave.masterVolume;
            bgmSlider.value = volumeSave.BGMVolume;
            sfxSlider.value = volumeSave.SFXVolume;
        }
        else
        {
            masterSlider.value = 1f;
            bgmSlider.value = 1f;
            sfxSlider.value = 1f;
        }
        
    }

    public void SaveAudio()
    {
        SaveObject_VolumeSettings volumeSave = new SaveObject_VolumeSettings();
        volumeSave.masterVolume = masterSlider.value;
        volumeSave.BGMVolume = bgmSlider.value;
        volumeSave.SFXVolume = sfxSlider.value;
        SaveSystem.SaveObject(AudioManager.Instance.FileLocation, volumeSave);
    }

    public void Slider_MasterVolume(float value)
    {
        AudioManager.Instance.SetMasterVolume(value);
    }

    public void Slider_BGMVolume(float value)
    {
        AudioManager.Instance.SetBGMVolume(value);
    }

    public void Slider_SFXVolume(float value)
    {
        AudioManager.Instance.SetSFXVolume(value);
    }
}
