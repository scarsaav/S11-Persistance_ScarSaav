using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeilleurScoreTemps : MonoBehaviour
{
    public float meilleurScore = 0f;
    public TextMeshProUGUI textMeilleurScore;

    private MiniJeu _jeu;

    private void Start()
    {
        _jeu = GetComponent<MiniJeu>();

        meilleurScore = PlayerPrefs.GetFloat("meilleurScore", 0f);
        string nom = PlayerPrefs.GetString("nom", "");
        textMeilleurScore.text = "Meilleur score de "+ nom + "" + meilleurScore.ToString("00.00");
    }

    private void Update()
    {
        if(_jeu.pointageTemps  > meilleurScore) //pointageTemps=c'est le pointage actuel et cette function est pour voir si mon pointage actuel est meilleur que l'anterieur
        {
            meilleurScore = _jeu.pointageTemps;

            PlayerPrefs.SetFloat("meilleurScore", meilleurScore);
            textMeilleurScore.text = "Nouveau meilleur score! " + meilleurScore.ToString("00.00");
        }
    }
}
