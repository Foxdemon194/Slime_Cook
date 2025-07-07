using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private CS_ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;

    private void Start()
    {
        CS_Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, CS_Player.OnSelectedCounterChangedEventArgs e)
    {
        if(e.selectedCounter == clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        visualGameObject.SetActive(true);
    }

    private void Hide()
    {
        visualGameObject.SetActive(false);
    }
}
