using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionMenuNext : MonoBehaviour
{
    public GameObject[] slides = new GameObject[4];
    GameObject activeSlide;
    public int slideIndex = 1;

    public void nextSlide()
    {
        activeSlide.SetActive(false);
        slideIndex ++;
        activeSlide.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        activeSlide = slides[slideIndex];
    }
}
