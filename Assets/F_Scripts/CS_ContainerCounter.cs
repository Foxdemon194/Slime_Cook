using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_ContainerCounter : CS_BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] SO_KitchenObject sOKitchenObject;

    public override void Interact(CS_Player player)
    {
        if (!HasKitchenObject())
        {
            Transform kitchenObjectTransform = Instantiate(sOKitchenObject.prefab);
            kitchenObjectTransform.GetComponent<CS_KitchenObject>().SetKitchenObjectParent(player);

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}
