using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinCost = 1;
    [SerializeField] private string playerLayer = "Player";
    private bool isCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer(playerLayer)) return;
        PickCoin();
    }

    private void PickCoin()
    {
        if (isCollected) return;
        isCollected = true;
        Game game = FindObjectOfType<Game>();
        if (game != null) game.AddCoins(coinCost);
        else Debug.Log("Не найден скрипт Game.");
        Destroy(gameObject);
    }
}
