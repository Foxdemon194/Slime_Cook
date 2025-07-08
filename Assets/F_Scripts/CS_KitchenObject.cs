using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_KitchenObject : MonoBehaviour
{
    [SerializeField] private SO_KitchenObject sOKitchenObject;

    private CS_ClearCounter clearCounter;

    public SO_KitchenObject GetSO_KitchenObject()
    {
        return sOKitchenObject;
    }

    public void SetClearCounter(CS_ClearCounter clearCounter)
    {
        this.clearCounter = clearCounter;
        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public CS_ClearCounter GetClearCounter() 
    {
        return clearCounter;
    }
}
