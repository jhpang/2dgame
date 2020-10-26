using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public HealthManager hm;
    

    public GameObject button;
    public AudioSource audioSource;
    public AudioClip audioClip;

    public float damage = 1.2f;
    public float seriouspunchOn = 0.3f;
    public bool seriousPunch = false;
    
    public void attack()
    {
        hm.health -= damage;
        hm.healthBar.fillAmount = hm.health / hm.maxHealth;

        if (hm.health < (hm.maxHealth*seriouspunchOn))
        {
            hm.stophealth = true;
            seriousPunch = true;
            playClip();
            hm.health = 0;
            hm.healthBar.fillAmount = hm.health;
            gameObject.GetComponentInChildren<Text>().text = "SERIOUS PUNCH";
            button.GetComponent<Button>().interactable = false;
            damage += 1.0f;
        }
    }
    public void playClip()
    {
        if (seriousPunch == true)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
            seriousPunch = false;
        }
    }
}
