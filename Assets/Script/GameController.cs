using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int _CurrentBlockNum;
    public GameObject gameClearText;
    public GameObject gameOverText;
    public GameObject ball;
    public static GameController Instance { get; private set; }
    public int BlockNum = 36;
    void Start()
    {
        Instance = this;
        _CurrentBlockNum = BlockNum;

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        Destroy(ball);

    }
    public void BlockBreak()
    {
        _CurrentBlockNum--;
        if (_CurrentBlockNum == 0)
        {
            gameClearText.SetActive(true);
            Destroy(ball);
        }

    }




}
