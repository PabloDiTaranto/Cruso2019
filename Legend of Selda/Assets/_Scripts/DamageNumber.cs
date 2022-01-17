using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
using UnityEngine.UI;
public class DamageNumber : MonoBehaviour
{
    public float damageSpeed;
    public float damagePoints;
    public float rescaleMultiplier = 6;
    public float timeToChangeDirection = 1;
    private float _timeToChangeDirectionCounter = 1;

    //public TMP_Text damageTextTMP;
    public Text damageText;

    public Vector2 direction = new Vector2(1, 0);


    private void Start()
    {
        _timeToChangeDirectionCounter = timeToChangeDirection;
        damageText.text = "" + damagePoints;
    }

    // Update is called once per frame
    void Update()
    {
        _timeToChangeDirectionCounter -= Time.deltaTime;
        if (_timeToChangeDirectionCounter <= timeToChangeDirection/2)
        {
            direction *= -1;
            _timeToChangeDirectionCounter += timeToChangeDirection;
            if (damageSpeed > 0.1f)
            {
                damageSpeed -= Time.deltaTime * 1.5f;
            }
        }
        
        transform.position = new Vector3(transform.position.x + direction.x * damageSpeed * Time.deltaTime,
            transform.position.y + damageSpeed * Time.deltaTime
            , transform.position.z);

        transform.localScale *= (1 - Time.deltaTime / rescaleMultiplier);
    }

}
