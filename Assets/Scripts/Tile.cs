using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    bool canKillPlayer = false;
    [SerializeField] GameObject emote;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    public bool CanKillPlayer
    {
        get { return canKillPlayer; }
        set { canKillPlayer = value; }
    }
    [SerializeField] ParticleSystem explosion;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip explosionSound;
    [SerializeField]Color originalColor;
    public Color OriginalColor => originalColor;

    [SerializeField] Renderer renderer;

    void Awake()
    {
        originalColor = renderer.material.color;    
    }
    public void DestroyTile(Color currentPlayerColor)
    {
        if (currentPlayerColor == renderer.material.color)
        {
            renderer.material.color = Color.black;
            GetComponentInParent<Tile_Manager>().DecreaseTileCount(originalColor);
            FindObjectOfType<GameManager>().UpdateScore();
            explosion.Play();
            audioSource.PlayOneShot(explosionSound);

        }
    }


}

