using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChoiceNumber : MonoBehaviour
{
    public GameObject WordCategoryMenu;
    public GameObject ScoreMenu;
    public WordGenerator wg;
    public static PlayerChoiceNumber instance;
    private void Awake()
    {
        instance = this;
    }
    public Text SkorPlayer1; public Text SkorPlayer2;
    private void Update()
    {
        SkorPlayer1.text = skor1.ToString();
        SkorPlayer2.text = skor2.ToString();
    }
    public int numbPlayer;
    public void binatangOK()
    {
        wg.catSelected = true;
        numbPlayer = 0; sound_Controller.instance.sfxKlik();
        WordCategoryMenu.SetActive(false);
        ScoreMenu.SetActive(true);
    }
    public void tumbuhanOK()
    {
        wg.catSelected = true;
        numbPlayer = 1; sound_Controller.instance.sfxKlik();
        WordCategoryMenu.SetActive(false);
        ScoreMenu.SetActive(true);
    }
    public void bendaOK()
    {
        wg.catSelected = true;
        numbPlayer = 2; sound_Controller.instance.sfxKlik();
        WordCategoryMenu.SetActive(false);
        ScoreMenu.SetActive(true);
    }
    public void acakOK()
    {
        wg.catSelected = true;
        numbPlayer = 3; sound_Controller.instance.sfxKlik();
        WordCategoryMenu.SetActive(false);
        ScoreMenu.SetActive(true);
    }
    public void backCategory()
    {
        ScoreMenu.SetActive(false);
        WordCategoryMenu.SetActive(true);
        WordGenerator.instance.kataUtama.text = "";
    }

    public GameObject playerS1; public GameObject playerS2;
    public void StartGame()
    {
        int randomPlayer = Random.Range(0, 2);
        if(randomPlayer == 0)
        {
            sound_Controller.instance.sfxKlik();
            playerS1.SetActive(true);
        }
        else
        {
            sound_Controller.instance.sfxKlik();
            playerS2.SetActive(true);
        }
    }

    private int skor1 = 0;
    public void SkorP1(int nilai)
    {
        skor1 += nilai;
    }
    public int ScorePanel1
    {
        get { return skor1; }
    }

    private int skor2 = 0;
    public void SkorP2(int nilai)
    {
        skor2 += nilai;
    }
    public int ScorePanel2
    {
        get { return skor2; }
    }
    public GameObject TutorPanel;
    public void openTutorial()
    {
        TutorPanel.SetActive(true);
    }
    public void closeTutorial()
    {
        TutorPanel.SetActive(false);
    }
}
