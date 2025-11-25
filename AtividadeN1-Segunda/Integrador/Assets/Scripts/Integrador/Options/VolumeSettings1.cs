using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider musicaSlider;
    [SerializeField] private Sprite bolinhaSpriteZero;    
    [SerializeField] private Sprite bolinhaSprite;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicaVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }
        
    }
    private void LoadVolume()
    {
        musicaSlider.value = PlayerPrefs.GetFloat("MusicaVolume");

        SetMusicVolume();
    }
    public void SetMusicVolume()
    {
        float volume = musicaSlider.value;
        mixer.SetFloat("Musica", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("MusicaVolume",volume);
        if (musicaSlider.handleRect != null)
        {
            Image bolinhaImagem = musicaSlider.handleRect.GetComponent<Image>();
            if (bolinhaImagem != null)
            {
              
                if (Mathf.Approximately(volume, 0f))
                    bolinhaImagem.sprite = bolinhaSpriteZero;
                else
                    bolinhaImagem.sprite = bolinhaSprite;
            }
        }
    }
   
}
