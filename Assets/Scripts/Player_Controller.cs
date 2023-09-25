using System.Collections;
using System.Collections.Generic;
//using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    
    public float speed;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI winText;

    private Rigidbody rb;
    private int count;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            setCountText();
        }
    }

    private void setCountText()
    {
        countText.text = "Count : " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}