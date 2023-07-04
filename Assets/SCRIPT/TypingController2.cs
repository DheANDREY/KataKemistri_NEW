using UnityEngine;
using UnityEngine.UI;

public class TypingController2 : MonoBehaviour
{
    public Text jawabanPlayer;
    public Image timeFill;
    public float timeRemaining2;
    public float maxTime2 = 100.0f;
    //public string testing = "badak";   
    public static TypingController2 instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        timeRemaining2 = maxTime2;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CekJawaban();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {

        }
        if ((TypingController.instance.timeRemaining1 < 1 && timeRemaining2 < 1) && !isAllLose2)
        {
            isAllLose2 = true;
            AllLose2();
        }
        timeFill.fillAmount = timeRemaining2 / maxTime2;

    }
    public GameObject jawBenar; public GameObject jawSalah;
    public GameObject playerS1; public GameObject playerS2;
    public void CekJawaban()
    {
        string jawabanPemain = jawabanPlayer.text;
       // string jawabanBenar = testing;
        string jawabanBenar = WordGenerator.instance.kataUtama.text;
        Debug.Log(WordGenerator.instance.kataUtama.text);
        //string jawabanBenar = WordGenerator.instance.kataUtama.text;
        if (jawabanPemain.ToLower() == jawabanBenar.ToLower())
        {
            Debug.Log("Anda Benar");
            sound_Controller.instance.sfxJawBenar();
            jawBenar.SetActive(true); jawSalah.SetActive(false);
            Invoke("CorrectAnswer", 3);
        }
        else
        {
            Debug.Log("Anda Salah");
            sound_Controller.instance.sfxJawSalah();
            timeRemaining2 -= 33.3f;
            jawSalah.SetActive(true); jawBenar.SetActive(false);
            Invoke("changePlayer", 4); jawabanPemain = "";
        }
    }
    public InputField _inputField2;
    public void changePlayer()
    {
        playerS1.SetActive(true); playerS2.SetActive(false); jawSalah.SetActive(false);
        _inputField2.text = "";
    }
    public GameObject panelScore;
    public void CorrectAnswer()
    {
        PlayerChoiceNumber.instance.SkorP2(100);
        playerS2.SetActive(false); panelScore.SetActive(true); 
        WordGenerator.instance.catSelected = true;
        WordGenerator.instance.chanceSwap = 2;
        jawBenar.SetActive(false);
        _inputField2.text = "";
    }
    private bool isAllLose2 = false;
    private void AllLose2()
    {
        WordGenerator.instance.catSelected = true;
        if (isAllLose2)
        {
            
            WordGenerator.instance.chanceSwap = 2;
            _inputField2.text = "";
            playerS2.SetActive(false); panelScore.SetActive(true);
            
            isAllLose2 = false;
        }
    }



}