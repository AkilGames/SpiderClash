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
        LevelManager.Instance.LoadNextLevel();
    }

    public void AddStar()
    {
        if (starsCount < 3)
            starsCount++;
    }

    public void LoseLevel()
    {
        SoundManager.Instance.PlaySound("Lose");
        LevelManager.Instance.Restart();
    }
}