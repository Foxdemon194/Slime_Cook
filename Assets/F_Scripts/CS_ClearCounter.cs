using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_ClearCounter : MonoBehaviour
{

    [SerializeField] SO_KitchenObject sOKitchenObject;
    [SerializeField] Transform CounterTopPoint;
    [SerializeField] CS_ClearCounter secondClearCounter;
    [SerializeField] bool testing;


    private CS_KitchenObject kitchenObject;

    private void Update()
    {
        if(testing && Input.GetKeyDown(KeyCode.T))
        {
            if(kitchenObject != null)
            {
                kitchenObject.SetClearCounter(secondClearCounter);
            }
        }
    }

    public void Interact()
    {
        if (kitchenObject == null)
        {        
            Transform kitchenObjectTransform = Instantiate(sOKitchenObject.prefab, CounterTopPoint);
            kitchenObjectTransform.GetComponent<CS_KitchenObject>().SetClearCounter(this);
        }
        else
        {
            Debug.Log(kitchenObject.GetClearCounter());
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
