using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public BattleManager bm;
    public GameManager gm;
    public GameObject Player;

    public Image healthBar;

    public Text victoryMsg;
    public float maxHealth = 100;
    public float health = 100;
    public float regeneration = 1.4f;
    public bool regening = false;
    public bool stophealth = false;
    public string mob = "";
    public int beatMobs = 0;

    void Start()
    {
        victoryMsg.enabled = false;
    }
    void Update()
    {
        if (health != maxHealth && regening == false && stophealth == false)
        {
            StartCoroutine(Regen());
        }
        if (health <= 0)
        {
            StartCoroutine(victory());
        }
    }

    private IEnumerator Regen()
    {
        regening = true;
        while (health < maxHealth)
        {
            health += regeneration;
            healthBar.fillAmount += regeneration / maxHealth;
            yield return new WaitForSeconds(1);
        }
        regening = false;
    }
    private IEnumerator victory()
    {
        stophealth = false;
        health = maxHealth;
        victoryMsg.enabled = true;
        yield return new WaitForSeconds(5);
        gm.GoToPlayer();
        Player.GetComponent<PlayerMovement>().enabled = true;
        bm.GetComponent<Button>().interactable = true;
        victoryMsg.enabled = false;
        healthBar.fillAmount = 1;
        regeneration += 2.0f;
        beatMobs += 1;
    }
}
