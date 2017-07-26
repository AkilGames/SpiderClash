using UnityEngine;

public class LevelController : MonoBehaviour
{
    public byte pack;
    public byte level;

    byte starsCount = 0;

    public static LevelController Current { get; private set; }

    void Start()
    {
        Current = this;
    }

    public void CompleteLevel()
    {
        SoundManager.Instance.PlaySound("Win");
        if (starsCount > PlayerPrefs.GetInt(string.Format("Level{0:d2}-{1:d2}Stars", pack, level), 0))
        {
            PlayerPrefs.SetInt(string.Format("Level{0:d2}-{1:d2}Stars", pack, level), starsCount);
            PlayerPrefs.Save();
        }
        #region Take Achievements
        int starCount = 0;

        for (byte pack = 0; pack < LevelManager.packsCount; pack++)
            for (byte level = 0; level < LevelManager.countInPack; level++)
                starCount += PlayerPrefs.GetInt(string.Format("Level{0:d2}-{1:d2}Stars", pack, level), 0);

        if(starCount >= 3)
        {
            if (!PlayerAchievements.Instance[(byte)Achievements.ThreeStars])
                PlayerAchievements.Instance[(byte)Achievements.ThreeStars] = true;
            if (starCount >= 9)
            {
                if (!PlayerAchievements.Instance[(byte)Achievements.NineStars])
                    PlayerAchievements.Instance[(byte)Achievements.NineStars] = true;
                if (starCount >= 25)
                {
                    if (!PlayerAchievements.Instance[(byte)Achievements.TwentyFiveStars])
                        PlayerAchievements.Instance[(byte)Achievements.TwentyFiveStars] = true;
                    if (starCount >= LevelManager.packsCount * LevelManager.countInPack * 3)
                    {
                        if (!PlayerAchievements.Instance[(byte)Achievements.AllStars])
                            PlayerAchievements.Instance[(byte)Achievements.AllStars] = true;
                    }
                }
            }
        }

        if (level == 1)
            if (!PlayerAchievements.Instance[(byte)Achievements.OneLevel])
                PlayerAchievements.Instance[(byte)Achievements.OneLevel] = true;
        if (level == 3)
            if (!PlayerAchievements.Instance[(byte)Achievements.ThreeLevels])
                PlayerAchievements.Instance[(byte)Achievements.ThreeLevels] = true;
        if (level == 5)
            if (!PlayerAchievements.Instance[(byte)Achievements.FiveLevels])
                PlayerAchievements.Instance[(byte)Achievements.FiveLevels] = true;
        if (level == 10)
            if (!PlayerAchievements.Instance[(byte)Achievements.TenLevels])
                PlayerAchievements.Instance[(byte)Achievements.TenLevels] = true;
        if (level == LevelManager.countInPack * LevelManager.packsCount)
            if (!PlayerAchievements.Instance[(byte)Achievements.AllLevels])
                PlayerAchievements.Instance[(byte)Achievements.AllLevels] = true;
        #endregion
        LevelManager.Instance.LoadNextLevel();
    }

    public void AddStar()
    {
        if (starsCount < 3)
            starsCount++;
    }

    public void LoseLevel()
    {
        if (!PlayerAchievements.Instance[(byte)Achievements.FirstLose])
            PlayerAchievements.Instance[(byte)Achievements.FirstLose] = true;
        SoundManager.Instance.PlaySound("Lose");
        LevelManager.Instance.Restart();
    }
}