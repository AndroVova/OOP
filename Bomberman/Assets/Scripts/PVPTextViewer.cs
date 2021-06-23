using UnityEngine;

public class PVPTextViewer : MonoBehaviour
{
    public GameObject ResetButton;
    public GameObject BackButton;
    public GameObject player1WinText;
    public GameObject player2WinText;
    public GameObject drawText;
    public GameObject resetter;

    public GameObject player1;
    public GameObject player2;


    void Start()
    {
        BackButton.SetActive(false);
        ResetButton.SetActive(false);
        player1WinText.SetActive(false);
        player2WinText.SetActive(false);
        drawText.SetActive(false);
    }


    void Update()
    {
        if (player1 == null || 
            player2 == null)
            EndOfGame();
    }
    private void EndOfGame()
    {
        ResetButton.SetActive(true);
        BackButton.SetActive(true);
        resetter.SetActive(false);

        if(player1 == null && player2 != null ||
           player1 != null && player2 == null)
            FindObjectOfType<Player>().StopPlayer();
        if (player1 != null && 
            player2 == null)
        {            
            player1WinText.SetActive(true);
        }
        else if (player1 == null && 
                 player2 != null)
        {
            player2WinText.SetActive(true);
        }
        else if (player1 == null && 
                 player2 == null)
        {
            player1WinText.SetActive(false);
            player2WinText.SetActive(false);
            drawText.SetActive(true);
        }
    }
}
