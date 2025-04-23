using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniJeu : MonoBehaviour
{
    public float pointageTemps;
    public TextMeshProUGUI textScore;

    public TextMeshProUGUI textScorePanneau; //FAIT EN CLASSE
    public TMP_InputField inputNom;

    [SerializeField] GameObject panneauRecord; //VARIABLE CRÉÉ EN CLASSE

    void Start()
    {

       // PlayerPrefs.DeleteAll(); //detruire toutes les info enregistrés (suprimer apres tes) FAIT EN CLASSE
        pointageTemps = 0;
    }

    private void Update()
    {
        textScore.text = pointageTemps.ToString("00.00");
    }


    //NOUVELLES FUNCTIONS CRÉÉS EN CLASSE
    public void TraiterDefaite()
    {
       
        Debug.Log("Defaite!");

        float recordActuel = PlayerPrefs.GetFloat("meilleurScoreTemps", 0f);
        if (pointageTemps >= recordActuel)
        {
            Invoke("MontrerPanneauNouveauRecord", 3f);
        }
        
    }

    void MontrerPanneauNouveauRecord()
    {
        Debug.Log("NOUVEAU RECORD");

        panneauRecord.SetActive(true);
        textScorePanneau.text = textScore.text;
    }

    public void EnregistrerNomRecord()
    {
        string nom = inputNom.text;
        PlayerPrefs.SetString("nom", nom);

        //Redemarre la scene actuel
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

