using UnityEngine;
using UnityEngine.UI;

public class VolumeMenu : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("VolumeGlobal", 1f);

        slider.onValueChanged.AddListener((v) =>
        {
            AudioManager.Instance.SetVolume(v);
        });
    }
}
