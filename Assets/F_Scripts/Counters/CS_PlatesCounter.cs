using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_PlatesCounter : CS_BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;
    [SerializeField] private SO_KitchenObject plateKitchenObjectSO;

    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 4f;
    private int platesSpawnedAmount;
    private int platesSpawnedAmountMax = 4;

    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlateTimerMax)
        {
            spawnPlateTimer = 0;

            if(platesSpawnedAmount < spawnPlateTimerMax ) 
            {
                platesSpawnedAmount++;

                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(CS_Player player)
    {
        if(!player.HasKitchenObject())
        {
            if(platesSpawnedAmount > 0)
            {
                platesSpawnedAmount--;

                CS_KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);

                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
