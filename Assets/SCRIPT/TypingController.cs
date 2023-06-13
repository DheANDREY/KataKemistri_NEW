using UnityEngine;
using UnityEngine.UI;

public class TypingController : MonoBehaviour
{
    public Text jawabanPlayer;
    public string testing = "badak";
    public static TypingController instance;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CekJawaban();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {

        }
    }
    public GameObject jawBenar;    public GameObject jawSalah;
    public GameObject playerS1;    public GameObject playerS2;
    public void CekJawaban()
    {
        string jawabanPemain = jawabanPlayer.text;
        string jawabanBenar = testing;
        //string jawabanBenar = WordGenerator.instance.kataUtama.text;
        if (jawabanPemain.ToLower() == jawabanBenar.ToLower())
        {
            Debug.Log("Anda Benar");
            jawBenar.SetActive(true); jawSalah.SetActive(false);
            Invoke("CorrectAnswer", 3);
        }
        else
        {
            Debug.Log("Anda Salah");
            jawSalah.SetActive(true); jawBenar.SetActive(false);
            Invoke("changePlayer", 4); jawabanPemain = "";
        }
    }
    public void changePlayer()
    {
        playerS1.SetActive(false); jawSalah.SetActive(false); playerS2.SetActive(true);
    }
    public GameObject panelScore;
    public void CorrectAnswer()
    {
        PlayerChoiceNumber.instance.SkorP1(100);
        playerS1.SetActive(false); panelScore.SetActive(true); jawBenar.SetActive(false);
    }

}
