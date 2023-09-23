using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerMsgBG;
    private string _playerMessage;
    [SerializeField] private TMP_Text _playerMessageArea;

    private void Start()
    {
        _playerMessageArea.text = "";
        _playerMsgBG.SetActive(false);
    }


    void Update()
    {
        
    }

    public void GameOver()
    {
        _playerMsgBG.SetActive(true);
        _playerMessage = "Game Over! You Are Dead! Have A Nice Day!";
        _playerMessageArea.text = _playerMessage;
        Time.timeScale = 0.0f;
    }


    IEnumerator TurnOffPlayerMsg()
    {
        yield return new WaitForSeconds(3);
        _playerMessage = "";
        _playerMessageArea.text = _playerMessage;
        _playerMsgBG.SetActive(false);
    }

}
