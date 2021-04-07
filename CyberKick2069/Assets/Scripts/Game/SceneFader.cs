﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneFader : MonoBehaviour
{
    public Image image;
    public AnimationCurve fadeCurve;
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string Scene)
    {
        
        {
        StartCoroutine(FadeOut(Scene));
        }
    }
    IEnumerator FadeIn ()
    {
        float t = 1f;
        
         while (t > 0f)
         {
             t -= Time.deltaTime * 0.5f;
             float a = fadeCurve.Evaluate(t);
             image.color = new Color (0f, 0f ,0f, a);
             yield return 0;
         }
    }

    IEnumerator FadeOut (string _Scene)
    {
        float t = 0f;
        
         while (t < 1f)
         {
             t += Time.deltaTime * 0.5f;
             float a = fadeCurve.Evaluate(t);
             image.color = new Color (0f, 0f ,0f, a);
             yield return 0;
         }

         SceneManager.LoadScene(_Scene);
    }
    
    
}
