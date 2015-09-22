using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
    private GameObject gameOver;
    // Use this for initialization

    void Awake()
    {
        GameObject gameOver = GameObject.Find("GameOver");
        //gameOver.SetActive(true);
    }
    void Start()
    {
       // GameObject gameOver = GameObject.Find("GameOver");
       // gameOver.gameObject.SetActive(false);
    }

 
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        if (playerMovement.deathCounter >= 3)
        {
            gameOver.gameObject.SetActive(true);
        }
    }
}
