using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private CS_StoveCounter stoveCounter;
    [SerializeField] private GameObject stoveOnGameObject;
    [SerializeField] private GameObject particlesGameObject;
    [SerializeField] private GameObject stoveOnGameObjectBurning;
    [SerializeField] private GameObject particlesGameObjectBurning;
    [SerializeField] private GameObject particlesGameObjectBurnt;

    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, CS_StoveCounter.OnStateChangedEventArgs e)
    {
        bool showVisualCooking = e.state == CS_StoveCounter.State.Frying;
        bool showVisualBurning = e.state == CS_StoveCounter.State.Fried;
        bool showVisualBurnt = e.state == CS_StoveCounter.State.Burned;

        if (showVisualCooking)
        {
            stoveOnGameObject.SetActive(true);
            particlesGameObject.SetActive(true);
            stoveOnGameObjectBurning.SetActive(false);
            particlesGameObjectBurning.SetActive(false);
            particlesGameObjectBurnt.SetActive(false);
        }
        else if (showVisualBurning)
        {
            stoveOnGameObject.SetActive(false);
            particlesGameObject.SetActive(false);
            stoveOnGameObjectBurning.SetActive(true);
            particlesGameObjectBurning.SetActive(true);
            particlesGameObjectBurnt.SetActive(false);
        }
        else if (showVisualBurnt)
        {
            stoveOnGameObject.SetActive(false);
            particlesGameObject.SetActive(false);
            stoveOnGameObjectBurning.SetActive(true);
            particlesGameObjectBurning.SetActive(false);
            particlesGameObjectBurnt.SetActive(true);
        }
        else
        {
            stoveOnGameObject.SetActive(false);
            particlesGameObject.SetActive(false);
            stoveOnGameObjectBurning.SetActive(false);
            particlesGameObjectBurning.SetActive(false);
            particlesGameObjectBurnt.SetActive(false);

        }
    }
}
