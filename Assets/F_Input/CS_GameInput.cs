using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CS_GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    private IA_Player iAPlayer;

    private void Awake()
    {
        iAPlayer = new IA_Player();
        iAPlayer.Player.Enable();

        iAPlayer.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = iAPlayer.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }
}
