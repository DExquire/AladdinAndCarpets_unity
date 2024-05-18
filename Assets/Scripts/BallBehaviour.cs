using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    public Rigidbody2D rb;
    public List<GameObject> charSkins;
    public GameObject jin;
    public GameManager GM;    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(transform.GetChild(0).gameObject);
    }

    void Update()
    {
     
        transform.position = new Vector2(transform.position.x,//Mathf.Clamp(joystick.Horizontal * Time.deltaTime * speed + transform.position.x, -10f, 10f),
           Mathf.Clamp(joystick.Vertical * Time.deltaTime * speed + transform.position.y, -3.5f, 5.5f)
           );

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin"))
        {
            int coins = PlayerPrefs.GetInt("coins");
            GM.gameShop.Coins = coins + 5;
            //shop.Coins += coins;
            PlayerPrefs.SetInt("coins", GM.gameShop.Coins);
            GM.coinsText.text = GM.gameShop.Coins.ToString();
            Destroy(collision.gameObject);
        }
    }
}
