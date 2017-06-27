using UnityEngine;
using UnityEngine.UI;

public class ChooseLevelPanel : PanelBehaviour
{
    public Text starStatistics;
    public Scrollbar scroll;
    public GameObject commingSoonPanel;
    public LevelButton[] buttons;

    byte pack = 0, prevPack;

    void Start()
    {
        LevelManager.Instance.onFinished += () =>
        {
            commingSoonPanel.SetActive(true);
        };
    }

    public override void Show()
    {
        base.Show();
        if (PlayerPrefs.GetInt(string.Format("Level01-01Unlocked"), 0) == 0)
            PlayerPrefs.SetInt(string.Format("Level01-01Unlocked"), 1);
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].Load();
        int stars = 0;
        for (byte pack = 0; pack < LevelManager.packsCount; pack++)
            for (byte level = 0; level < LevelManager.countInPack; level++)
                stars += PlayerPrefs.GetInt(string.Format("Level{0:d2}-{1:d2}Stars", pack, level), 0);
        int total = LevelManager.packsCount * LevelManager.countInPack * 3;
        starStatistics.text = string.Format("{0}/{1}", stars, total);
    }

    public override void Hide()
    {
        base.Hide();
        commingSoonPanel.SetActive(false);
    }

    public void OnPackSelect()
    {
        prevPack = pack;
        if (scroll.value < 0.25f)
            pack = 0;
        else if (scroll.value > 0.75f)
            pack = 2;
        else
            pack = 1;
        if (prevPack != pack)
            SoundManager.Instance.PlaySound("Click");
    }

    public void OnCommingSoonPanelClick()
    {
        SoundManager.Instance.PlaySound("Click");
        commingSoonPanel.SetActive(false);
    }
}