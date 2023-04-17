using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class LifeAdder : MonoBehaviour{

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && enabled) {
            other.GetComponent<DestroyOnTrigger2D>().NumberOflifes.AddNumber(1);
            // Debug.Log(NumberOflifes);
            Destroy(gameObject);  // Destroy the shield itself - prevent double-use
        }
    }
}