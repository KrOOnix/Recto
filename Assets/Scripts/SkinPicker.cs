using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinPicker : MonoBehaviour
{
    [SerializeField] Renderer player;
    [SerializeField] Material skin;

    public void ChangeSkin()
    {
        if (GetComponentInParent<Item>().isOwned) {
            player.material = skin;
            player.material.color = FindObjectOfType<ColorManager>().CurrentColor;
        }
    }
}
