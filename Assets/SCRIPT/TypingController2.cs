using UnityEngine;
using UnityEngine.UI;

public class TypingController2 : MonoBehaviour
{
    public Text jawabanPlayer;
    public string testing = "badak";
    public sound_Controller SoC;
    public static TypingController2 instance;
    private void Awake()
    {
        instance = this;
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
            jawSalah.SetActive(true); jawBenar.SetActive(false);
            Invoke("changePlayer", 4); jawabanPemain = "";
        }
    }
    public InputField _inputField2;
    public void changePlayer()
    {
        playerS2.SetActive(false); jawSalah.SetActive(false); playerS1.SetActive(true);
        _inputField2.text = "";
    }
    public GameObject panelScore;
    public void CorrectAnswer()
    {
        PlayerChoiceNumber.instance.SkorP2(100);
        playerS2.SetActive(false); panelScore.SetActive(true); WordGenerator.instance.catSelected = true;
        WordGenerator.instance.chanceSwap = 2;
        jawBenar.SetActive(false);
        _inputField2.text = "";
    }


}