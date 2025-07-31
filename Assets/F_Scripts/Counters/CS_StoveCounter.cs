using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CS_CuttingCounter;

public class CS_StoveCounter : CS_BaseCounter
{
    [SerializeField] private SO_FryingRecipe[] sO_FryingRecipeArray;

    private float fryingTimer;


    private void Update()
    {
        if(HasKitchenObject())
        {
            fryingTimer += Time.deltaTime;
            SO_FryingRecipe sO_FryingRecipe = GetSO_FryingRecipeWithInput(GetKitchenObject().GetSO_KitchenObject());
            if(fryingTimer > sO_FryingRecipe.fryingTimerMax)
            {
                // Fried
                fryingTimer = 0;
                Debug.Log("Fried");
                GetKitchenObject().DestroySelf();

                CS_KitchenObject.SpawnKitchenObject(sO_FryingRecipe.output, this);
            }

            Debug.Log(fryingTimer);
        }
    }

    public override void Interact(CS_Player player)
    {
        if (!HasKitchenObject())
        {
            // No object is being held by the counter
            if (player.HasKitchenObject())
            {
                // Player is carrying something
                // and the counter is empty
                if (HasRecipeWithInput(player.GetKitchenObject().GetSO_KitchenObject()))
                {
                    //Player is carrying something that can be fried
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
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

    private bool HasRecipeWithInput(SO_KitchenObject sO_InputKitchenObject)
    {
        SO_FryingRecipe sO_FryingRecipe = GetSO_FryingRecipeWithInput(sO_InputKitchenObject);
        return sO_FryingRecipe != null;

    }

    private SO_KitchenObject GetOutputForInput(SO_KitchenObject sO_inputKitchenObject)
    {
        SO_FryingRecipe sO_FryingRecipe = GetSO_FryingRecipeWithInput(sO_inputKitchenObject);
        if (sO_FryingRecipe != null)
        {
            return sO_FryingRecipe.output;
        }
        else
        {
            return null;
        }
    }

    private SO_FryingRecipe GetSO_FryingRecipeWithInput(SO_KitchenObject sO_inputKitchenObject)
    {
        foreach (SO_FryingRecipe sO_FryingRecipe in sO_FryingRecipeArray)
        {
            if (sO_FryingRecipe.input == sO_inputKitchenObject)
            {
                return sO_FryingRecipe;
            }
        }
        return null;
    }
}
