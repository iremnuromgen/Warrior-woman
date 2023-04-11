using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public GameObject textSkor;
    public Text Skor;
    public int toplamElmas;
    
    
    void Start()
    {
        Skor = textSkor.GetComponent<Text>();
        toplamElmas = 0;

        Skor.text = toplamElmas.ToString();
    }

    
    void Update()
    {
        Skor.text = "Score : " + toplamElmas.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Coin")
        {
            toplamElmas++;
        }
    }

   
}
