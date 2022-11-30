using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pickup : MonoBehaviour
{
    MateiralBar mateiralBar;
    public GameObject mats;

    // Start is called before the first frame update
    void Start()
    {
        mateiralBar = mats.GetComponent<MateiralBar>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E");
                mateiralBar.Increase();
                Destroy(gameObject);

            }
        }
    }
}
