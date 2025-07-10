using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_CuttingCounter : CS_BaseCounter
{
    [SerializeField] private SO_KitchenObject sO_cutKitchenObject;

    public override void Interact(CS_Player player)
    {
        if (!HasKitchenObject())
        {
            // No object is being held by the counter
            if (player.HasKitchenObject())
            {
                // Player is carrying something
                // and the counter is empty
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //The player is not carrying anything
                // and the counter is empty
            }
        }
        else
        {
            //There is an object being held
            if (player.HasKitchenObject())
            {
                // The player is carrying something
                // and the counter is occupied
            }
            else
            {
                // The player is not carrying anything
                // and the counter is occupied
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(CS_Player player)
    {
        if(HasKitchenObject())
        {
            //There is an object here
            GetKitchenObject().DestroySelf();

            CS_KitchenObject.SpawnKitchenObject(sO_cutKitchenObject, this);
        }
    }
}
