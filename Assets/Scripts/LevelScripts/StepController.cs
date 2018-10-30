using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour {
   public bool destructionSet;
   public bool touched;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touched = true;
            if (transform.position.y > collision.transform.position.y)
                GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            touched = true;
            if(transform.position.y< collider.transform.position.y)
            GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
                GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        touched = true;
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!destructionSet && !GetComponent<BoxCollider>().isTrigger && touched)
            {
                StartCoroutine(SetDestruction(1));
            }
        }
    }

    IEnumerator SetDestruction(int seconds)
    {
        destructionSet = true;
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

}
