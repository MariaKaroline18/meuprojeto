using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public int velocidade = 10;
    public int forcaPulo = 7;

    public Rigidbody rb;

    public bool noChao = false;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);

    }

    private void OnCollisionEnter(Collision collision)
    {
        noChao = true;
    }

    // Update is called once per frame
    void Update()
    {
        //pulo
        if (noChao && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(h, 0, v) * velocidade * Time.deltaTime, ForceMode.Impulse);
        if (transform.position.y <= -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
