using System;
using UnityEngine;

public class PMUPASSAGE : MonoBehaviour
{

    public PMU panel;
    


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("GOOD");
            panel.PMUPanel.SetActive(true);
        }
    }
}
