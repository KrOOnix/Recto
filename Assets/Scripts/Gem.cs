using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] GameObject emote;
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<Shop>().AddGems();
        PlayEmote();
        Destroy(gameObject);       
    }

    void PlayEmote()
    {
        Instantiate(emote,new Vector3(transform.position.x,20f,transform.position.z),Quaternion.identity);
    }
}
