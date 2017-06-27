using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource music;
    AudioClip[] soundsCache;
    bool isReady = false;

    public bool IsMusicOn
    {
        get
        {
            return !music.mute;
        }
        set
        {
            music.mute = !value;
        }
    }

    public float MusicVolume
    {
        get
        {
            return music.volume;
        }
        set
        {
            music.volume = value;
        }
    }
    
    public float soundVolume { get; set; }
    public bool IsReady { get; private set; }

    static SoundManager instance = null;
    public static SoundManager Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject temp = new GameObject("SoundManager", typeof(SoundManager));
                instance = temp.GetComponent<SoundManager>();
                instance.Init();
            }
            return instance;
        }
    }

    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        Init();
    }

    void Init()
    {
        if (isReady)
            return;
        isReady = true;
        soundsCache = Resources.LoadAll<AudioClip>("Sounds");
        music = gameObject.AddComponent<AudioSource>();
        music.loop = true;
        music.clip = FindByName("Background");
        music.mute = !PlayerPreferences.IsMusicOn;
        soundVolume = PlayerPrefs.GetFloat("SoundVolume", 1.0f);
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        music.Play();
    }

    public void PlaySound(string name)
    {
        AudioSource.PlayClipAtPoint(FindByName(name), Camera.main.transform.position, soundVolume);
    }

    AudioClip FindByName(string name)
    {
        for (int i = 0; i < soundsCache.Length; i++)
            if ((soundsCache[i]).name.Equals(name))
                return soundsCache[i];
        return null;
    }
}