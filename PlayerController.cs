using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public Text scoreTextFinal;
    Rigidbody2D rb;
    [SerializeField] float flapForce = 5000;
    [SerializeField] int score = 0;
    [SerializeField] float yBounds1 = 5.5f;
    [SerializeField] float yBounds2 = -5.5f;
    [SerializeField] int highScore;
    public GameObject Panel;
    private Animator anim;
   
    // Start is called before the first frame update
    private void Awake() 
    {
        anim = Panel.GetComponent<Animator>();
        highScore = PlayerPrefs.GetInt("highScore");
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        ScreenConstraints();
    }

    //On space bar add force
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
        rb.AddForce(transform.up * flapForce);
        }
    }
    void Score()
    {
        scoreText.text = score.ToString();
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            highScore = score;
        }

    }
    void ScreenConstraints()
    {
        if(gameObject.transform.position.y >= yBounds1 ||  gameObject.transform.position.y <= yBounds2)
        {
            GameOver();
        }
    }
     void GameOver()
    {
        Score();
        highScoreText.text = highScore.ToString();
        scoreTextFinal.text = score.ToString();
        anim.SetBool("isPaused", true);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Goal")
        {
            score += 1;
            Score();
        }
        if(other.tag == "Pipes")
        {
            //GameOver
            GameOver();
        }
    }
   
}
