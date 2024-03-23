using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Game game;
    private Vector3 startPosition;

    private void Awake()
    {
        game = FindObjectOfType<Game>();
        if (game != null) Debug.Log("Не найден скрипт Game.");
    }

    private void Start()
    {
        startPosition = transform.position;
    }

    public void TakeDamage()
    {
        game.LoseLife();
        transform.position = startPosition;
    }
}
