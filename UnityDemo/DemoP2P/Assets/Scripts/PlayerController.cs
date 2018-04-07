using UnityEngine;

public class PlayerController : SingletonMonoBehaviour<PlayerController>
{
    public float moveSpeed = 1.0f;
    public PlayerData PlayerData { get; private set; } = new PlayerData();

    void Start()
	{
		//StartCoroutine(ProcLoop());
	}

    //private IEnumerator ProcLoop()
    //{
    //    while (true)
    //    {

    //        yield return new WaitForSeconds(1.0f);
    //    }
    //}

    void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * moveSpeed;

        var pos = transform.position;
        if (PlayerData.X != pos.x ||
            PlayerData.Z != pos.z)
        {
            PlayerData.X = pos.x;
            PlayerData.Z = pos.z;

            SendPeer.Instance.Data = Serializer.Serialize(PlayerData);
        }
    }
}
