using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{


    private AudioSource audioSrc;


    public Slider volSlider;
    GameObject MusicObject;

    private void OnEnable()
    {
        MusicObject = GameObject.FindWithTag("MusicPlayer");


        audioSrc = MusicObject.GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("Volume"))
        {
            volSlider.value = audioSrc.volume = 0.2f;

        }
        else
        {
            volSlider.value = PlayerPrefs.GetFloat("Volume");
            audioSrc.volume = volSlider.value;
        }

    }

    public void OnDrag()
    {
        audioSrc.volume = volSlider.value;
        PlayerPrefs.SetFloat("Volume", volSlider.value);
        PlayerPrefs.Save();

    }



}
