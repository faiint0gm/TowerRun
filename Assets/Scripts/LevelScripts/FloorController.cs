using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {
    bool destructionSet;

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !destructionSet)
            StartCoroutine(SetDestruction(3));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && destructionSet)
            StopAllCoroutines();
    }

    IEnumerator SetDestruction(int seconds)
    {
        destructionSet = true;
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
