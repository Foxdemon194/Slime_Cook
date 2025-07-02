using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_GameInput : MonoBehaviour
{
    private IA_Player iAPlayer;

    private void Awake()
    {
        iAPlayer = new IA_Player();
        iAPlayer.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = iAPlayer.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        //Debug.Log(inputVector);
        return inputVector;
    }
}
