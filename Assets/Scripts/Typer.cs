﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Typer : MonoBehaviour {
    public float letterPause = 0.2f;
    public AudioClip typeSound1;
    public AudioClip typeSound2;

    public string message;
    Text textComp;

    // Use this for initialization
    void Start()
    {
        textComp = GetComponent<Text>();
        message = textComp.text;
        textComp.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            textComp.text += letter;
            //if (typeSound1 && typeSound2)
            // SoundManager.Instance.RandomizeSfx(typeSound1, typeSound2);
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
    }

}
