using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharpTemelleri : MonoBehaviour
{
    private int score = 0; // Tam sayý deðiþkeni
    private float speed = 5.0f; // Ondalýklý sayý deðiþkeni
    private string playerName = "Oyuncu1"; // Metin deðiþkeni
    private bool isGameOver = false; // Mantýksal deðiþken
    private Vector2 degisken; //(3f,2f)

    // MonoBehaviour Temel Fonksiyonlarý

    private void Awake()
    {
        print("Awake methodu");
    }
    void Start()
    {
        // Oyun baþladýðýnda bir kez çalýþýr
        Debug.Log("Oyun Baþladý! Oyuncu: " + playerName);

        // Döngü Örneði: For Döngüsü
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("For Döngüsü: " + i);
        }
        // Koþul Örneði: If-Else
        if (score == 0)
        {
            Debug.Log("Skor sýfýr, oyuna baþla!");
        }
        else
        {
            Debug.Log("Skor: " + score);
        }
    }
              

    private void Update()
    {
    // Her karede bir çalýþýr
    if (Input.GetKeyDown(KeyCode.Space))
    {
        Debug.Log("Space tuþuna basýldý!");
    }
    // While Döngüsü Örneði
    int count = 0;
    while (count < 2)
    {
           Debug.Log("While Döngüsü: " + count);
           count++;
    }
    }
}

