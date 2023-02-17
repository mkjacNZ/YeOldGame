using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public Material red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "water")
        {
            Destroy(GameObject.Find("Canvas"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cube")
        {
            if (collision.gameObject.GetComponent<MeshRenderer>().material.color == red.color)
            {
                Destroy(GameObject.Find("Canvas"));
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "cube")
        {
            if (collision.gameObject.GetComponent<MeshRenderer>().material.color == red.color)
            {
                Destroy(GameObject.Find("Canvas"));
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
