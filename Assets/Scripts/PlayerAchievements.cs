using UnityEngine;

public class PlayerAchievements 
{
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
            PlayerPrefs.SetInt(string.Format("Achievment{0:d2}", number), value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}