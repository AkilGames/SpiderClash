using UnityEngine;

public enum Achievements : byte
{
    OneLevel,
    ThreeLevels,
    FiveLevels,
    TenLevels,
    AllLevels,
    ThreeStars,
    NineStars,
    TwentyFiveStars,
    AllStars,
    FirstLose,
    //...
}

public class PlayerAchievements 
{
    public event System.Action<Achievements> onTake;

    static PlayerAchievements instance = null;
    public static PlayerAchievements Instance
    {
        get
        {
            if (instance == null)
                instance = new PlayerAchievements();
            return instance;
        }
    }

    private PlayerAchievements() { }

    public bool this[int number]
    {
        get
        {
            return PlayerPrefs.GetInt(string.Format("Achievment{0:d2}", number)) == 1;
        }
        set
        {
            if (PlayerPrefs.GetInt(string.Format("Achievment{0:d2}", number)) == 0 && value)
                if (onTake != null)
                    onTake((Achievements)number);
            PlayerPrefs.SetInt(string.Format("Achievment{0:d2}", number), value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}