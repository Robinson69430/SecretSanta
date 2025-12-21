using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;


public class PMU : MonoBehaviour
{
    public int number;          // 0,1,2,3
    public float speed = 20f;

    private static int winner = -1;
    private static bool gameStopped = false;

    public GameObject PMUPanel;
    
    private Rigidbody2D rb;

    void Start()
    {
        PMUPanel.SetActive(false);
        
        rb = GetComponent<Rigidbody2D>();
        Game();
    }

    void Update()
    {
        if (gameStopped) return;

        float currentSpeed = speed;

        if (number == winner)
        {
            currentSpeed = speed + 2f;
        }

        rb.linearVelocity = Vector2.up * currentSpeed;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish") && !gameStopped)
        {
            gameStopped = true;
            Debug.Log("🏁 Arrivée franchie par le cheval " + number);

            StopAllHorses();
        }
    }

    void StopAllHorses()
    {
        PMU[] horses = FindObjectsOfType<PMU>();
        foreach (PMU horse in horses)
        {
            horse.StopGame();
        }
    }

    public void Game()
    {
        Debug.Log("Game Started");

        List<int> tab = new List<int> { 0, 1, 2, 3 };
        System.Random rnd = new System.Random();
        winner = tab[rnd.Next(tab.Count)];

        Debug.Log("🏆 Le cheval numéro " + winner + " est le gagnant !");
    }

    public void StopGame()
    {
        rb.linearVelocity = Vector2.zero;
        speed = 0f;
    }
}