using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_ClearCounter : CS_BaseCounter
{

    [SerializeField] SO_KitchenObject sOKitchenObject;


    public override void Interact(CS_Player player)
    {
        if(!HasKitchenObject())
        {
            // No object is being held by the counter
            if(player.HasKitchenObject())
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
            if(player.HasKitchenObject())
            {
                // The player is carrying something
                // and the counter is occupied
                if (player.GetKitchenObject().TryGetPlate(out CS_PlateKitchenObject plateKitchenObject))
                {
                    //player is holding a plate                    
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetSO_KitchenObject()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    //Player is not carrying a plate, but is holding something else
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        //Count is holding a plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetSO_KitchenObject()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }                
            }
            else
            {
                // The player is not carrying anything
                // and the counter is occupied
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}
