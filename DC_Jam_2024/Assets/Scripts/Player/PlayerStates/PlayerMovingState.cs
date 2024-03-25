using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : PlayerState
{
    public PlayerMovingState(PlayerManager playerManager, PlayerStateMachine playerStateMachine) : base(playerManager, playerStateMachine)
    {
    }

    public override void AnimationTriggerEvent(PlayerManager.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        throw new System.NotImplementedException();
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
        throw new System.NotImplementedException();
    }

    public override void handleTurnInput(float input)
    {
        throw new System.NotImplementedException();
    }
}
