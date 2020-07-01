using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealthPiont = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;

    [SerializeField] AudioClip hitByEnemySFX;

    void Start()
    {
        healthText.text = playerHealthPiont.ToString(); //convert int to string
    }

    private void OnTriggerEnter(Collider other)
    {
        if(playerHealthPiont <= 0)
        {
            //end the game
        }
        else
        {
            DecreasePlayerHealth();
        }
        print(playerHealthPiont);
    }

    private void DecreasePlayerHealth()
    {
        playerHealthPiont -= healthDecrease;
        healthText.text = playerHealthPiont.ToString(); //convert int to string

        GetComponent<AudioSource>().PlayOneShot(hitByEnemySFX);
    }
}
