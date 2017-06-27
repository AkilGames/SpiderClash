public class LanguageManager
{
    LANGUAGE language = LANGUAGE.ENG;
    LanguageStringsCollection collection = null;

    public event System.Action onLanguageChanged;

    static LanguageManager instance = null;
    public static LanguageManager Instance
    {
        get
        {
            if (instance == null)
                instance = new LanguageManager();
            return instance;
        }
    }

    private LanguageManager()
    {
        Load();
        instance = this;
    }

    public string GetString(string name)
    {
        return collection[language].ContainsKey(name) ? collection[language][name] : "";
    }

    public LANGUAGE Language
    {
        get
        {
            return language;
        }
        set
        {
            language = value;
            if (onLanguageChanged != null)
                onLanguageChanged();
        }
    }

    void Load()
    {
        collection = new LanguageStringsCollection();
        Language = PlayerPreferences.Language;
    }
}