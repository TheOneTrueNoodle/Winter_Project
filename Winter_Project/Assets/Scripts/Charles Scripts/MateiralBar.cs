using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MateiralBar : MonoBehaviour
{
    private Slider slider;
    public float fill = 10f;
    public float lower = 5f;
    public float value;
    public bool increase = false;
    public bool reduce = false;

    void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        value = slider.value;

        if (increase == true)
        {
            slider.value += fill;
            increase = false;
        }

        if (reduce == true)
        {
            slider.value -= lower;
            reduce = false;
        }
    }

    public void Increase()
    {
        increase = true;
    }

    public void Reduce()
    {
        reduce = true;
    }
}
