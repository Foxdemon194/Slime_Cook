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
                Debug.Log(kitchenObject.GetClearCounter());
            }
        }
    }

    public void Interact()
    {
        if (kitchenObject == null)
        {        
            Transform kitchenObjectTransform = Instantiate(sOKitchenObject.prefab, CounterTopPoint);
            kitchenObjectTransform.localPosition = Vector3.zero;

            kitchenObject = kitchenObjectTransform.GetComponent<CS_KitchenObject>();
            kitchenObject.SetClearCounter(this);
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
}
