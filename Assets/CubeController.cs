using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    private AudioSource BlockCollider;


    // Use this for initialization
    void Start()
    {
        BlockCollider = GetComponent<AudioSource>();//AudioSourceのコンポーネントを操作可能にする
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)//衝突判定
    {
        if (other.gameObject.tag == "ground" || other.gameObject.tag == "CubePrefab")//地面もしくはCubeに衝突した場合に
        {
            BlockCollider.PlayOneShot(BlockCollider.clip);//音を鳴らす
        }
    }
}