using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 50;
    public Image healthBar;
    public TMP_Text healthText;
    public GameObject player;
    public GameObject GameOverCanvas;
    public ParticleSystem deathPoof;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = ((float)currentHealth)/maxHealth;

        healthText.text = currentHealth + "/" + maxHealth;

        if (currentHealth <= 0) {
            Instantiate(deathPoof, player.transform.position, player.transform.rotation);
            GameOverCanvas.SetActive(true);
            Destroy(player);
        }

        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
    }
}
