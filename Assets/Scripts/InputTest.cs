using UnityEngine;
using UnityEngine.InputSystem;
using static ISubscribeToInputs;

public class InputTest : MonoBehaviour, ISubscribeToInputs
{
    public PlayerControls PlayerControls { get; set; }

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

    void HandleTurnInput(InputAction.CallbackContext context) {
        Debug.Log(context);
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

    private void Start()
    {
        SubscribeInputs();
        Debug.Log("Got here");
    }
}
