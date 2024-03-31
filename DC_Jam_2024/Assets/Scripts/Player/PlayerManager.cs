using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings;

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

    #region Cut/Blade Functionality
        [field: SerializeField] Transform Blade { get; set; }
        [field: SerializeField] Camera Camera { get; set; }
        [field: SerializeField] LayerMask CuttableTargets {  get; set; }
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
        PlayerControls.Default.Cut.started += HandleCutStartInput;
        PlayerControls.Default.Cut.performed += HandleCutInput;
    }

    public void UnsubscribeInputs()
    {
        PlayerControls.Default.Move.started -= HandleMoveInput;
        PlayerControls.Default.Turn.started -= HandleTurnInput;
        PlayerControls.Default.Cut.started -= HandleCutStartInput;
        PlayerControls.Default.Cut.performed -= HandleCutInput;
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

    void HandleCutStartInput(InputAction.CallbackContext context)
    {

    }

    void HandleCutInput(InputAction.CallbackContext context) 
    {
        Ray ray = Camera.ScreenPointToRay(context.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 4f, CuttableTargets))
        {
            hit.transform.SendMessage("Cut", hit.point);
            Debug.DrawRay(ray.origin, ray.direction * 4, Color.yellow);
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 4, Color.red);
        }
    }
}
