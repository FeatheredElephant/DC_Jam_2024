using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerManager : MonoBehaviour, IDamageable, IMove, ISubscribeToInputs
{
    #region Controls/Movement
    public PlayerControls PlayerControls { get; set; }
    public Rigidbody MyRigidbody { get; set; }
    [field: SerializeField] public float MoveSpeed { get; set; } = 1;
    [field: SerializeField] public LayerMask DetectsCollitionsWith {  get; set; }
    #endregion

    #region State Machine Variables
    PlayerStateMachine PlayerStateMachine { get; set; }
    PlayerState PlayerIdleState { get; set; }
    PlayerState PlayerMovingState { get; set; }
    #endregion

    #region Health Management Variables
    [field: SerializeField] public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    #endregion

    private void Awake()
    {
        PlayerControls ??= new PlayerControls();
        PlayerStateMachine ??= new PlayerStateMachine();
        PlayerIdleState ??= new PlayerIdleState(this, PlayerStateMachine);
        PlayerMovingState ??= new PlayerMovingState(this, PlayerStateMachine);
        PlayerStateMachine.Initialize(PlayerIdleState);
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
        MyRigidbody = GetComponent<Rigidbody>();
        SubscribeInputs();
    }

    private void OnEnable()
    {
        PlayerControls.Enable();
    }

    private void OnDisable()
    {
        PlayerControls.Disable();
        UnsubscribeInputs();
    }

    public void Damage(float amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0) Die();
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    public void Rotate()
    {
        throw new System.NotImplementedException();
    }

    public enum AnimationTriggerType{
        PlayFootstepSound,
        PlayerDamaged
    }

    public void SubscribeInputs()
    {
        PlayerControls ??= new PlayerControls();
        PlayerControls.Default.Move.started += HandleMoveInput;
        PlayerControls.Default.Turn.started += HandleTurnInput;
    }

    public void UnsubscribeInputs()
    {
        PlayerControls.Default.Move.started -= HandleMoveInput;
        PlayerControls.Default.Turn.started -= HandleTurnInput;
    }

    void HandleMoveInput(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        PlayerStateMachine.currentState.handleMoveInput(input);
    }

    void HandleTurnInput(InputAction.CallbackContext context)
    {
        float input = context.ReadValue<float>();
        PlayerStateMachine.currentState.handleTurnInput(input);
    }




}
