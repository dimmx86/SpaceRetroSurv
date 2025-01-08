using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Transform target;
    private Material material;
    Vector2 offset = Vector2.zero;

    [SerializeField] private float scale = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = transform.root;
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2(target.position.x / 100 * scale, target.position.y / 100 * scale);
        material.mainTextureOffset = offset;
    }
}
