using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_KitchenObject : MonoBehaviour
{
    [SerializeField] private SO_KitchenObject sOKitchenObject;

    private IKitchenObjectParent kitchenObjectParent;

    public SO_KitchenObject GetSO_KitchenObject()
    {
        return sOKitchenObject;
    }

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if(this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        this.kitchenObjectParent = kitchenObjectParent;

        if(kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("IKitchenObjectParent already has a KitchenObject!");
        }

        kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetKitchenObjectParent() 
    {
        return kitchenObjectParent;
    }
}
