using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cards(int sloats)
    {
        switch (sloats)
        {
            case 1:if (sloats == 1)
                {
                    Debug.Log("destroy");
                }
            break;
        }
    }
    public void game()
    {
        //mainMenu.SetActive(false);
        SceneManager.LoadScene(1);
    }
    public void home()
    {
        //mainMenu.SetActive(true);
        SceneManager.LoadScene(0);
    }

}
