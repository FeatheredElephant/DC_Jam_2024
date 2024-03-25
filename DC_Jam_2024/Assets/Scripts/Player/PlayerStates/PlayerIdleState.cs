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

        if (input.x > 0) targetPosition = MoveRight(currentPosition);
        if (input.x < 0) targetPosition = MoveLeft(currentPosition);
        if (input.y > 0) targetPosition = MoveForward(currentPosition);
        if (input.y < 0) targetPosition = MoveBackward(currentPosition);

        playerManager.transform.position = targetPosition;
        /*
         * 1. Convert input into move direction
         * 2. Check if player can move in that direction
         * 3. If no, play bump sound effect
         * 4. If yes, changestate to moving
         */

        Vector3 MoveRight(Vector3 currentPositon)    
        {
            RaycastHit hit;
            if (Physics.Raycast(currentPosition, playerManager.transform.right, out hit, playerManager.MoveSpeed, playerManager.DetectsCollitionsWith))
            {
                Debug.Log("Collision detected.");
                return currentPosition;
            }
            else return currentPosition + playerManager.transform.right * playerManager.MoveSpeed;
        }
        Vector3 MoveLeft(Vector3 currentPositon)     { return currentPosition - playerManager.transform.right; }
        Vector3 MoveForward(Vector3 currentPositon)  
        {
            RaycastHit hit;
            if (Physics.Raycast(currentPositon, playerManager.transform.forward, out hit, playerManager.MoveSpeed, playerManager.DetectsCollitionsWith))
            {
                Debug.Log("Collision detected.");
                return currentPosition;
            }
            else return currentPosition + playerManager.transform.forward * playerManager.MoveSpeed;
        }
        Vector3 MoveBackward(Vector3 currentPositon) { return currentPosition - playerManager.transform.forward; }
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
