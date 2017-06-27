using UnityEngine;
using UnityEngine.UI;

public class AchievementButton : MonoBehaviour
{
    public LanguageUIElement caption, description;
    public Image secret;
    public byte number;
    public bool isSecret;
    public bool isOpened;
    
    public void Choose()
    {
        SoundManager.Instance.PlaySound("Click");
        if (isSecret && !isOpened)
            return;
        caption.stringName = string.Format("Achievment{0}Caption", number);
        caption.SetLanguage();
        description.stringName = string.Format("Achievment{0}Description", number);
        description.SetLanguage();
    }

    public void SetState(bool isOpened)
    {
        this.isOpened = isOpened;
        GetComponent<Image>().color = isOpened ? Color.white : Color.grey;
        secret.color = !isOpened && isSecret ? Color.white : Color.clear;
        GetComponent<Button>().interactable = !isOpened;
    }
}