using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    [SerializeField] public NumberField NumberOflifes;

    private void Start(){
        if(this.tag == "Player")
            NumberOflifes.SetNumber(1);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(triggeringTag != "Laser"){
            if(other.tag == triggeringTag && NumberOflifes.GetNumber() > 1  && enabled){
                Destroy(other.gameObject);
                NumberOflifes.AddNumber(-1);
            }
            else if(other.tag == triggeringTag && NumberOflifes.GetNumber() <= 1 && enabled){
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
        else if (other.tag == triggeringTag  && enabled) {
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            
        }
    }

    private void Update() {
        /* Just to show the enabled checkbox in Editor */
    }
}