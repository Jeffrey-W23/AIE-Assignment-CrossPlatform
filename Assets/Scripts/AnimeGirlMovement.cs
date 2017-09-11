using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeGirlMovement : MonoBehaviour
{
	public float m_fSpeed = 10.0f;
	private Animator anim;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update ()
	{
		float H = Input.GetAxis("Horizontal") * Time.deltaTime * m_fSpeed;
		float V = Input.GetAxis("Vertical") * Time.deltaTime * m_fSpeed;

		if (H < 0)
		{
			anim.SetBool("IsLeft", true);
		}
		else if(H > 0)
		{
			anim.SetBool("IsRight", true);
		}
		else
		{
			anim.SetBool("IsLeft", false);
			anim.SetBool("IsRight", false);
		}


		if (V != 0 && H < 0)
		{
				anim.SetTrigger("IsJumping");
		}
		else if (V != 0 && H > 0)
		{
				anim.SetTrigger("IsJumpingRight");
		}

		transform.Translate(H, 0, 0);

		transform.Translate(0, V, 0);
	}
}
