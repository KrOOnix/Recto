using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField]int price;
    public int Price => price;

    public TMP_Text btnText;
    public bool isOwned;

    private void Start()
    {
        isOwned = (PlayerPrefs.GetInt("IsOwned"+this.name) != 0);

        if (isOwned)
        {
            btnText.text = "OWNED";
        }
    }
}
