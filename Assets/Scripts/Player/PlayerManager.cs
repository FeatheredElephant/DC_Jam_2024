using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerManager : MonoBehaviour, IDamageable, IMove, ISubscribeToInputs
{
    public PlayerControls PlayerControls { get; set; }
    public Rigidbody MyRigidbody { get; set; }
    [field: SerializeField] public float MaxHealh { get; set; }
    public float CurrentHealth { get; set; }

    private void Start()
    {
        CurrentHealth = MaxHealh;
        MyRigidbody = GetComponent<Rigidbody>();
        SubscribeInputs();
    }
    private void Awake()
    {
        PlayerControls ??= new PlayerControls();
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
        Debug.Log(context);
    }

    void HandleTurnInput(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }


}
