using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] Transform CounterTopPoint;


    private CS_KitchenObject kitchenObject;


    public virtual void Interact(CS_Player player)
    {
        Debug.LogError("CS_BaseCounter.Interact() was run when it should have been overwriten");
    }

    public virtual void InteractAlternate(CS_Player player)
    {
        //Debug.LogError("CS_BaseCounter.InteractAlternate() was run when it should have been overwriten");
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return CounterTopPoint;
    }

    public void SetKitchenObject(CS_KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public CS_KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }

}
