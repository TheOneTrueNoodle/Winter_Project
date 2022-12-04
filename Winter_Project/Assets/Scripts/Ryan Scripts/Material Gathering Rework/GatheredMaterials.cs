using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GatheredMaterials : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public int gatheredWood;

    private void Update()
    {
        slider.value = gatheredWood;
    }

    public void Increase(int value)
    {
        gatheredWood += value;
        if(gatheredWood >= 10)
        {
            gatheredWood = 10;
        }
    }

    public void Reduce(int value)
    {
        gatheredWood -= value;
        if (gatheredWood <= 0)
        {
            gatheredWood = 0;
        }
    }
}
