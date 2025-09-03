using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CS_CuttingCounter;

public class CS_StoveCounter : CS_BaseCounter, IHasProgress
{
    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;
    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;
    public class OnStateChangedEventArgs : EventArgs
    {
        public State state;
    }

    public enum State
    {
        Idle,
        Frying,
        Fried,
        Burned,
    }


    [SerializeField] private SO_FryingRecipe[] sO_FryingRecipeArray;
    [SerializeField] private SO_BurningRecipe[] sO_BurningRecipeArray;


    private State state;
    private float fryingTimer;
    private SO_FryingRecipe sO_FryingRecipe;
    private float burningTimer;
    private SO_BurningRecipe sO_BurningRecipe;

    private void Start()
    {
        state = State.Idle;
    }

    private void Update()
    {
        if (HasKitchenObject())
        {
            switch (state)
            {
                case State.Idle:
                    break;
                case State.Frying:
                    fryingTimer += Time.deltaTime;

                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = fryingTimer / sO_FryingRecipe.fryingTimerMax
                    });

                    if (fryingTimer > sO_FryingRecipe.fryingTimerMax)
                    {
                        // Fried
                        GetKitchenObject().DestroySelf();

                        CS_KitchenObject.SpawnKitchenObject(sO_FryingRecipe.output, this);
                        Debug.Log("Object Fried!");
                        state = State.Fried;
                        burningTimer = 0f;
                        sO_BurningRecipe = GetSO_BurningRecipeWithInput(GetKitchenObject().GetSO_KitchenObject());
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                        {
                            state = state
                        });
                    }

                break;
            case State.Fried:
                    burningTimer += Time.deltaTime;

                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = burningTimer / sO_BurningRecipe.burningTimerMax
                    });

                    if (burningTimer > sO_BurningRecipe.burningTimerMax)
                    {
                        GetKitchenObject().DestroySelf();

                        CS_KitchenObject.SpawnKitchenObject(sO_BurningRecipe.output, this);
                        Debug.Log("Object Burned!");
                        state = State.Burned;

                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                        {
                            state = state
                        });

                        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                        {
                            progressNormalized = 0f
                        });

                    }
                break;
            case State.Burned:
                break;
            }



            Debug.Log(state);
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

                    sO_FryingRecipe = GetSO_FryingRecipeWithInput(GetKitchenObject().GetSO_KitchenObject());
                    state = State.Frying;
                    fryingTimer = 0f;

                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                    {
                        state = state
                    });
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = fryingTimer / sO_FryingRecipe.fryingTimerMax
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

                state = State.Idle;

                OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                {
                    state = state
                });

                OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                {
                    progressNormalized = 0f
                });

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

    private SO_BurningRecipe GetSO_BurningRecipeWithInput(SO_KitchenObject sO_inputKitchenObject)
    {
        foreach (SO_BurningRecipe sO_BurningRecipe in sO_BurningRecipeArray)
        {
            if (sO_BurningRecipe.input == sO_inputKitchenObject)
            {
                return sO_BurningRecipe;
            }
        }
        return null;
    }
}
