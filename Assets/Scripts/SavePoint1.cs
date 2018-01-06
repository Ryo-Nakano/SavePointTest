using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint1 : MonoBehaviour {

	[SerializeField] Sprite test;//Unity上からSpriteをアタッチ
	[SerializeField] GameObject player;//Unity上からPlayerをアタッチ

	SpriteRenderer sr;//SpriteRendererを格納しておくための変数

	// Use this for initialization
	void Start () {
	sr = GetComponent<SpriteRenderer> ();//SpriteRendererコンポーネントを取ってきて変数srの中に格納
	}
	
	// Update is called once per frame
	void Update () {
		DeletMessage (4.0f);//playerのx座標が4より大きい時
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			this.transform.position += new Vector3 (0, 4.0f, 0);
			sr.sprite = test;
		}
	}

	void DeletMessage(float f)
	{
		if(player.transform.position.x > f)
		{
			Destroy (this.gameObject);
		}
	}
}
