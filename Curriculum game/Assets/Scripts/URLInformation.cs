using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLInformation : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
        {

            switch (gameObject.tag)
            {
                case "GitHub":
                    Application.OpenURL("https://github.com/victorsanchezgimenez?tab=repositories");
                    break;

                case "LinkedIn":
                    Application.OpenURL("https://www.linkedin.com/in/v%C3%ADctor-s%C3%A1nchez-gim%C3%A9nez-023baa135/");
                    break;

                case "Youtube":
                    Application.OpenURL("https://www.youtube.com/channel/UCrhM_2ymogfUa7EcyT2_yvA");
                    break;

                case "Gmail":
                    Application.OpenURL("https://mail.google.com/mail/?view=cm&fs=1&to=victorsanchezgimenez98@gmail.com&su=SUBJECT&body=BODY");
                    break;
            }

        }

    }
}
