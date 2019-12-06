using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    #region
    [Header(" ")][Range(0f,100f)]
    public float speed = 3.5f;
    [Header(" "),Range(100,2000)]
    public int junp = 300;
    public bool isGround = false;
    public string _name = "uYC";
    [Header("剛體")]
    public Rigidbody2D r2d;
    public Animator ani;
    [Header("音效區域")]
    public AudioSource aud;
    public AudioClip soundDiamond;
    [Header("鑽石區域")]
    public int diamondCurrent;
    public int diamondTotal;
    public Text textDiamond;
    #endregion
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        r2d.AddForce(new Vector2(speed*h,0));
        ani.SetBool("paobu", h != 0);
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) transform.eulerAngles = new Vector3(0, 180, 0);
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) transform.eulerAngles = new Vector3(0, 0, 0);
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0,junp));
            ani.SetTrigger("junp");
        }
    }
    private void Dead()
    {
        
    }
    //事件
    private void Start()
    {
        diamondTotal = GameObject.FindGameObjectsWithTag("gem-1").Length;
        textDiamond.text = "鑽石:0 /" + diamondTotal;
    }
    private void Update()
    {
        Move();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "地板")
        {
            isGround = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "鑽石鑽石")
        {
            aud.PlayOneShot(soundDiamond, 1.5f);
            Destroy(collision.gameObject);
            diamondCurrent++;
            textDiamond.text = "鑽石:" + diamondCurrent + "/" + diamondTotal;
        }
    }
}
