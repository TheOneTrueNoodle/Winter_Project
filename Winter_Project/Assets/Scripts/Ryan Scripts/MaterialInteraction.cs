using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;

public class MaterialInteraction : MonoBehaviour
{
    [SerializeField] private bool playerNearby;

    private int remainingWood;

    private void Start()
    {
        remainingWood = Random.Range(2, 6);
    }

    private void Update()
    {
        if(playerNearby)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                OnMaterialGathered();
            }
        }
    }
    private void OnMaterialGathered()
    {
        Vector3 quadPosition = transform.position;
        Vector3 direction = Random.insideUnitCircle.normalized;

        MaterialParticleSystemHandler.Instance.SpawnFragment(quadPosition, direction);
        remainingWood--;
        if(remainingWood <= 0) { Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") { playerNearby = true; }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player") { playerNearby = false; }
    }
}
