using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCon : MonoBehaviour
{
    public float Speed;
    Rigidbody rb;
    int Puan=100;
    int PuanToplam;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Hata.intansce.Ulaþ();
    }

    void Update()
    {
        Hareket();
    }
    public void Hareket()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(x,0,z);

        rb.AddForce(move * Speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            PuanToplam+= Puan;
            Debug.Log("Skor" + PuanToplam);
        }
    }
 
}
