using UnityEngine;

public class GamePanel : PanelBehaviour
{
    public override void Hide()
    {
        base.Hide();
        LevelManager.Instance.UnLoad();
    }

    public void OnRestartClick()
    {
        SoundManager.Instance.PlaySound("Click");
        LevelManager.Instance.Restart();    
    }
}