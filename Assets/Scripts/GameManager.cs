using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float GameDuration = 30f;
    public float CurrentTime = 0f;

    public delegate void GameEnd(bool won);
    public event GameEnd OnGameEnd;

    private List<GameObject> targets;
    private bool gameEnded = false;

    static private GameManager instance;
    static public GameManager Inst
    {
        get => instance;
        set { }
    }

    public float ResetTime = 5f;

    private float timeBeforeReset = -1f; // Negative value means that countdown is inactive
    public float TimeBeforeReset { get => timeBeforeReset; set { } }

    private void Awake()
    {
        instance = this;
        targets = new List<GameObject>();
    }

    private void Update()
    {
        if (gameEnded) return;
        CurrentTime += Time.deltaTime;

        if (CurrentTime >= GameDuration)
        {
            EndGame(false);
        }
    }

    public void AddTarget(GameObject target)
    {
        targets.Add(target);
    }

    public void RemoveTarget(GameObject target)
    {
        targets.Remove(target);
        if (targets.Count == 0)
        {
            EndGame(true);
        }
    }

    public void EndGame(bool won)
    {
        if (!gameEnded)
        {
            //Debug.Log($"END: {won}; listeners{OnGameEnd.GetInvocationList().Length}");
            StartCountdown();
            gameEnded = true;
            OnGameEnd?.Invoke(won);
        }
    }

    private void StartCountdown()
    {
        timeBeforeReset = ResetTime;
    }

    private void ResetGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private void FixedUpdate()
    {
        if (timeBeforeReset <= 0f)
            return;

        timeBeforeReset = Mathf.Max(timeBeforeReset - Time.fixedDeltaTime, 0f);

        if (timeBeforeReset == 0f)
            ResetGame();
    }
}
