using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public HealthManager hman;
    public GameObject Exclam;
    public GameObject Player;
    private GameManager gm;
    private bool waiting = false;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Exclam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<PlayerMovement>())
        {
            if (gameObject.tag == "Goblin")
            {
                if (gm != null)
                {
                    hman.health = 100;
                    hman.maxHealth = 100;
                    Exclam.SetActive(true);
                    Player.GetComponent<PlayerMovement>().enabled = false;
                    if (waiting == false)
                    {
                        waiting = true;
                        StartCoroutine(waiter("Goblin"));
                    }
                    
                }
            }
            if (gameObject.tag == "Troll")
            {
                if (gm != null)
                {
                    hman.health = 160;
                    hman.maxHealth = 160;
                    Exclam.SetActive(true);
                    Player.GetComponent<PlayerMovement>().enabled = false;
                    if (waiting == false)
                    {
                        waiting = true;
                        StartCoroutine(waiter("Troll"));
                    }
                }
            }
            if (gameObject.tag == "Skeleton")
            {
                if (gm != null)
                {
                    hman.health = 300;
                    hman.maxHealth = 300;
                    Exclam.SetActive(true);
                    Player.GetComponent<PlayerMovement>().enabled = false;
                    if (waiting == false)
                    {
                        waiting = true;
                        StartCoroutine(waiter("Skeleton"));
                    }
                }
            }
        }
    }

    IEnumerator waiter(string mob)
    {
        if (mob == "Goblin")
        {
            yield return new WaitForSeconds(2);
            gm.EnterBattle("Goblin");
            waiting = false;
        }
        if (mob == "Troll")
        {
            yield return new WaitForSeconds(2);
            gm.EnterBattle("Troll");
            waiting = false;
        }
        if (mob == "Skeleton")
        {
            yield return new WaitForSeconds(2);
            gm.EnterBattle("Skeleton");
            waiting = false;
        }
        Exclam.SetActive(false);
        gameObject.SetActive(false);
    }
    
}
