using UnityEngine;
using UnityEngine.UI;

public class TypingController : MonoBehaviour
{
    public Text jawabanPlayer;
    public Image timeFill;
    public float timeRemaining1;
    public float maxTime1 = 100.0f;
    //public string testing = "badak";
    public static TypingController instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        timeRemaining1 = maxTime1;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CekJawaban();
        }
        if ((timeRemaining1 < 1 && TypingController2.instance.timeRemaining2 < 1) && !isAllLose1)
        {
            isAllLose1 = true;
            AllLose1();
        }
        timeFill.fillAmount = timeRemaining1 / maxTime1;


    }
    public GameObject jawBenar;    public GameObject jawSalah;
    public GameObject playerS1;    public GameObject playerS2;
    public InputField _inputField1;
    public void CekJawaban()
    {
        string jawabanPemain = jawabanPlayer.text;
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
            timeRemaining1 -= 33.3f;
            timeFill.fillAmount = timeRemaining1 / maxTime1;
            jawSalah.SetActive(true); jawBenar.SetActive(false);
            Invoke("changePlayer", 4); 
        }
    }
    public void changePlayer()
    {
        playerS2.SetActive(true); playerS1.SetActive(false); jawSalah.SetActive(false);
        _inputField1.text = "";        
    }
    public GameObject panelScore;
    public void CorrectAnswer()
    {
        PlayerChoiceNumber.instance.SkorP1(100);
        playerS1.SetActive(false); panelScore.SetActive(true); 
        WordGenerator.instance.catSelected = true;
        WordGenerator.instance.chanceSwap = 2;
        jawBenar.SetActive(false);
        _inputField1.text = "";
    }
    private bool isAllLose1 = false;
    private void AllLose1()
    {
        WordGenerator.instance.catSelected = true;
        if (isAllLose1)
        {            
            WordGenerator.instance.chanceSwap = 2;
            _inputField1.text = "";
            playerS1.SetActive(false); panelScore.SetActive(true);
            
            isAllLose1 = false;
        }
    }

}
