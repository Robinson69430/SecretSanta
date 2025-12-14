using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class TagPuzzle : MonoBehaviour
{
    public GameObject panelPuzzle;
    public Button FaceButton;
    public Button PileButton;
    public InputField mise;
    public TextMeshProUGUI afficherMise;
    public int miser;
    public GameManager gm;
    public TextMeshProUGUI pileText;
    
    void Start()
    {

            panelPuzzle.SetActive(false);
            
            FaceButton.onClick.AddListener(LancerFace);
            PileButton.onClick.AddListener(LancerPile);
            
        
    }
    
    void Update()
    {

            if (int.TryParse(mise.text, out miser))
            {
                afficherMise.text = "Are you ready to bet " + miser + " Dollars ?";
            }

        
    }
    
    public void LancerPile()
    {
        Debug.Log("RENTRER DANS LE Pile");

        if (gm.coins >= miser)
        {
                
            
            List<int> tab = new List<int> {0,1};
            System.Random rnd = new System.Random();
            int nbAleatoire = rnd.Next(tab.Count);
            Debug.Log(nbAleatoire);
            if (nbAleatoire == 0)
            {
                Debug.Log("PILE");
                pileText.text = "";
                pileText.text = "Pile ! Bravo You won " + miser*2 + " dollars !!";
                gm.coins += miser*2;
            }
            else
            {
                Debug.Log("Face");
                
                pileText.text = "";
                pileText.text = "Face ! Oh Shit you lost " + miser +  " dollars :(";
                gm.coins -= miser;
            }
        }
            
            

        

    }
    public void LancerFace()
    {
        Debug.Log("RENTRER DANS LE Face");


        if (gm.coins >= miser)
        {
            List<int> tab = new List<int> {0,1};
            System.Random rnd = new System.Random();
            int nbAleatoire = rnd.Next(tab.Count);
            Debug.Log(nbAleatoire);
            if (nbAleatoire == 0)
            {
                pileText.text = "";
                pileText.text = "Pile ! Oh Shit you lost " + miser + " dollars :(";
                gm.coins -= miser;
            }
            else
            {
                pileText.text = "";
                pileText.text = "Face ! Bravo You won " + miser * 2 + " dollars !!";
                gm.coins += miser*2;
            }
        }




    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            panelPuzzle.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            panelPuzzle.SetActive(false);
        }
    }
}