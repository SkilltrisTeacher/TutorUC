using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
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
        PlayerUI.ui.AddCoin();
        Destroy(gameObject);
    }
}
