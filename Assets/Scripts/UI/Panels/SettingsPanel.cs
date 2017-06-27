using UnityEngine.UI;

public class SettingsPanel : PanelBehaviour
{
    public Slider sound, music;
    public Text language;

    string[] strings = { "Eng", "Рус", "Укр", "Deu" };

    void Start()
    {
        sound.value = PlayerPreferences.SoundVolume;
        music.value = PlayerPreferences.MusicVolume;
        language.text = strings[(int)LanguageManager.Instance.Language];
    }

    public override void Hide()
    {
        base.Hide();
        PlayerPreferences.MusicVolume = music.value;
        PlayerPreferences.SoundVolume = sound.value;
    }

    public void SetSound()
    {
        SoundManager.Instance.soundVolume = sound.value;
    }

    public void SetMusic()
    {
        SoundManager.Instance.MusicVolume = music.value;
    }

    public void ChangeLanguage()
    {
        SoundManager.Instance.PlaySound("Click");
        LANGUAGE lang = LanguageManager.Instance.Language;
        lang = lang == LANGUAGE.DE ? LANGUAGE.ENG : lang + 1;
        language.text = strings[(int)(LanguageManager.Instance.Language = lang)];
        PlayerPreferences.Language = lang;
    }
}