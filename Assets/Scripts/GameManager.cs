using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject first;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void game()
    {
        SceneManager.LoadScene(1);
    }
    public void home()
    {
        SceneManager.LoadScene(0);
    }

}
