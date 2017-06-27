using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum MENUSTATE : byte { MAIN, ACHIEVEMENTS, SETTINGS, ABOUT, CHOOSE_LEVEL, IN_GAME }

public class MenuManager : MonoBehaviour
{
    public PanelBehaviour main, achievements, settings, about, chooseLevel, game;
    public Image fade;
    public GameObject backButton, background;
    public float fadingTime = 2.0f;

    MENUSTATE menuState;
    MENUSTATE? previousMenuState = null;

    static MenuManager instance = null;
    public static MenuManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<MenuManager>();
                instance.Init();
            }
            return instance;
        }
    }

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Init();
        instance = this;
    }

    void Init()
    {
        MenuState = MENUSTATE.MAIN;
    }

    void Update()
    {
        if (menuState == MENUSTATE.IN_GAME)
            return;
        if (Input.GetKeyUp(KeyCode.Escape))
            Back();
    }

    IPanel this[MENUSTATE state]
    {
        get
        {
            switch (state)
            {
                case MENUSTATE.MAIN:
                    return main;
                case MENUSTATE.ACHIEVEMENTS:
                    return achievements;
                case MENUSTATE.SETTINGS:
                    return settings;
                case MENUSTATE.ABOUT:
                    return about;
                case MENUSTATE.CHOOSE_LEVEL:
                    return chooseLevel;
                case MENUSTATE.IN_GAME:
                    return game;
            }
            return null;
        }
    }

    public MENUSTATE MenuState
    {
        get
        {
            return menuState;
        }
        set
        {
            if (previousMenuState.HasValue)
            {
                if (value == menuState)
                    return;
                this[menuState].Hide();
                this[value].Show();
            }
            else
                this[value].Show();
            previousMenuState = menuState;
            menuState = value;
            backButton.SetActive(menuState != MENUSTATE.MAIN);
            background.SetActive(menuState != MENUSTATE.IN_GAME);
        }
    }

    public void Back()
    {
        SoundManager.Instance.PlaySound("Click");
        if (!previousMenuState.HasValue || MenuState == MENUSTATE.MAIN)
        {
            fade.gameObject.SetActive(true);
            fade.DOFade(1.0f, fadingTime).SetEase(Ease.Linear).OnComplete(Application.Quit);
            enabled = false;
        }
        else if (MenuState == MENUSTATE.CHOOSE_LEVEL)
            MenuState = MENUSTATE.MAIN;
        else
            MenuState = previousMenuState.Value;
    }
}