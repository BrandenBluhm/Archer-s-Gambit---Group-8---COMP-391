using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{

    private int coins = 0;
    private int arrows = 5;

    [SerializeField] private Text coinsText;
    [SerializeField] private Text arrowsText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++;
            coinsText.text = "   " + coins;
        }
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Destroy(collision.gameObject);
            arrows = arrows + 5;
            arrowsText.text = "      " + arrows;
        }


    }
}
