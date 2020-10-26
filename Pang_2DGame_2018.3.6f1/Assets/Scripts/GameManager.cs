using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public HealthManager hm;
    public GameObject playerCamera;
    public GameObject battleCamera;
    public GameObject Grid;
    public GameObject Player;
    public GameObject Exclam;
    public GameObject Goblin;
    public GameObject Troll;
    public GameObject Skeleton;
    public Text heartinfo;
    public Text winnerText;

    public bool finalAccess = false;
    public bool inBattle = false;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera.SetActive(true);
        battleCamera.SetActive(false);
        Exclam.SetActive(false);
        winnerText.enabled = false;
        inBattle = false;
    }

    // Update is called once per frame
    void Update()
    {
        heartinfo.text = hm.beatMobs + "/8 Hearts Collected";
        if (hm.beatMobs == 8)
        {
            finalAccess = true;
        }
        if (hm.beatMobs == 9)
        {
            winnerText.enabled = true;
        }
    }
    public void GoToPlayer()
    {
        playerCamera.SetActive(true);
        battleCamera.SetActive(false);
        Exclam.SetActive(false);
        inBattle = false;
    }
    public void EnterBattle(string mob)
    {
        inBattle = true;
        if (mob == "Goblin")
        {
            Goblin.SetActive(true);
            Troll.SetActive(false);
            Skeleton.SetActive(false);
        }
        if (mob == "Troll")
        {
            Goblin.SetActive(false);
            Troll.SetActive(true);
            Skeleton.SetActive(false);
        }
        if (mob == "Skeleton")
        {
            Goblin.SetActive(false);
            Troll.SetActive(false);
            Skeleton.SetActive(true);
        }
        playerCamera.SetActive(false);
        battleCamera.SetActive(true);
    }
}
