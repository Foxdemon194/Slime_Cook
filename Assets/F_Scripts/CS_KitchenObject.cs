using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_KitchenObject : MonoBehaviour
{
    [SerializeField] private SO_KitchenObject sOKitchenObject;

    private IKitchenObjectParent kitchenObjectParent;

    public SO_KitchenObject GetSO_KitchenObject()
    {
        return sOKitchenObject;
    }

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if(this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        this.kitchenObjectParent = kitchenObjectParent;

        if(kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("IKitchenObjectParent already has a KitchenObject!");
        }

        kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero; // If i decide to do the hand off animation through code, i will probably have to relocate this line
    }

    public void DestroySelf()
    {
        kitchenObjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }

    public IKitchenObjectParent GetKitchenObjectParent() 
    {
        return kitchenObjectParent;
    }

    public static CS_KitchenObject SpawnKitchenObject(SO_KitchenObject sO_KitchenObject, IKitchenObjectParent kitchenObjectParent)
    {
        Transform kitchenObjectTrasform = Instantiate(sO_KitchenObject.prefab);

        CS_KitchenObject kitchenObject = kitchenObjectTrasform.GetComponent<CS_KitchenObject>();

        kitchenObject.SetKitchenObjectParent(kitchenObjectParent);

        return kitchenObject;
    }

    // I added this in case I want to implement a toss animation through a IEnumerator
    /*
    public IEnumerator CenterObject(float waitTime)
    {
        //move the object upwards, towards the location, and flip it and center it once done.
        yield return new WaitForSeconds(waitTime);
    }*/
}
