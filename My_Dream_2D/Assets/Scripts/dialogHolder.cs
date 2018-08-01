using UnityEngine;

public class dialogHolder : MonoBehaviour {

    public string dialogue;
    private DialogueManager dMan;

	// Use this for initialization
	void Start ()
    {
        dMan = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                dMan.ShowBox(dialogue);
            }
        }
    }
}
