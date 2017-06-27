using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{ 
    public byte pack;
    public byte level;
    public Sprite inactiveStar, activeStar;
    public Image[] stars;

    public void Click()
    {
        SoundManager.Instance.PlaySound("Click");
        MenuManager.Instance.MenuState = MENUSTATE.IN_GAME;
        LevelManager.Instance.LoadLevel(pack, level);
    }

    public void Load()
    {
        int count = PlayerPrefs.GetInt(string.Format("Level{0:d2}-{1:d2}Stars", pack, level), 0);
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].sprite = i < count ? activeStar : inactiveStar;
            stars[i].color = i < count ? Color.white : new Color(1.0f, 1.0f, 1.0f, 100.0f / 255.0f);
        }
        GetComponent<Button>().interactable = PlayerPrefs.GetInt(string.Format("Level{0:d2}-{1:d2}Unlocked", pack, level), 0) == 1;
    }
}