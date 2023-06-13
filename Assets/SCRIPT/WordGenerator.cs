using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordGenerator : MonoBehaviour
{
    public Text kataUtama;
    string[] kataBinatang = new string[] { "Kucing", "Anjing", "Kuda", "Lele" };
    string[] kataTumbuhan = new string[] { "Padi", "Kaktus", "Cemara", "Eceng Gondok" };
    string[] kataBenda = new string[] { "Kursi", "Pulpen", "Kemeja", "Pintu" };
    public static int randomIndex;
    public bool catSelected = false;

    public static WordGenerator instance;
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        int playerNumb = PlayerChoiceNumber.instance.numbPlayer;
        if (catSelected)
        {
            switch (playerNumb)
            {
                case 0:
                    startBinatang();
                    break;
                case 1:
                    startTumbuhan();
                    break;
                case 2:
                    startBenda();
                    break;
                case 3:
                    startRandom();
                    break;
            }
            catSelected = false;
        }
    }

    private void startRandom()
    {
        int randomCategory = Random.Range(0, 3); // Mengacak angka dari 0 hingga 2
        switch (randomCategory)
        {
            case 0:
                randomIndex = Random.Range(0, kataBinatang.Length);
                kataUtama.text = kataBinatang[randomIndex];
                break;
            case 1:
                randomIndex = Random.Range(0, kataTumbuhan.Length);
                kataUtama.text = kataTumbuhan[randomIndex];
                break;
            case 2:
                randomIndex = Random.Range(0, kataBenda.Length);
                kataUtama.text = kataBenda[randomIndex];
                break;
        }
    }
    private void startBinatang()
    {
        randomIndex = Random.Range(0, kataBinatang.Length);
        kataUtama.text = kataBinatang[randomIndex];
    }
    private void startTumbuhan()
    {
        randomIndex = Random.Range(0, kataTumbuhan.Length);
        kataUtama.text = kataTumbuhan[randomIndex];
    }
    private void startBenda()
    {
        randomIndex = Random.Range(0, kataTumbuhan.Length);
        kataUtama.text = kataBenda[randomIndex];
    }
    private int chanceSwap = 2;
    public void gantiKata()
    {
        chanceSwap -= 1;
        if (chanceSwap >= 0)
        {
            catSelected = true;
            Debug.Log("sisa= "+ chanceSwap);
        }
    }
}
