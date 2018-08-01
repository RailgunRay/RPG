using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour {

    public DialogueNode[] node;
    public int _currentNode;
    public bool ShowDialogue = true;
         
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        if (ShowDialogue == true) { 
        GUI.Box(new Rect(Screen.width / 2 - 300, Screen.height -300, 600, 250), "");
        GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height -280, 500, 90), node[_currentNode].NPCText);
            for (int i = 0; i < node[_currentNode].PlayerAnswer.Length; i++)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height  -200 + 25 * i, 500, 25), node[_currentNode].PlayerAnswer[i].Text))
                {
                    if (node[_currentNode].PlayerAnswer[i].SpeakEnd)
                    {
                        ShowDialogue = false;
                    }
                    _currentNode = node[_currentNode].PlayerAnswer[i].ToNode;
                }
            }
        }
    }

    [System.Serializable]
    public class DialogueNode
    {
        public string NPCText;
        public Answer[] PlayerAnswer;
    }

    [System.Serializable]
    public class Answer
    {
        public string Text;
        public int ToNode;
        public bool SpeakEnd;
    }
}
