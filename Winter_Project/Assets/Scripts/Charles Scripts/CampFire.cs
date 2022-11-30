using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampFire : MonoBehaviour
{
    MateiralBar mateiralBar;
    Timer timer;
    public GameObject mats;
    public GameObject fire;

    // Start is called before the first frame update
    void Start()
    {
        mateiralBar = mats.GetComponent<MateiralBar>();
        timer = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timerRunning == true)
        {
            fire.SetActive(true);
        }
        else
        {
            fire.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E");
                if (mateiralBar.value >= 5f)
                {
                    Debug.Log("10");
                    mateiralBar.Reduce();
                    timer.Begin();
                }

            }
        }
    }
}
