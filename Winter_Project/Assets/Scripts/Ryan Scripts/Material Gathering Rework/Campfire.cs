using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    [SerializeField] private int FuelCost = 3;

    private bool timerRunning = false;
    private float timer;
    [SerializeField] private float reset = 60f;

    private GameObject player;
    [SerializeField] private bool playerNearby = false;

    [SerializeField] private AudioSource audioSource;

    private void Update()
    {
        if(playerNearby == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GatheredMaterials gm = player.GetComponent<GatheredMaterials>();
                if (gm.gatheredWood >= FuelCost)
                {
                    TurnOnFire(gm);
                }
            }
        }
        if (timerRunning == true)
        {
            timer -= Time.deltaTime % 60f;

            if (timer <= 0)
            {
                TurnOffFire();
            }
        }
    }

    private void TurnOnFire(GatheredMaterials gm)
    {
        gm.Reduce(FuelCost);
        timerRunning = true;
        timer += reset;
        fire.SetActive(true);
        audioSource.Play();
        StartCoroutine(FadeMixerGroup.StartFade(audioSource.outputAudioMixerGroup.audioMixer, audioSource.outputAudioMixerGroup.name, 0.3f, 1f));
    }

    private void TurnOffFire()
    {
        timerRunning = false;
        fire.SetActive(false);
        StartCoroutine(stopSFX());
        timer = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        { 
            playerNearby = true; 
            if(player == null)
            {
                player = collision.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") { playerNearby = false; }
    }

    private IEnumerator stopSFX()
    {
        yield return StartCoroutine(FadeMixerGroup.StartFade(audioSource.outputAudioMixerGroup.audioMixer, audioSource.outputAudioMixerGroup.name, 0.3f, 0));
        audioSource.Stop();
    }
}
