using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalPlatformController : Elemental
{
	public float _delay;
    public float speed;
	public float radius;
	public bool horizontal;
	public bool reveseDirection;
	public bool pause;

	private Vector2 _startPos;
    private float actSpeed = 0;
    private int direction = 1;

    void Start ()
    {
		_startPos = transform.position;
		if(reveseDirection)
        {
			direction *= -1;
		}
	
		StartCoroutine("Delay");
	}

	void Update ()
    {
		if (!pause)
        {
			if (horizontal)
            {
                Vector3 deltaPos = new Vector3
                {
                    x = actSpeed * Time.deltaTime * direction
                };
                transform.position += deltaPos;
				if (direction == 1)
                {
					if (transform.position.x - _startPos.x >= radius)
                    {
						direction = -1;
					}
				}
                else
                {
					if (_startPos.x - transform.position.x >= radius)
                    {
						direction = 1;
					}
				}
			}
            else
            {
                Vector3 deltaPos = new Vector3
                {
                    y = actSpeed * Time.deltaTime * direction
                };
                transform.position += deltaPos;
				if (direction == 1)
                {
					if (transform.position.y - _startPos.y >= radius)
                    {
						direction = -1;
					}
				}
                else
                {
					if (_startPos.y - transform.position.y >= radius)
                    {
						direction = 1;
					}
				}
			}
		}
	}

	override public void Ignite ()
	{
		pause = false;
        SoundController.PlayWhoosh();
	}

	override public void Freeze ()
	{
		pause = true;
        SoundController.PlayFreeze();
	}

    public void SetActSpeed(float speed)
    {
        actSpeed = speed;
    }

    IEnumerator Delay()
    {
		yield return new WaitForSeconds (_delay);
		actSpeed = speed;
	}
}
