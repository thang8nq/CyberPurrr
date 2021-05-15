using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject m_menuStart;
    public GameObject m_menuReplay;
    public Text m_scoreAP;
    public Text m_scoreMenu; 

    // Start is called before the first frame update
    void Start()
    {
        m_menuStart.SetActive(false);
        m_menuReplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        m_scoreAP.text = m_scoreMenu.text = Define.score.ToString();

        if(Define.isGameOver)
        {
            m_menuReplay.SetActive(true);
        }
        else
        {
            m_menuReplay.SetActive(false);
        }

        if(Define.isGameBegin)
        {
            m_menuStart.SetActive(true);
        }
        else
        {
            m_menuStart.SetActive(false);
        }

    }

    public void OnReplayButtonClicked()
    {
        Define.isGameOver = false;
        Define.isGameBegin = true; 
    }

    public void OnStartButtonCliecked()
    {
        Define.isGameBegin = false;
        Time.timeScale = 1;
        Define.score = 0;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
