using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public GameObject startPanel, gamePanel, endPanel, winPanel;
    public Text workText, enterText, smallerText, biggerText, triesCounterText, rightNumberText, rightNumberWinText, triesCounterWinText;
    public AudioSource welcome, welcomeLine, iWillChoose, iAmReady, smallerThan, biggerThan, win, gameOver;
    public Button startBtn;
    private int randomNumber, triesCouter = 0;
    

    void Start()
    {
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        endPanel.SetActive(false);
        winPanel.SetActive(false);
        GivemeRandomNumber();
        StartSound();
    }
    
    public void StartBtn()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    void GivemeRandomNumber()
    {
        randomNumber = Random.Range(1, 100);
    }

    public void WriteTheNumberBtn(int num)
    {
        if (workText.text == "--" )
            workText.text = "";
        if (workText.text.Length <= 1)
        {
            switch (num)
            {
                case 0: workText.text += num.ToString(); break;
                case 1: workText.text += num.ToString(); break;
                case 2: workText.text += num.ToString(); break;
                case 3: workText.text += num.ToString(); break;
                case 4: workText.text += num.ToString(); break;
                case 5: workText.text += num.ToString(); break;
                case 6: workText.text += num.ToString(); break;
                case 7: workText.text += num.ToString(); break;
                case 8: workText.text += num.ToString(); break;
                case 9: workText.text += num.ToString(); break;
            }
        }
    }

    public void BackSpaceBtn()
    {
        if (workText.text.Length > 0)
            workText.text = workText.text.Remove(workText.text.Length - 1, 1);
    }

    public void EnterBtn()
    {   
        int theNumber = int.Parse(workText.text);

        triesCouter++;
        triesCounterText.text = triesCouter.ToString();
        enterText.gameObject.SetActive(false);
        workText.text = "";

        if (randomNumber > theNumber)
        {
            smallerText.gameObject.SetActive(false);
            biggerText.gameObject.SetActive(true);
            if (triesCouter < 7) PlaySound(6);
        }
        else if (randomNumber < theNumber)
        {
            biggerText.gameObject.SetActive(false);
            smallerText.gameObject.SetActive(true);
            if (triesCouter < 7) PlaySound(5);

        }
        else
        {
            gamePanel.SetActive(false);
            winPanel.SetActive(true);
            PlaySound(7);
            rightNumberWinText.text = randomNumber.ToString();
            triesCounterWinText.text = triesCouter.ToString();
            return;
        }

        if(triesCouter >= 7)
        {
            gamePanel.SetActive(false);
            endPanel.SetActive(true);
            PlaySound(8);
            rightNumberText.text = randomNumber.ToString();
        }
    }

    public void NewGameBtn()
    {
        biggerText.gameObject.SetActive(false);
        smallerText.gameObject.SetActive(false);
        enterText.gameObject.SetActive(true);
        workText.text = "--";
        triesCouter = 0;
        triesCounterText.text = "0";
        GivemeRandomNumber();
        gamePanel.SetActive(true);
        endPanel.SetActive(false);
        winPanel.SetActive(false);
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    private async void  StartSound()
    {
        PlaySound(1);
        await Task.Delay(3200);
        PlaySound(2);
        await Task.Delay(2200);
        PlaySound(3);
        await Task.Delay(6300);
        PlaySound(4);
        await Task.Delay(1800);
        startBtn.interactable = true;
    }
    public void PlaySound(int soundNum)
    {
        switch (soundNum)
        {
            case 1:welcome.Play(); break;
            case 2: welcomeLine.Play(); break;
            case 3: iWillChoose.Play(); break;
            case 4: iAmReady.Play(); break;
            case 5: smallerThan.Play(); break;
            case 6: biggerThan.Play(); break;
            case 7: win.Play(); break;
            case 8: gameOver.Play(); break;
        }
    }
    
}
