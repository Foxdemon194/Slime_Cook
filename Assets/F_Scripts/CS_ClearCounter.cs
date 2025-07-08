using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_ClearCounter : MonoBehaviour, IKitchenObjectParent
{

    [SerializeField] SO_KitchenObject sOKitchenObject;
    [SerializeField] Transform CounterTopPoint;


    private CS_KitchenObject kitchenObject;


    public void Interact(CS_Player player)
    {
        if (kitchenObject == null)
        {        
            Transform kitchenObjectTransform = Instantiate(sOKitchenObject.prefab, CounterTopPoint);
            kitchenObjectTransform.GetComponent<CS_KitchenObject>().SetKitchenObjectParent(this);
        }
        else
        {
            kitchenObject.SetKitchenObjectParent(player);
            Debug.Log(kitchenObject.GetKitchenObjectParent());
        }
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
