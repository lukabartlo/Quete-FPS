using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AttackController : MonoBehaviour
{
    public Shooting shooting;
    public Character characters;

    private void Update()
    {
        if (Time.timeScale == 0)
            return;

        /*if (characters.CurrentCD > 0f)
            return;*/

        if (Input.GetMouseButtonDown(0))
        {
            shooting.Attack();
        }
    }
}

