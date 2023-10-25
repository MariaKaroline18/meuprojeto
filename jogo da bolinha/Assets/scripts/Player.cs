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
        Debug.Log("START");
        TryGetComponent(out rb);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!noChao && collision.gameObject.tag == "Chão") 
        {
            noChao = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("UPDAT");
        //pulo
        float h = Input.GetAxis("Horizontal");//-1 equerda ,0 nada ,1 direita
        float v = Input.GetAxis("Vertical");//-1 pra trás ,0 nada ,1 pra frente
        Vector3 direcao = new Vector3(h, 0, v);
        rb.AddForce(direcao * velocidade * Time.deltaTime,ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up*forcaPulo,ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rb.AddForce(Vector3.up * forcaPulo,ForceMode.Impulse);
            noChao = false;
        }

        
        if(transform.position.y <= -10)
        {
            //jogador caiu
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        
        

        
           
        }

    }
}
