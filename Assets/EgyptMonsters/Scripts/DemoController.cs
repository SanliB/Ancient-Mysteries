using UnityEngine;
using System.Collections;

public class DemoController : MonoBehaviour
{
    [System.Serializable]
    public class CustomTrigger
    {
        public KeyCode triggerKey;
        public string triggerName;
        public float animDuration = 1;
    }

	private Animator animator;

	public float walkspeed = 5;
	private float horizontal;
	private float vertical;
	private float rotationDegreePerSecond = 1000;
	private bool isInAnimation = false;

	public GameObject gamecam;
	public Vector2 camPosition;
	private bool dead;


	public GameObject[] characters;
	public int currentChar = 0;

    public GameObject[] targets;
    public float attackDuration = 1f;
    public float minAttackDistance;

    public CustomTrigger[] customAnimTriggerList;

    public UnityEngine.UI.Text nameText;


	void Start()
	{
		setCharacter(0);
	}

	void FixedUpdate()
	{
		if (animator && !dead)
		{
			//walk
			horizontal = Input.GetAxis("Horizontal");
			vertical = Input.GetAxis("Vertical");

			Vector3 stickDirection = new Vector3(horizontal, 0, vertical);
			float speedOut;

			if (stickDirection.sqrMagnitude > 1) stickDirection.Normalize();

			if (!isInAnimation)
				speedOut = stickDirection.sqrMagnitude;
			else
				speedOut = 0;

			if (stickDirection != Vector3.zero && !isInAnimation)
				transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(stickDirection, Vector3.up), rotationDegreePerSecond * Time.deltaTime);
			GetComponent<Rigidbody>().velocity = transform.forward * speedOut * walkspeed + new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0);

			animator.SetFloat("Speed", speedOut);
		}
	}


	void Update()
	{
		if (!dead)
		{
			// move camera
			if (gamecam)
				gamecam.transform.position = transform.position + new Vector3(0, camPosition.x, -camPosition.y);

			// attack
			if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump") && !isInAnimation)
			{
				isInAnimation = true;
				animator.SetTrigger("Attack");
				StartCoroutine(stopAnimation(attackDuration));
                tryDamageTarget();


            }

            animator.SetBool("isAttacking", isInAnimation);

			//switch character

			if (Input.GetKeyDown("left"))
			{
				setCharacter(-1);
				isInAnimation = true;
				StartCoroutine(stopAnimation(1f));
			}

			if (Input.GetKeyDown("right"))
			{
				setCharacter(1);
				isInAnimation = true;
				StartCoroutine(stopAnimation(1f));
			}

			// death
			if (Input.GetKeyDown("m"))
				StartCoroutine(selfdestruct());

            foreach (var item in customAnimTriggerList)
            {
                if (Input.GetKeyDown(item.triggerKey) && !isInAnimation)
                {
                    animator.SetTrigger(item.triggerName);
                    isInAnimation = true;
                    StartCoroutine(stopAnimation(item.animDuration));
                }
            }
		}

	}
    GameObject target = null;
    public void tryDamageTarget()
    {
        target = null;
        float targetDistance = minAttackDistance + 1;
        foreach (var item in targets)
        {
            float itemDistance = (item.transform.position - transform.position).magnitude;
            if (itemDistance < minAttackDistance)
            {
                if (target == null) {
                    target = item;
                    targetDistance = itemDistance;
                }
                else if (itemDistance < targetDistance)
                {
                    target = item;
                    targetDistance = itemDistance;
                }
            }
        }
        if(target != null)
        {
            transform.LookAt(target.transform);
            
        }
    }
    public void DealDamage(DealDamageComponent comp)
    {
        if (target != null)
        {
            target.GetComponent<Animator>().SetTrigger("Hit");
            var hitFX = Instantiate<GameObject>(comp.hitFX);
            hitFX.transform.position = target.transform.position + new Vector3(0, target.GetComponentInChildren<SkinnedMeshRenderer>().bounds.center.y,0);
        }
    }

    public IEnumerator stopAnimation(float length)
	{
		yield return new WaitForSeconds(length); 
		isInAnimation = false;
	}

    public IEnumerator selfdestruct()
    {
        animator.SetTrigger("isDead");
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        dead = true;

        yield return new WaitForSeconds(3f);
        while (true)
        {
            if (Input.anyKeyDown)
            {
                Application.LoadLevel(Application.loadedLevelName);
                yield break;
            }
            else
                yield return 0;

        }
    }
    public void setCharacter(int i)
	{
		currentChar += i;

		if (currentChar > characters.Length - 1)
			currentChar = 0;
		if (currentChar < 0)
			currentChar = characters.Length - 1;

		foreach (GameObject child in characters)
		{
            if (child == characters[currentChar])
            {
                child.SetActive(true);
                if (nameText != null)
                    nameText.text = child.name;
            }
            else
            {
                child.SetActive(false);
            }
		}
		animator = GetComponentInChildren<Animator>();
        

    }
}
