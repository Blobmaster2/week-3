using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject GoalUI;

    GameObject player;

    public static GameManager Instance;

    private void Start()
    {
        Instance = this;
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (player.transform.position.y < -20)
        {
            GameOver();
        }
    }

    public static void GameOver()
    {
        Instance.GameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public static void YouWin()
    {
        Instance.GoalUI.SetActive(true);
        Time.timeScale = 0;
    }
}
