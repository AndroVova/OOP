using UnityEngine;

public class Visuals : MonoBehaviour
{
    public GameObject ResetButton;
    public GameObject BackButton;
    public GameObject winText;
    public GameObject loseText;    
    public GameObject player;

    private GameObject[] enemies;

    public bool gameIsActive;

    void Start()
    {
        gameIsActive = true;
        BackButton.SetActive(false);
        ResetButton.SetActive(false);
        winText.SetActive(false);
        loseText.SetActive(false);
    }

    void Update()
    {
        if (gameIsActive)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length == 0 || player == null)
            {
                gameIsActive = false;
                EndOfGame();
            }
        }
    }

    private void EndOfGame()
    {
        ResetButton.SetActive(true);
        BackButton.SetActive(true);        

        if (enemies.Length == 0 && player != null)
        {
            FindObjectOfType<Player>().StopPlayer();
            winText.SetActive(true);
        }
        else if (player == null)
        {
            winText.SetActive(false);
            loseText.SetActive(true);
        }
    }
}
