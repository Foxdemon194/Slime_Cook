using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_CuttingCounterVisual : MonoBehaviour
{
    private const string CUT = "Cut";

    [SerializeField] private CS_CuttingCounter cuttingCounter;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        //containerCounter.OnPlayerGrabbedObject += ContainerCounter_OnPlayerGrabbedObject; uncomment this~~~~~~~~~~~~~~~~~~~
    }

    private void ContainerCounter_OnPlayerGrabbedObject(object sender, System.EventArgs e)
    {
        //animator.SetTrigger(OPEN_CLOSE); uncomment this too ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}
