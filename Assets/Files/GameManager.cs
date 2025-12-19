using System;
using DefaultNamespace;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button _shopButton;
    public Button _closeButton;
    public GameObject PanelShop;

    
    public TextMeshProUGUI _coinsText;
    public int hit;
    public PlayerHealh playerHealh;
    public Transform checkpoint;
    public float coins = 100f;
    public Button _prendSoins;
    
    public TextMeshProUGUI _ballesText;
    public int balles = 0;
    public Button _ballesSup;
    
    
    
    
    
    private void Awake()
    {
        PanelShop.SetActive(false);
        
    }

    void Start()
    {
        _shopButton.onClick.AddListener(OpenShop);
        _closeButton.onClick.AddListener(CloseShop);
        _prendSoins.onClick.AddListener(() => playerHealh.TakeHeal(3));
        _ballesSup.onClick.AddListener(BallesSup);
        checkpoint.position = transform.position;
        
    }

    
    void Update()
    {
        _coinsText.text = coins + "$";
        _ballesText.text = "" + balles;
    }



    public void BallesSup()
    {
        balles += 10;
    }
    

    public void OpenShop()
    {
        PanelShop.SetActive(true); 
        
    }
    public void CloseShop()
    {
        PanelShop.SetActive(false); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("kill"))
        {
            hit--;
            Destroy(collision.gameObject);
            playerHealh.TakeDamage(2);
        }
    }


}
