using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Canvas使う時に必要！

public class PlayerController : MonoBehaviour {

	[SerializeField] Text RespawnPositionText;

	[SerializeField] float speed;
	[SerializeField] float jumpPower;
	Rigidbody rigidbody;

	int playerRespawnPoint = 0;//Playerの復活地点を決める変数
	Vector3 startPosition = new Vector3(-10f, 1f, 0);
	Vector3 savePoint1;
	Vector3 savePoint2;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();	//Rigidbodyコンポーネントを取得して変数rigidbodyに格納

		savePoint1 = GameObject.FindWithTag ("SavePoint1").transform.position;//変数savePoint1にSavePoinrt1の位置情報を格納
		savePoint2 = GameObject.FindWithTag ("SavePoint2").transform.position;//変数savePoint2にSavePoinrt2の位置情報を格納
	}
	
	// Update is called once per frame
	void Update () 
	{
		Move ();//Playerの移動
		Jump ();//PlayerのJump
		Respawn (playerRespawnPoint);//playerRespawnPositionの値に応じた場所にリスポン


		RespawnPositionText.text = "playerRespawnPoint : " + playerRespawnPoint.ToString();//分かりやすさの為にtext表示
			
	}



	//当たり判定
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "SavePoint1")//当たった相手のtagが"SavePoint1"の時
		{
			playerRespawnPoint = 1;
			Debug.Log ("Reached SavePoint1");
		}

		if(col.gameObject.tag == "SavePoint2")//当たった相手のtagが"SavePoint2"の時
		{
			playerRespawnPoint = 2;
			Debug.Log ("Reached SavePoint1");
		}
	}



	//====================以下、自作の関数====================

	//Playerに移動をさせる関数
	void Move()
	{
		if(Input.GetKey("right"))
		{
			this.transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
		}

		if(Input.GetKey("left"))
		{
			this.transform.position += new Vector3 (-speed * Time.deltaTime, 0, 0);
		}
	}


	//PlayerにJumpをさせる関数
	void Jump()
	{
		if(Input.GetKeyDown("space"))
		{
			rigidbody.velocity = new Vector3 (0, jumpPower, 0);
		}
	}


	//playerRespawnPositionの値に応じた場所にリスポン
	void Respawn(int i)//引数"i"の値に応じて振る舞いが変化！
	{
		if(this.transform.position.y < -10.0f)
		{
			if(i == 0)
			{
				this.transform.position = startPosition;
			}

			if(i == 1)
			{
				this.transform.position = savePoint1;
			}

			if(i == 2)
			{
				this.transform.position = savePoint2;
			}
		}
	}
}
