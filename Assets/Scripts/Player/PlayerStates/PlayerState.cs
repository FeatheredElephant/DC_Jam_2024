using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected PlayerManager playerManager;
    protected PlayerStateMachine playerStateMachine;

    public PlayerState(PlayerManager playerManager, PlayerStateMachine playerStateMachine)
    {
        this.playerManager = playerManager;
        this.playerStateMachine = playerStateMachine;  
    }

    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void FrameUpdate();
    public virtual void PhysicsUpdate() { throw new System.NotImplementedException(); }
    public virtual void AnimationTriggerEvent(PlayerManager.AnimationTriggerType triggerType) { throw new System.NotImplementedException(); }
}
