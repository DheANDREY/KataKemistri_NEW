using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public Text SkorPlayer1; 
    public Text SkorPlayer2;
    public GameObject buttonFinishGame;
    public GameObject backButton;
    public TextMeshProUGUI angkaGanti;
    private void Update()
    {
        SkorPlayer1.text = skor1.ToString();
        SkorPlayer2.text = skor2.ToString();
        angkaGanti.text = wg.chanceSwap.ToString();
        if(skor1 > 0 || skor2 > 0)
        {
            backButton.SetActive(false);
        }
        else
        {
            backButton.SetActive(true);
        }

        if ((skor1 >= 300 || skor2 >= 300) && (skor1 > skor2 || skor2 > skor1))
        {
            buttonFinishGame.SetActive(true);
            skorCertif();
        }                        
        
        //if((TypingController.instance.timeRemaining1 < 1 && TypingController2.instance.timeRemaining2 < 1) && !isAllPlayerLose)
        //{
        //    //Debug.Log(wg.catSelected);            
        //    wg.catSelected = true;
        //    isAllPlayerLose = true;
        //    AllLose();
        //}

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Player 1: " + TypingController.instance.timeRemaining1);
            Debug.Log("Player 2: " + TypingController2.instance.timeRemaining2);
        }

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
            //ScoreMenu.SetActive(false);
            playerS1.SetActive(true); 
            TypingController.instance.timeRemaining1 = 30f; TypingController2.instance.timeRemaining2 = 30f;
        }
        if (randomPlayer == 1)
        {
            sound_Controller.instance.sfxKlik(); 
            //ScoreMenu.SetActive(false);
            playerS2.SetActive(true); 
            TypingController.instance.timeRemaining1 = 30f; TypingController2.instance.timeRemaining2 = 30f;
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
    public GameObject TutorPanel; public GameObject TutorPanel2;
    public void openTutorial()
    {
        TutorPanel.SetActive(true); TutorPanel2.SetActive(true);
        sound_Controller.instance.sfxKlik();
    }
    public void closeTutorial()
    {
        TutorPanel.SetActive(false); TutorPanel2.SetActive(false);        
    }
    public GameObject settingPanel;
    public void openSetting()
    {
        settingPanel.SetActive(true);
        sound_Controller.instance.sfxKlik();
    }
    public void closeSetting()
    {
        settingPanel.SetActive(false);

    }
    public GameObject panelCongrats;
    public void finishGame0()
    {
        panelCongrats.SetActive(true);
        buttonFinishGame.SetActive(false);
        sound_Controller.instance.sfxKlik();
    }
    public Text SkorWIN; public Text SkorLOSE;
    public Text namaWIN; 
    
    public void skorCertif()
    {
        if(skor1 > skor2)
        {
            SkorWIN.text = skor1.ToString();
            SkorLOSE.text = skor2.ToString();
            namaWIN.text = "A";
        }
        else
        {
            SkorWIN.text = skor2.ToString();
            SkorLOSE.text = skor1.ToString();
            namaWIN.text = "B";
        }
    }
    public void restartGame()
    {
        panelCongrats.SetActive(false);
        buttonFinishGame.SetActive(false);
        ScoreMenu.SetActive(false);
        WordCategoryMenu.SetActive(true);
        skor1 = 0; skor2 = 0;
    }
    private bool isAllPlayerLose = false;
    private void AllLose()
    {
        if (isAllPlayerLose)
        {            
            playerS1.SetActive(false); playerS2.SetActive(false);
            ScoreMenu.SetActive(true);
            TypingController.instance._inputField1.text = ""; 
            TypingController2.instance._inputField2.text = "";
            //wg.catSelected = true;
            wg.chanceSwap = 2;
            isAllPlayerLose = false;
        }
    }

    public GameObject mainMenuPanel;
    public void toWordMenu()
    {
        WordCategoryMenu.SetActive(true); sound_Controller.instance.sfxKlik();
    }
    public void CloseWordMenu()
    {
        WordCategoryMenu.SetActive(false);
        mainMenuPanel.SetActive(true);
    }


}
