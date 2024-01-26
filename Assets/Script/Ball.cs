using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;//基本スピード
    [SerializeField] float basespeed = 1.0f;//初期スピードベース
    [SerializeField] float accelSpeed = 2.0f; //加速度
    [SerializeField] ScoreManager scoreManager;

    [SerializeField] GameObject exeplosionPrefab;

    Rigidbody rb;
    bool isStart = false;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isStart == false && Input.GetMouseButtonDown(0))
        {

            isStart = true;
            rb.AddForce(new Vector3(basespeed, -basespeed, 0) * speed, ForceMode.VelocityChange);
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Block")
        {
            scoreManager.AddScore();
            GameController.Instance.BlockBreak();
            GameObject exeplosion = Instantiate(exeplosionPrefab, transform.position, Quaternion.identity);
            exeplosion.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Bar")
        {

            scoreManager.ResetCombo();
            speed += accelSpeed;
            Vector3 vec = transform.position - other.transform.position;
            rb.velocity = Vector3.zero;
            rb.AddForce(vec.normalized * speed, ForceMode.VelocityChange);
        }
    }


}
