using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] Sprite onIcon;
    [SerializeField] Sprite offIcon;
    [SerializeField] GameObject soundButton;


    void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    public void ToggleOnOff()
    {
        this.gameObject.SetActive(!isActiveAndEnabled);
        if (isActiveAndEnabled)
        {
            soundButton.GetComponent<Image>().sprite = onIcon;
        }else { 
            soundButton.GetComponent<Image>().sprite = offIcon;
        }
    }
}
