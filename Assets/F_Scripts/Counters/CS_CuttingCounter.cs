using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CS_CuttingCounter : CS_BaseCounter, IHasProgress
{
    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;

    public event EventHandler OnCut;


    [SerializeField] private SO_CuttingRecipe[] SO_CuttingRecipeArray;

    private int cuttingProgress;

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
                    //Player is carrying something that can be cut
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    cuttingProgress = 0;

                    SO_CuttingRecipe sOCuttingRecipe = GetSO_CuttingRecipeWithInput(GetKitchenObject().GetSO_KitchenObject());

                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = (float) cuttingProgress / sOCuttingRecipe.cuttingProgressMax
                    });
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

    public override void InteractAlternate(CS_Player player)
    {
        if(HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetSO_KitchenObject()))
        {
            cuttingProgress++;

            OnCut?.Invoke(this, EventArgs.Empty);

            SO_CuttingRecipe sOCuttingRecipe = GetSO_CuttingRecipeWithInput(GetKitchenObject().GetSO_KitchenObject());

            OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
            {
                progressNormalized = (float)cuttingProgress / sOCuttingRecipe.cuttingProgressMax
            });

            if (cuttingProgress >= sOCuttingRecipe.cuttingProgressMax)
            {
                //There is an object here and it can be cut
                SO_KitchenObject sO_OutputKitchenObject = GetOutputForInput(GetKitchenObject().GetSO_KitchenObject());

                GetKitchenObject().DestroySelf();

                CS_KitchenObject.SpawnKitchenObject(sO_OutputKitchenObject, this);
            }
        }
    }

    private bool HasRecipeWithInput(SO_KitchenObject sO_InputKitchenObject)
    {
        SO_CuttingRecipe sO_CuttingRecipe = GetSO_CuttingRecipeWithInput(sO_InputKitchenObject);
        return sO_CuttingRecipe != null;
        
    }

    private SO_KitchenObject GetOutputForInput(SO_KitchenObject sO_inputKitchenObject)
    {
        SO_CuttingRecipe sO_CuttingRecipe = GetSO_CuttingRecipeWithInput(sO_inputKitchenObject);
        if (sO_CuttingRecipe != null)
        {
            return sO_CuttingRecipe.output;
        }
        else
        {
            return null;
        }
    }

    private SO_CuttingRecipe GetSO_CuttingRecipeWithInput(SO_KitchenObject sO_inputKitchenObject)
    {
        foreach(SO_CuttingRecipe sO_CuttingRecipe in SO_CuttingRecipeArray)
        {
            if(sO_CuttingRecipe.input == sO_inputKitchenObject)
            {
                return sO_CuttingRecipe;
            }            
        }
        return null;
    }
}
