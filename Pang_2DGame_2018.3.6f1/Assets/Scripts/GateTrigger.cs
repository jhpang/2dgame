using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    private GameManager gm;
    public HealthManager hm;

    public Text infoText;
    public GameObject canvas;
    public GameObject Player;
    public GameObject Gate;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<PlayerMovement>())
        {
            if (gameObject.tag == "Gate")
            {
                if (gm != null)
                {
                    if (hm.beatMobs < 8)
                    {
                        Player.GetComponent<PlayerMovement>().enabled = false;
                        canvas.SetActive(true);
                        infoText.text = "You do not have enough hearts to pass this gate, defeat more monsters and gain enough hearts!";
                        StartCoroutine(waiter());
                    }
                    if (hm.beatMobs >= 8)
                    {
                        Player.GetComponent<PlayerMovement>().enabled = false;
                        canvas.SetActive(true);
                        infoText.text = "You have collected enough monster hearts, the gate now opens!";
                        Gate.SetActive(false);
                        StartCoroutine(waiter());
                    }
                }
            }
        }
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
        Player.GetComponent<PlayerMovement>().enabled = true;
        canvas.SetActive(false);
    }
}
