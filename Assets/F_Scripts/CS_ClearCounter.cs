using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_ClearCounter : MonoBehaviour
{

    [SerializeField] SO_KitchenObject sOKitchenObject;
    [SerializeField] Transform CounterTopPoint;


    private CS_KitchenObject kitchenObject;

    public void Interact()
    {
        if (kitchenObject == null)
        {        
        Transform kitchenObjectTransform = Instantiate(sOKitchenObject.prefab, CounterTopPoint);
        kitchenObjectTransform.localPosition = Vector3.zero;

        kitchenObject = kitchenObjectTransform.GetComponent<CS_KitchenObject>();
        }
    }
}
