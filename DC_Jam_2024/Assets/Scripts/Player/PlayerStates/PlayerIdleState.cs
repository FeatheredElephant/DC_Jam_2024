using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerManager playerManager, PlayerStateMachine playerStateMachine) : base(playerManager, playerStateMachine) { }

    public override void AnimationTriggerEvent(PlayerManager.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        //play idle animation
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void FrameUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void handleMoveInput(Vector2 input)
    {        
        Vector3 currentPosition = playerManager.transform.position;
        Vector3 targetPosition = currentPosition;

        Vector3 Move(Vector3 currentPosition, Vector3 direction)
        {
            if (Physics.Raycast(currentPosition, direction, out _, playerManager.MoveSpeed, playerManager.DetectsCollitionsWith))
            {
                Debug.Log("Collision detected.");
                return currentPosition;
            }
            return currentPosition + direction * playerManager.MoveSpeed;
        }
        Vector3 MoveRight(Vector3 currentPositon) { return Move(currentPosition, playerManager.transform.right); }
        Vector3 MoveLeft(Vector3 currentPositon) { return Move(currentPosition, -playerManager.transform.right); }
        Vector3 MoveForward(Vector3 currentPositon) { return Move(currentPosition, playerManager.transform.forward); }
        Vector3 MoveBackward(Vector3 currentPositon) { return Move(currentPosition, -playerManager.transform.forward); }

        if (input.x > 0) targetPosition = MoveRight(currentPosition);
        if (input.x < 0) targetPosition = MoveLeft(currentPosition);
        if (input.y > 0) targetPosition = MoveForward(currentPosition);
        if (input.y < 0) targetPosition = MoveBackward(currentPosition);

        playerManager.transform.position = targetPosition;
    }

    public override void handleTurnInput(float input)
    {
        Vector3 currentRotation = playerManager.transform.rotation.eulerAngles;
        Vector3 targetRotation = input < 0 ? CalculateLeftTurn(currentRotation) : CalculateRightTurn(currentRotation);
        playerManager.transform.rotation = Quaternion.Euler(targetRotation);

        Vector3 CalculateLeftTurn(Vector3 targetRotation)  { return currentRotation - Vector3.up * 90f; }
        Vector3 CalculateRightTurn(Vector3 targetRotation) { return currentRotation + Vector3.up * 90f; }
    }
}
