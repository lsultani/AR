using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARInstruction : MonoBehaviour
{
    public Text m_btnText; //reference to button text
    public GameObject m_mainMenu; //reference to main menu canvas
    public List<GameObject> m_steps = new List<GameObject>(); //List of all the steps in our instructions

    private int m_currentStep; //track current step

    public void NextStep()
    {
        if (m_currentStep < m_steps.Count - 1)
        {
            m_steps[m_currentStep].SetActive(false); //turn current step off
            m_currentStep++; //increment current step
            m_steps[m_currentStep].SetActive(true); //use new incremented step and turn it on

            if (m_currentStep == m_steps.Count - 1) //if on last step
            {
                m_btnText.text = "Return"; //change button text to return
            }
        }
        else
        {
            m_steps[m_currentStep].SetActive(false); //turn off last step
            m_currentStep = 0; //rest current step variable
            m_steps[m_currentStep].SetActive(true); //turn on first step

            m_btnText.text = "Next"; //change button to next
            m_mainMenu.SetActive(true); //turn back on main menu
            gameObject.SetActive(false); //turn off this object (what is holding the script)
        }
    }
}