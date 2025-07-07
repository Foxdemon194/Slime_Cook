using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_KitchenObject : MonoBehaviour
{
    [SerializeField] private SO_KitchenObject sOKitchenObject;
    public SO_KitchenObject GetSO_KitchenObject()
    {
        return sOKitchenObject;
    }
}
