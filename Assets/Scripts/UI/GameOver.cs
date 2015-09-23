using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
    //gameobjects
    private GameObject gameOver;
    private GameObject goText;
    //gameobjects


    //audiosource
    [SerializeField]
    private AudioSource gameOverSFX;
    //audiosource

    void Start()
    {
        goText = GameObject.Find("GO");
        goText.SetActive(false);
        gameOver = GameObject.Find("GameOver");
        gameOver.SetActive(false);
    }

 
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        if (playerMovement.deathCounter >= 3)
        {
            gameOverSFX.Play();
            StartCoroutine("GameOverTimer");
        }
    }

    IEnumerator GameOverTimer()
    {
        yield return new WaitForSeconds(2);
        
        gameOver.SetActive(true);
        
    }
}
