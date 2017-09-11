// Using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// AnimeGirlMovement object
//--------------------------------------------------------------------------------------
public class AnimeGirlMovement : MonoBehaviour
{
	// Player speed.
    public float m_fSpeed = 10.0f;

	// Player animation.
    private Animator m_aAnimate;

	//--------------------------------------------------------------------------------------
	// initialization
	//--------------------------------------------------------------------------------------
	void Start()
    {
		m_aAnimate = GetComponent<Animator>();
    }

	//--------------------------------------------------------------------------------------
	// Update: Function that calls each frame to update game objects.
	//--------------------------------------------------------------------------------------
	void Update()
    {
		// Get the values of the Horizontal and vertical virtual axis.
        float fHor = Input.GetAxis("Horizontal") * Time.deltaTime * m_fSpeed;
        float fVer = Input.GetAxis("Vertical") * Time.deltaTime * m_fSpeed;

		//--------------------------
		// Player walking animations.
		//--------------------------
		if (fHor < 0)
		{
			// If the player goes left.
			// Animate left.
			m_aAnimate.SetBool("IsLeft", true);
		}
		else if(fHor > 0)
		{
			// If the player goes right.
			// Animate right.
			m_aAnimate.SetBool("IsRight", true);
		}
		else
		{
			// Set both animation to false if not going wither direction.
			m_aAnimate.SetBool("IsLeft", false);
			m_aAnimate.SetBool("IsRight", false);
		}
		//--------------------------
		// Player walking animations.
		//--------------------------

		//--------------------------
		// Player jumping animations.
		//--------------------------
		if (fVer != 0 && fHor < 0)
		{
			// if vertical axis is 0 and Horizontal is less then 0.
			// Animate jumping.
			m_aAnimate.SetTrigger("IsJumping");
		}
		else if (fVer != 0 && fHor > 0)
		{
			// if vertical axis is 0 and Horizontal is greater then 0.
			// Animate jumping right.
			m_aAnimate.SetTrigger("IsJumpingRight");
		}
		//--------------------------
		// Player jumping animations.
		//--------------------------

		// Update the player transform.
		transform.Translate(fHor, 0, 0);
		transform.Translate(0, fVer, 0);
	}
}
