using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CS_PlateKitchenObject : CS_KitchenObject
{
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs: EventArgs
    {
        public SO_KitchenObject kitchenObjectSO;
    }

    [SerializeField] private List<SO_KitchenObject> validKitchenObjectSOList;
    private List<SO_KitchenObject> kitchenObjectSOList;


    private void Awake()
    {
        kitchenObjectSOList = new List<SO_KitchenObject>();
    }

    public bool TryAddIngredient(SO_KitchenObject sO_KitchenObject)
    {
        if(!validKitchenObjectSOList.Contains(sO_KitchenObject))
        {
            // not a valid ingredient
            return false;
        }
        if (kitchenObjectSOList.Contains(sO_KitchenObject))
        {
            // already has this ingredient
            return false;
        }
        else
        {
            kitchenObjectSOList.Add(sO_KitchenObject);

            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs
            {
                kitchenObjectSO = sO_KitchenObject
            });
            return true;
        }
    }

    public List<SO_KitchenObject> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList;
    }
}
