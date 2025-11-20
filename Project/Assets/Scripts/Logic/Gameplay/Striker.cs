using UnityEngine;

using GameSettingsAndSaveSystem;
using Players;

public class Striker : MonoBehaviour
{
    public float MovementSpeedModifier => movementSpeedModifierSwipe;
    public float MaxMovmentSpeedModifier => maxMovementSpeedModifierSwipe;
    public float MinMovementSpeedModifier => minMovementSpeedModifierSwipe;
    public float DefaultMovementSpeedModifier => defaultMovementSpeedModifier;
    public Rigidbody Rigidbody => rigidbody;

    private Rigidbody rigidbody;

    private float movementSpeedModifierSwipe = 12;
    private float maxMovementSpeedModifierSwipe = 30f;
    private float minMovementSpeedModifierSwipe = 0.5f;
    private float defaultMovementSpeedModifier = 12f;

    private float movementSpeedModifierSnap = 125;

    private void Awake()
    {
       rigidbody = GetComponent<Rigidbody>();
    }

    public void SetMovementSpeedModifier(float movementSpeedModifier)
    {
        this.movementSpeedModifierSwipe = movementSpeedModifier;
    }

    public void PerformSnapMovementPlayerHuman(Vector3 forceVectorToAdd)
    {
        rigidbody.linearVelocity = (forceVectorToAdd * movementSpeedModifierSnap);
    }

    public void PerformSwipeMovementPlayerHuman(Vector2 playerInputForce)
    {
        rigidbody.AddForce(new Vector3(-playerInputForce.x, 0f, -playerInputForce.y) * movementSpeedModifierSwipe);
    }

    public void PerformMovementPlayerComputer(Vector3 velocityToAdd, float computerDifficultyMaxSpeed)
    {
        rigidbody.AddForce(Mathf.Clamp(velocityToAdd.x, -computerDifficultyMaxSpeed, computerDifficultyMaxSpeed), 0f, Mathf.Clamp(velocityToAdd.z, -computerDifficultyMaxSpeed, computerDifficultyMaxSpeed), ForceMode.VelocityChange);
    }

    public void ConstraintPlayerMaxVelocity(float maxOverallVelocity)
    {
        rigidbody.maxLinearVelocity = maxOverallVelocity;
    }

    public Vector3 ReturnGameWorldPosition()
    {
        return rigidbody.position;
    }

    public void SetGameWorldPosition(Vector3 newPosition)
    {
        rigidbody.position = newPosition;
    }

    public void SetVelocity(Vector3 newVelocity)
    {
        rigidbody.linearVelocity = newVelocity;
    }

    public void StopStriker()
    {
        rigidbody.linearVelocity = new Vector3(0f, 0f, 0f);
    }

    public void SetKinematic()
    {
        rigidbody.isKinematic = true;
    }

    public void SetNotKinematic()
    {
        rigidbody.isKinematic = false;
    }
}
