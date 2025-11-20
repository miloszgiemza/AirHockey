using UnityEngine;
using UnityEngine.SceneManagement;

using UIMainMenuScene;
using Audio;
using GameSettingsAndSaveSystem;

public enum GameMode
{
    TwoPlayers,
    Computer
}

public enum ScenesIdentifiers
{
    MainMenu,
    Gameplay
}

public enum ControlsType
{
    Snap,
    Swipe
}

public class GameController : MonoBehaviour
{
    public static GameController Instance => instance;

    public ControlsType ControlsType => controlsType;
    public GameMode GameMode => gameMode;
    public int ScoreToWin => scoreToWin;

    private static GameController instance;

    private ControlsType controlsType = ControlsType.Snap;

    private GameMode gameMode = GameMode.Computer;

    private int scoreToWin = 10;

    private void Awake()
    {
        if(!ReferenceEquals(GameController.Instance, null))
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        controlsType = GameSettings.Instance.TryLoadSetting(GameSettings.SettingsOptions.ActiveControlScheme, ControlsType.Snap);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SwitchGameMode(GameMode newGameMode)
    {
        gameMode = newGameMode;
    }

    public void SwitchControlsTypeToSnap()
    {
        controlsType = ControlsType.Snap;
        GameSettings.Instance.SetSetting(GameSettings.SettingsOptions.ActiveControlScheme, controlsType);
    }

    public void SwitchControlsTypeToSwipe()
    {
        controlsType = ControlsType.Swipe;
        GameSettings.Instance.SetSetting(GameSettings.SettingsOptions.ActiveControlScheme, controlsType);
    }

    public void UpdateScoreToWin(int newScoreToWin)
    {
        scoreToWin = newScoreToWin;
    }

    public void StartGameplay(int newScoreToWin)
    {
        scoreToWin = newScoreToWin;
        SceneManager.LoadScene(ScenesIdentifiers.Gameplay.ToString());
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(SceneIdentifiers.MainMenu.ToString());
    }
}
