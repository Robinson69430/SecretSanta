using UnityEngine;

public class FinishGame : MonoBehaviour
{

    public PMU pmu;
    
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            Debug.Log("Finish");
            pmu.StopGame();
        }
    }
}
