using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int scoreValue = 14;
    int score=0;
    [SerializeField]TMP_Text scoreText;
    [SerializeField] TMP_Text levelText;

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject shop;
    bool isRuning = false;
    public bool IsRuning => isRuning;
    float difficultyCurve;


    void Awake()
    {
        StartLevel();
    }


    void Start()
    {
        scoreText.text = "Score: " + score;

    }

    void StartLevel()
    {
        FindObjectOfType<WalkMapGenerator>().RunGeneration();

    }


    public void UpdateScore()
    {
        score += scoreValue;
        scoreText.text = "Score: " + score;    
    }


    public void StartGame()
    {
        mainMenu.SetActive(false);
        mainUI.SetActive(true);
        isRuning = true;
    }

    public void LoadNextLevel()
    {
        StartCoroutine(StartNextLevelLoading());
        difficultyCurve += 0.4f;
    }


    IEnumerator StartNextLevelLoading()
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();  
        playerMovement.enabled = false;
        yield return new WaitForSeconds(1f);
        playerMovement.enabled = true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void OpenShop()
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
        playerMovement.enabled = false;
        
        shop.SetActive(true);
    }

    public void CloseShop()
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
        playerMovement.enabled = true;

        shop.SetActive(false);
    }

}
