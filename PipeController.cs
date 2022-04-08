using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] int xBounds = -22;
    [SerializeField] float yBounds1 = 3;
    [SerializeField] float yBounds2 = -3;
    [SerializeField] float xPos = 8;
    [SerializeField] float Timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        float randomY = Random.Range(yBounds1, yBounds2);
        var position = new Vector3(gameObject.transform.position.x,randomY,0);
        gameObject.transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        SpeedUp();
        //move left
        transform.Translate(speed * Time.deltaTime,0,0);

        if (transform.position.x <= -22)
        {
            TransformReset();
        }
    }

    //reset if xtransform == xbounds
    void TransformReset()
    {
        //get random y position between set bounds
        float randomY = Random.Range(yBounds1, yBounds2);

        var position = new Vector3(xPos,randomY,0); //resets to new position 
        gameObject.transform.position = position;
    }
    void SpeedUp()
    {
        Timer += Time.deltaTime;
        if(Timer >= 5)
        {
            Timer = 0;
            speed -= .5f;
        }

    }
    
}
