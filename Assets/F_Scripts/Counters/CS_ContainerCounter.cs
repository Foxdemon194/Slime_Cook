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

        if(!player.HasKitchenObject())
        {
            // The player isn't carrying an object
            CS_KitchenObject.SpawnKitchenObject(sOKitchenObject, player);

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}
