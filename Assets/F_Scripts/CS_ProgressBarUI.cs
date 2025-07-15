using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_ProgressBarUI : MonoBehaviour
{
    [SerializeField] private CS_CuttingCounter cS_cuttingCounter;
    [SerializeField] private Image barImage;

    private void Start()
    {
        cS_cuttingCounter.OnProgressChanged += CS_cuttingCounter_OnProgressChanged;
        barImage.fillAmount = 0f;
        Hide();
    }

    private void CS_cuttingCounter_OnProgressChanged(object sender, CS_CuttingCounter.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;

        if(e.progressNormalized == 0 || e.progressNormalized == 1 )
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
