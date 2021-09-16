using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public Text scoreText;
    public Text orotext;
    public Text platatext;
    public Text bronzetext;
    
    private int _score = 0;
    private int _scoreoro = 0;
    private int _scoreplata = 0;
    private int _scorebronze = 0;
    private int addmoneda= 1; 

    private void Start()
    {
        scoreText.text = "Puntos: " + _score;
        orotext.text = "Monedas de Oro: " + _scoreoro;
        platatext.text = "Monedas de Plata: " + _scoreplata;
        bronzetext.text = "Monedas de Bronze: " + _scorebronze;
      
    }
    private void update(){
            scoreText.text = "Puntos: " + _score;
            orotext.text = "Monedas de Oro: " + _scoreoro;
            platatext.text = "Monedas de Plata: " + _scoreplata;
            bronzetext.text = "Monedas de Bronze: " + _scorebronze;
    }

    public int GetScore()
    {
        return _score;
    }
    public void addpuntos(int puntos){
        _score += puntos;
        scoreText.text = "Puntos: " + _score;
    }
    public void addMonedas(string moneda)
    {
        if (moneda == "oro"){
        _scoreoro += addmoneda;
        orotext.text = "Monedas de: " + _scoreoro;
        }
        if (moneda == "plata"){
        _scoreplata += addmoneda;
        platatext.text = "Monedas de: " + _scoreplata;
        }
        if (moneda == "bronze"){
        _scorebronze += addmoneda;
        bronzetext.text = "Monedas de: " + _scorebronze;
        }
    }

   
}
