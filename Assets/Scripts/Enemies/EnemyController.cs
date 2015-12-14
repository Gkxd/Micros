using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    public SpawnEnemy spawner;

    public new Rigidbody rigidbody;
    public bool poisonous;
    public bool hostile;

    public float maxSize;
    public float minSize;

    private float targetSize;
    private float size;

    public bool canInteract { get; private set; }

    private float angle;
    private float speed;

    private float lifeTime;

    public float initialSize { get; private set; }

    void Start() {
        initialSize = targetSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(size, size, 1);
        canInteract = true;
        angle = Random.Range(0, 360);
    }

    void FixedUpdate() {
        if (ShowHelp.helpActive) {
            rigidbody.Sleep();
            return;
        }

        if (hostile && PlayerController.playerInstance != null && (PlayerController.playerInstance.position - transform.position).sqrMagnitude < (8.8f + 1.2f*TrackColonySize.colonySize) * (8.8f + 1.2f*TrackColonySize.colonySize)) {
            Vector3 toPlayer = PlayerController.playerInstance.position - transform.position;
            angle = Mathf.Atan2(toPlayer.y, toPlayer.x) * Mathf.Rad2Deg;
            speed = 2.5f;
        }
        else {
            angle += Random.Range(-10, 10);
            speed += Random.Range(-1, 1);

            speed = Mathf.Clamp(speed, -2.5f, 2.5f);
        }

        Vector3 targetVelocity = speed * new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);

        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, targetVelocity, Time.deltaTime * 3);
    }

    void Update() {
        if (ShowHelp.helpActive) return;

        size = Mathf.Lerp(size, targetSize, Time.deltaTime * 10);
        transform.localScale = Vector3.one * size;

        if (size < 0.1f && lifeTime > 1) {
            Destroy(gameObject);
        }

        if (!canInteract || (TrackColonySize.colonySize == 0 && TrackColonySize.hasGameStarted)) {
            targetSize = 0;
        }

        if ((spawner.transform.position - transform.position).sqrMagnitude > spawner.spawnRange.y * spawner.spawnRange.y) {
            if (spawner.population != -1) {
                spawner.population++;
            }

            Destroy(gameObject);
        }

        lifeTime += Time.deltaTime;
    }

    public float getSize() {
        return targetSize;
    }

    public void decreaseSize(float f) {
        targetSize -= f;

        if (targetSize < 0.1f) {
            targetSize = 0.1f;
        }
    }

    public void consume() {
        targetSize = 0;
        canInteract = false;
    }
}
