using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI coinsText;
    // Start is called before the first frame update
    void Start()
    {
        coinsText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCoinsText(PlayerInventory playerInventory){
        coinsText.text = playerInventory.NumberOfCoins.ToString();
    }
}
   
