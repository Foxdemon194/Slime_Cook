using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : CS_BaseCounter
{
    public override void Interact(CS_Player player)
    {
        if(player.HasKitchenObject())
        {
            if(player.GetKitchenObject().TryGetPlate(out CS_PlateKitchenObject plateKitchenObject)) 
            {
                player.GetKitchenObject();
            }            
        }
    }
}
