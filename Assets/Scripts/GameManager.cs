using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Feature futura
    //float tempo

    [Header("Dialogue Box Settings")]
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] float textSpeed;
    [SerializeField] AudioSource dialogBoxAudioSource;
    bool isTyping = false;


    public static GameManager instance;
    //[SerializeField] GameObject playerPrefab;

    // Cinemachine
    [Header("Cinemachine")]
    [SerializeField] CinemachineVirtualCamera virtualCamera;

    public int playerScore;



    void Start()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Time.timeScale = 0f;
    }

    public void EndGame()
    {
        if (Player.instance.FoundObjective)
        {
            GivePointsByTime();
            playerScore = Player.instance.PlayerScore;
            SceneManager.LoadScene("Game Over");
        }
        else
        {
            SceneManager.LoadScene("DERROTA");
        }
    }


    /*
    public void RestartGame(Transform savePointPosition, Player player)
    {

        Destroy(player.gameObject);

        GameObject newPlayer = Instantiate(playerPrefab, savePointPosition.position, Quaternion.identity);

        UIImageFillManager.Instance.UpdateGlitterImage(1);

        virtualCamera.Follow = newPlayer.transform;
    }*/

    public void StartDialogue(string lines)
    {
        
        if (!dialoguePanel.activeInHierarchy)
        {
            dialoguePanel.SetActive(true);
        }
        dialogueText.text = string.Empty;

        
        StartCoroutine(TypeText(lines));


    }

    IEnumerator TypeText(string text)
    {
        
        isTyping = true;

        foreach(char c in text.ToCharArray())
        {
            dialogBoxAudioSource.Play();
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        

        isTyping = false;

        yield return new WaitForSeconds(1f);

        if(!isTyping)
            dialoguePanel.SetActive(false);

    }

    private void GivePointsByTime()
    {
        TimeManager.Instance.ApplyTimeBonus();
    }

    public void GetPlayerScore()
    {
        playerScore = Player.instance.PlayerScore;
    }

}
