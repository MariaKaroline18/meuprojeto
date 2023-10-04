using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int velocidade = 10;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(h, 0, v) * velocidade * Time.deltaTime, ForceMode.Impulse);
        if (transform.position.y <= -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
