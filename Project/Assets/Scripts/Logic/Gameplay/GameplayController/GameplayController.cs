using UnityEngine;

using GameplayControllerStateMachine;
using Players;
using UIGameplayScene;

public enum SceneIdentifiers
{
    MainMenu,
    Gameplay
}

public enum GameObjectsTags
{
    Puck,
    Striker,
    Barrier,
    Goal,
    GroundPlaneForCameraCalculations
}

public class GameplayController : MonoBehaviour
{
    public Table Table => table;
    public Striker Striker1 => striker1;
    public Striker Striker2 => striker2;

    public UIControllerGameplay UIControllerGameplay => uIControllerGameplay;

    public BasePlayer Player1 => player1;
    public BasePlayer Player2 => player2;
    public Puck Puck => puck;
    public PuckUnblockIfBlocked PuckUnblockIfBlocked => puckUnblockIfBlocked;

    [SerializeField] protected Table table;
    [SerializeField] protected Striker striker1;
    [SerializeField] protected Striker striker2;

    protected StateInitialize stateInitialize = new StateInitialize();
    protected StateIntro stateIntro = new StateIntro();
    protected StatePaused statePaused = new StatePaused();
    protected StatePlaying statePlaying = new StatePlaying();
    protected StateScored stateScored = new StateScored();
    protected StateResetPuck stateResetPuck = new StateResetPuck();
    protected StateVictory stateVictory = new StateVictory();

    protected BaseState currentState;

    protected BasePlayer player1;
    protected BasePlayer player2;

    protected UIControllerGameplay uIControllerGameplay;

    protected Puck puck;
    protected PuckUnblockIfBlocked puckUnblockIfBlocked;

    protected virtual void Awake()
    {
        puck = GetComponentInChildren<Puck>();
        puckUnblockIfBlocked = GetComponentInChildren<PuckUnblockIfBlocked>();
        table = GetComponentInChildren<Table>();
        uIControllerGameplay = GetComponentInChildren<UIControllerGameplay>();
    }

    protected virtual void Start()
    {
        SwitchState(StateID.Initialize);
    }

    protected virtual void Update()
    {
        currentState.RunUpdate(this);
    }

    protected virtual void FixedUpdate()
    {
        currentState.RunFixedUpdate(this);   
    }

    public void SwitchState(StateID newStateID)
    {
        switch(newStateID)
        {
            case StateID.Initialize:
                currentState = stateInitialize;
                break;

            case StateID.Intro:
                currentState = stateIntro;
                break;

            case StateID.Paused:
                currentState = statePaused;
                break;

            case StateID.Playing:
                currentState = statePlaying;
                break;

            case StateID.Scored:
                currentState = stateScored;
                break;

            case StateID.ResetPuck:
                currentState = stateResetPuck;
                break;

            case StateID.Victory:
                currentState = stateVictory;
                break;
        }

        currentState.InitializeState(this);
    }

    public void CreatePlayers(BasePlayer player1, BasePlayer player2)
    {
        this.player1 = player1;
        this.player2 = player2;
    }

    public void FreezeGameplay()
    {
        Time.timeScale = 0f;
    }

    public void UnfreezeGameplay()
    {
        Time.timeScale = 1f;
    }
}
