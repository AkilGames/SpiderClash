using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    Toggle t;

    void Start()
    {
        t = GetComponent<Toggle>();
        t.isOn = !(SoundManager.Instance.IsMusicOn = PlayerPreferences.IsMusicOn);
    }

    public void OnClick()
    {
        PlayerPreferences.IsMusicOn = SoundManager.Instance.IsMusicOn = !t.isOn;
    }
}