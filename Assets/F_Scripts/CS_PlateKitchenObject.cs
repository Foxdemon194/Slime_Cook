using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_PlateKitchenObject : CS_KitchenObject
{
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
            return true;
        }
    }
}
