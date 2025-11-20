using UnityEngine;

using Players;

public class Table : MonoBehaviour
{
    public PlayerMovementConstraints Player1MovementConstraints => player1MovementConstraints;
    public PlayerMovementConstraints Player2MovementConstraints => player2MovementConstraints;
    public PlayerMovementConstraints PuckMovementConstraints => puckMovementConstraints;

    public Goal GoalPlayer1 => goalPlayer1;
    public Goal GoalPlayer2 => goalPlayer2;

    public Vector3 DefaultPuckPosition => defaultPuckPosition;

    public Plane GroundPlaneForCameraCalculations => groundPlaneForCameraCalculations;

    [Header("Player1 Movement Constraints")]
    [SerializeField] private PlayerMovementConstraints player1MovementConstraints;

    [Header("Player2 Movement Constraints")]
    [SerializeField] private PlayerMovementConstraints player2MovementConstraints;

    [Header("Puck Movement Constraints")]
    [SerializeField] private PlayerMovementConstraints puckMovementConstraints;

    [SerializeField] private Goal goalPlayer1;
    [SerializeField] private Goal goalPlayer2;

    [SerializeField] private Vector3 defaultPuckPosition = new Vector3(0f, 0f, 0f);

    protected Plane groundPlaneForCameraCalculations;
}
