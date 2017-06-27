using UnityEngine;

public class LevelManager : MonoBehaviour
{
    byte currentLevel = 1;
    byte currentPack = 1;
    GameObject current = null;
    Object currentPrefab = null;
    Transform holder;

    public const byte packsCount = 3;
    public const byte countInPack = 16;

    public event System.Action onFinished;

    static LevelManager instance = null;
    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject temp = new GameObject("LevelManager", typeof(LevelManager));
                instance = temp.GetComponent<LevelManager>();
                instance.holder = GameObject.Find("LocationHolder").transform;
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
        holder = GameObject.Find("LocationHolder").transform;
    }

    public void LoadLevel(byte pack, byte level)
    {
        currentPack = pack;
        currentLevel = level;
        Load();
    }

    public void LoadNextLevel()
    {
        if (currentLevel < countInPack)
            currentLevel++;
        else if (currentPack < packsCount)
        {
            currentLevel = 1;
            currentPack++;
        }
        else
            return;
        PlayerPrefs.SetInt(string.Format("Level{0:d2}-{1:d2}Unlocked", currentPack, currentLevel), 1);
        PlayerPrefs.Save();
        Load();
    }

    public void Restart()
    {
        if (current != null)
        {
            DestroyImmediate(current);
            current = Instantiate((GameObject)currentPrefab, holder);
        }
    }

    void Load()
    {
        if(currentLevel <= countInPack && currentPack <= countInPack)
        {
            if (current != null)
                UnLoad();
            currentPrefab = Resources.Load(string.Format(@"Levels\Pack{0:d2}\Level{1:d2}", currentPack, currentLevel));
            if(currentPrefab == null)
            {
                if (onFinished != null)
                    onFinished();
                MenuManager.Instance.MenuState = MENUSTATE.CHOOSE_LEVEL;
                return;
            }
            current = Instantiate((GameObject)currentPrefab, holder);
        }
    }

    public void UnLoad()
    {
        if (current != null)
        {
            Destroy(current);
            current = null;
            Resources.UnloadUnusedAssets();
            currentPrefab = null;
        }
    }
}