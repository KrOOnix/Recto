using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    int gems;
    [SerializeField] TMP_Text gemsText;


    void Start()
    {
        gemsText.text = (PlayerPrefs.GetInt("Gems").ToString());
        gems = PlayerPrefs.GetInt("Gems");
    }

    public void AddGems()
    {
        gems+=10;
        PlayerPrefs.SetInt("Gems", gems);
        gemsText.text = (PlayerPrefs.GetInt("Gems").ToString());
    }

    public void BuyItem(Item item)
    {
        if (gems >= item.Price && !item.isOwned)
        {
            gems -= item.Price;
            item.isOwned = true;
            PlayerPrefs.SetInt("IsOwned" + item.name, (item.isOwned  ? 1:0));
            item.btnText.text = "OWNED";
        }
    }

    
}
