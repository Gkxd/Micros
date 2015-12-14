using UnityEngine;
using System.Collections;

public class PlayerBodyBehavior : MonoBehaviour {

    public GameObject playerBodyPrefab;

    public Transform playerBodyContainer;
    public new Rigidbody rigidbody;
    public Rigidbody anchor;

    public float minSpeedWeight;
    public float maxSpeedWeight;

    private float speed;

    private float targetSize;
    private float size;
    private float lifeTime;

    private bool isDead = false;

    void Start() {
        speed = Random.Range(minSpeedWeight, maxSpeedWeight);
        targetSize = 1;
    }

    void FixedUpdate() {
        if (ShowHelp.helpActive) {
            rigidbody.Sleep();
            return;
        }

        Vector3 cohesion = Vector3.zero;

        Vector3 velocityMatching = anchor.velocity;

        Vector3 maintainSeparation = Vector3.zero;

        Vector3 averagePosition = Vector3.zero;

        foreach (Transform t in playerBodyContainer) {
            if (transform != t) {
                Vector3 fromOther = rigidbody.position - t.position;

                float otherSize = t.GetComponent<PlayerBodyBehavior>().targetSize;

                if (fromOther == Vector3.zero) {
                    maintainSeparation += Vector3.right * Random.Range(-1, 1) + Vector3.up * Random.Range(-1, 1);
                }
                else {
                    maintainSeparation += targetSize * fromOther.normalized / fromOther.sqrMagnitude;
                }

                if (maintainSeparation.sqrMagnitude > 100) {
                    maintainSeparation = maintainSeparation.normalized * 10;
                }
            }

            averagePosition = t.position;
        }

        averagePosition /= playerBodyContainer.childCount;

        cohesion = averagePosition - rigidbody.position;
        cohesion = anchor.position - rigidbody.position;

        Vector3 velocity = cohesion * 3.2f + speed * velocityMatching / (targetSize == 0 ? 1 : targetSize) + maintainSeparation * 6.8f;

        rigidbody.velocity = velocity;
    }

    void Update() {
        if (ShowHelp.helpActive) return;

        size = Mathf.Lerp(size, targetSize, Time.deltaTime * 10);
        transform.localScale = Vector3.one * size;

        if (size < 0.1f && lifeTime > 1) {
            Destroy(gameObject);
        }

        lifeTime += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        EnemyController otherController = other.GetComponent<EnemyController>();

        if (otherController.canInteract) {
            float otherSize = otherController.getSize();
            if (targetSize < otherSize) { // Player is smaller (player dies)
                otherController.decreaseSize(targetSize);
                targetSize = 0;

                if (!isDead) {
                    SfxManager.PlaySfxHurt();
                    isDead = true;
                    TrackColonySize.remove();
                }
            }
            else {
                if (!otherController.poisonous) {
                    if (size < 5) {
                        targetSize += otherSize / 10;
                    }

                    if (targetSize > 2 && transform.parent.childCount < 20) {
                        GameObject split = (GameObject)Instantiate(playerBodyPrefab, transform.position, Quaternion.identity);
                        split.transform.parent = transform.parent;

                        PlayerBodyBehavior splitBehavior = split.GetComponent<PlayerBodyBehavior>();
                        splitBehavior.playerBodyContainer = playerBodyContainer;
                        splitBehavior.playerBodyPrefab = playerBodyPrefab;
                        splitBehavior.anchor = anchor;

                        SfxManager.PlaySfxSplit();

                        targetSize -= 1;
                        TrackColonySize.add();
                        ScoreManager.score += (int)(100 * otherController.initialSize * TrackColonySize.colonySize);
                    }
                    else {
                        SfxManager.PlaySfxEat();
                        ScoreManager.score += (int)(10 * otherController.initialSize * TrackColonySize.colonySize);
                    }
                }
                else {
                    SfxManager.PlaySfxHurt();
                    targetSize -= otherSize;
                }

                otherController.consume();
            }
        }
    }
}
