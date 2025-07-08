using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent
{
    public Transform GetKitchenObjectFollowTransform();

    public void SetKitchenObject(CS_KitchenObject kitchenObject);

    public CS_KitchenObject GetKitchenObject();

    public void ClearKitchenObject();

    public bool HasKitchenObject();
   
}
