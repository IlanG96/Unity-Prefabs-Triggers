using System.Collections;
using UnityEngine;

public class LaserShooter : ClickSpawner {
    [SerializeField] NumberField scoreField;
    [SerializeField] float shootInterval = 5f; // Interval between shots in seconds.

    private bool canShoot = true;

    protected override GameObject spawnObject() {
        if (canShoot) {
            GameObject newObject = base.spawnObject();

            // Modify the text field of the new object.
            ScoreAdder newObjectScoreAdder = newObject.GetComponent<ScoreAdder>();
            if (newObjectScoreAdder) {
                newObjectScoreAdder.SetScoreField(scoreField);
            }

            StartCoroutine(ShootCooldown());
            return newObject;
        }

        return null;
    }

    private IEnumerator ShootCooldown() {
        canShoot = false;
        yield return new WaitForSeconds(shootInterval);
        canShoot = true;
    }
}
