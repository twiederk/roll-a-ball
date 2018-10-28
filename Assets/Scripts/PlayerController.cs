using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float Speed;
    public Movement Movement;
    public Text countText;
    public Text winText;
    public Text timeText;

    private int count;
    private bool playerWon;
    private float startTime;

    private Rigidbody rb;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        SetCountText();
        timeText.text = "";
        startTime = Time.time;
        Movement = new Movement(Speed);
    }

    void FixedUpdate()
    {
        float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = Movement.Calculate(moveHorizontal, moveVertical);

        rb.AddForce(movement);


        if (!playerWon)
        {
            float passedTime = Time.time - startTime;
            timeText.text = "Time: " + passedTime.ToString("0.##");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    public string SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You win!";
            playerWon = true;
            Invoke("Restart", 2.0f);

        }
        return winText.text;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
