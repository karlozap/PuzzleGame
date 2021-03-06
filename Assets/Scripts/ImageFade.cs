﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFade : MonoBehaviour
{

    // the image you want to fade, assign in inspector
    public Image img;
    public float fadeSpeed = 1f;

    public bool startfade = false;


    public bool fadeaway = true;
    
    

    void Start()
    {
        // fades the image out when you click
        StartCoroutine(FadeImage(true));
    }

    private void Update()
    {
        if (startfade)
        {
            StartCoroutine(FadeImage(fadeaway));
            startfade = false;
        }
    }

    public IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            yield return new WaitForSeconds(1f);
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime/5 * fadeSpeed)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                i -= Time.deltaTime/5;
                yield return new WaitForEndOfFrame();
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime / 5 * fadeSpeed)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                i += Time.deltaTime/5;
                yield return null;
            }
        }
    }
}