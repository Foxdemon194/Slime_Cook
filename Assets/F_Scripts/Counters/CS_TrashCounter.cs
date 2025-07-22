using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_TrashCounter : CS_BaseCounter
{
    public override void Interact(CS_Player player)
    {
        if(player.HasKitchenObject())
        {
            player.GetKitchenObject().DestroySelf();
        }
    }
}
