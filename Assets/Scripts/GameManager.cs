using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;
    public List<GameObject> ShuffledCard = new List<GameObject>(20);
    public GameObject[] referanceobjects;
    public GameObject one;
    public GameObject two;
    public int clickCount;
    public int correctCard;
    public int tuenCount;
    public bool Checking;
    public GameObject grid;
    public GameObject win;
    public int turnCount;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Turns;

    public AudioSource source;
    public AudioClip winAudio,misMatch,tap;
    private void Start()
    {
        Debug.Log(ShuffledCard.Count);
        instance = this;
        ShuffleList(ShuffledCard);
        Spwan();
    }

    private void Update()
    {
        if (correctCard == ShuffledCard.Count/2)
        {
            WinningFuntion();
        }
    }
    public void WinningFuntion()
    {
        Debug.Log("WIN");
        win.SetActive(true);
    }
    public void turnCounter()
    {
        tuenCount = clickCount / 2;
    }
    public void CheckCard()
    {
        if (one.GetComponent<Card>().card.CardName == two.GetComponent<Card>().card.CardName)
        {
            Corret();
            source.PlayOneShot(winAudio);
        }
        else
        {
            NotCorrect();
            source.PlayOneShot(misMatch);
        }
        Invoke("CheckigOff", 0.2f);
    }
    public void CheckigOff()
    {
        Checking = false;
    }
    public void Corret()
    {
        
        correctCard++;
        turnCount++;
        Turns.text = turnCount.ToString();
        //score
        Debug.Log("Correct");
        Score.text = correctCard.ToString();
    }
    public void NotCorrect()
    {
        turnCount++;
        Turns.text = turnCount.ToString();
        one.GetComponent<Animator>().SetBool("on",false);
        two.GetComponent<Animator>().SetBool("on",false);
        Debug.Log("NotCorrect");
        one.GetComponent<Card>().clicked = false;
        two.GetComponent<Card>().clicked = false;
        
    }
    public void Spwan()
    {
        int x = 0;

        while (x < ShuffledCard.Count)
        {
            GameObject obj;
            obj=Instantiate(ShuffledCard[x], grid.transform.position, grid.transform.rotation);
            obj.transform.SetParent(grid.transform);
            x++;
        }
        ShuffleList(ShuffledCard);
    }

    void ShuffleList(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            GameObject temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public void dificulty()
    {
        SceneManager.LoadScene(1);
    }
    public void home()
    {
        SceneManager.LoadScene(0);
        win.SetActive(false);
    }
    public void easy()
    {
        SceneManager.LoadScene(2);
    }
    public void medium()
    {
        SceneManager.LoadScene(3);
    }
    public void hard()
    {
        SceneManager.LoadScene(4);
    }
    public void CheckigsOff()
    {
        Checking = false;
    }
}

