public class AchievementsPanel : PanelBehaviour
{
    public AchievementButton[] achievements;

    public override void Show()
    {
        base.Show();
        for (int i = 0; i < achievements.Length; i++)
            achievements[i].SetState(PlayerAchievements.Instance[i]);
    }
}