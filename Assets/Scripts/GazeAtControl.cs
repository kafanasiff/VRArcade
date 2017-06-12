using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GazeAtControl : MonoBehaviour {

    private int countdownTracker; // for hover over (look at) to select button functionality
    private int countdownLength = 3; // how many seconds to count down
    public Text countdownText;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnable()
    {
        countdownTracker = countdownLength;
    }

    void OnDisable()
    {
        countdownTracker = countdownLength;
    }

    public void OnEnter()
    {
        //Debug.Log("on enter");
        countdownText.text = countdownTracker.ToString();
        InvokeRepeating("HoverCountdown", 1f, 1f);
    }

    public void OnExit()
    {
        //Debug.Log("on exit");
        CancelInvoke("HoverCountdown");
        countdownTracker = countdownLength;
        countdownText.text = "";
    }
       
    private void HoverCountdown()
    {
        countdownTracker--;
        countdownText.text = countdownTracker.ToString();
        if (countdownTracker <= 0)
        {
            CancelInvoke("HoverCountdown");
            countdownText.text = "";
            countdownTracker = countdownLength;
            if (gameObject.tag == "Button")
            {
                Button gameButton = GetComponent(typeof(Button)) as Button;
                gameButton.onClick.Invoke();
            }
            if (gameObject.tag == "Toggle")
            {
                Toggle gameToggle = GetComponent(typeof(Toggle)) as Toggle;
                gameToggle.isOn = !gameToggle.isOn;
            }
            /* Not working
            if (gameObject.tag == "Slider")
            {
                Slider gameSlider = GetComponent(typeof(Slider)) as Slider;
                ExecuteEvents.Execute<IPointerClickHandler>(gameSlider.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
            }
            */
            //Debug.Log("Play game");
        }
    }
}
