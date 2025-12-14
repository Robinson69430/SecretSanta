using System;
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
    public float coins = 1000f;
    public int hit;
    public PlayerHealh playerHealh;
    public Transform checkpoint;
    
    
    private void Awake()
    {
        PanelShop.SetActive(false);
    }

    void Start()
    {
        _shopButton.onClick.AddListener(OpenShop);
        _closeButton.onClick.AddListener(CloseShop);
        checkpoint.position = transform.position;
    }

    
    void Update()
    {   
        _coinsText.text = coins + "$";
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
