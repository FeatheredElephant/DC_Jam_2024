using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class CursorHandler : MonoBehaviour
{
    [field: SerializeField] Vector2 spritePosition { get; set; }
    [field: SerializeField] Texture2D swordCursorTexture { get; set; }
    [field: SerializeField] Texture2D openHandCursorTexture { get; set; }
    [field: SerializeField] Texture2D closedHandCursorTexture { get; set; }

    private void Start()
    {
        
        SetCursor(swordCursorTexture);
        
    }

    public void SetCursor(Texture2D newCursorTexture)
    {
        Cursor.SetCursor(newCursorTexture, spritePosition, CursorMode.ForceSoftware);
    }
}
