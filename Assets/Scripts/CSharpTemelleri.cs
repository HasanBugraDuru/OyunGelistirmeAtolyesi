using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharpTemelleri : MonoBehaviour
{
    private int score = 0; // Tam say� de�i�keni
    private float speed = 5.0f; // Ondal�kl� say� de�i�keni
    private string playerName = "Oyuncu1"; // Metin de�i�keni
    private bool isGameOver = false; // Mant�ksal de�i�ken
    private Vector2 degisken; //(3f,2f)

    // MonoBehaviour Temel Fonksiyonlar�

    private void Awake()
    {
        print("Awake methodu");
    }
    void Start()
    {
        // Oyun ba�lad���nda bir kez �al���r
        Debug.Log("Oyun Ba�lad�! Oyuncu: " + playerName);

        // D�ng� �rne�i: For D�ng�s�
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("For D�ng�s�: " + i);
        }
        // Ko�ul �rne�i: If-Else
        if (score == 0)
        {
            Debug.Log("Skor s�f�r, oyuna ba�la!");
        }
        else
        {
            Debug.Log("Skor: " + score);
        }
    }
              

    private void Update()
    {
    // Her karede bir �al���r
    if (Input.GetKeyDown(KeyCode.Space))
    {
        Debug.Log("Space tu�una bas�ld�!");
    }
    // While D�ng�s� �rne�i
    int count = 0;
    while (count < 2)
    {
           Debug.Log("While D�ng�s�: " + count);
           count++;
    }
    }
}

