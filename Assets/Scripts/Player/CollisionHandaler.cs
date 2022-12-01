using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandaler : MonoBehaviour
{
    [SerializeField] ColorManager colorManager;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Tile>().CanKillPlayer)
        {
            FindObjectOfType<GameManager>().LoadNextLevel();
        }
        collision.gameObject.GetComponent<Tile>().DestroyTile(colorManager.CurrentColor);       
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.GetComponent<Renderer>().material.color == Color.black)
        {
            collision.gameObject.GetComponent<Tile>().CanKillPlayer = true;
        }
    }
}
