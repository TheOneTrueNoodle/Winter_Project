using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public GameObject theSUN;
    public bool day = false;
    public bool night = false;
    public float timer = 120f;
    public float reset = 120f;

    // Start is called before the first frame update
    void Start()
    {
     day = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (day == true)
        {
            theSUN.SetActive(true);
        }

        if (night == true)
        {
            theSUN.SetActive(false);
        }

        if (day == true)
        {
            timer -= Time.deltaTime % 60f;

            if (timer <= 0)
            {
                day = false;
                night = true;
                timer = reset;

            }
        }

        if (night == true)
        {
            timer -= Time.deltaTime % 60f;

            if (timer <= 0)
            {
                night = false;
                day = true;
                timer = reset;

            }
        }

    }
}
