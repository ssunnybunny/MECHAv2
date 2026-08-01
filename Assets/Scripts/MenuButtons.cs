using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MECHA.GUI
{
	public class MenuButtons : MonoBehaviour
	{
        public void Update()
        {
			if (!Global.hasseenlore && !loredone) { starttxt.SetActive(true); loredone = true; }
        }

		[SerializeField] bool loredone;

		void Start()
		{
		if(Global.language == 2){ ptbt(); }
		if(Global.language == 1){ engbt(); }
		if (Global.night) { darknight.SetActive(true); }
		if (Global.hard) { inferno.SetActive(true); }
		DinoSlider.value = Global.dinovol; 
			//Global.dinovol = DinoSlider.value;
		DinoSPEED.value = Global.dinospeed; 
			//Global.dinospeed = DinoSPEED.value;
		DinoDASH.value = Global.dinodash; 
			//Global.dinodash = DinoDASH.value;
		DinoCD.value = Global.dinocd; 
		MUSSlider.value = Global.musvol; 
			//Global.dinocd = DinoCD.value;
		if(Global.hasseenlore){ starttxt.SetActive(false);}
		
		if(Global.trophynorm){trophynorm.SetActive(true);}
		if(Global.trophynight){trophynight.SetActive(true);}
		if(Global.trophyinf){trophyinf.SetActive(true);}
		if(Global.trophytinf){trophytinf.SetActive(true);}
        }
        [SerializeField] GameObject trophynorm;
        [SerializeField] GameObject trophynight;
        [SerializeField] GameObject trophyinf;
        [SerializeField] GameObject trophytinf;

        [SerializeField] GameObject starttxt;
		public void StartText() 
		{
			starttxt.SetActive(false);
			Global.seenstart = true;
			DinoSlider.value = 1;
            MUSSlider.value = 0;
            DinoSPEED.value = 5;
            DinoDASH.value = 5;
            DinoCD.value = 4;
        }

		[SerializeField] GameObject fakestart;
		[SerializeField] GameObject fakestart2;

		public void FakeStart() 
		{
			if (!Global.hasseenlore)
			{
				fakestart.SetActive(false);
				fakestart2.SetActive(true);
			} else{SceneManager.LoadScene("Map");}
			}

		public void StartButton()
        {
            Global.dinospeed = DinoSPEED.value;
            Global.dinodash = DinoDASH.value;
            Global.dinocd = DinoCD.value;
            Global.hasseenlore = true;
            SceneManager.LoadScene("Map");
		}

		public void MenuScene() 
		{
			SceneManager.LoadScene("Menu");
		}


		public void LoadButton(){ }
		[SerializeField] public AudioClip asa;
		public AudioSource ask;
		public void soma()
		{
			ask.clip = asa;
			ask.PlayOneShot(asa);
		}
		public bool aaaaa;
		public void SettingsButton()
		{
			a.SetActive(!a.activeSelf);

		}

		public void LeaveButton()
		{
			Application.Quit();
		}

		[SerializeField] GameObject a;
		[SerializeField] GameObject e1;
		[SerializeField] GameObject e12;
		[SerializeField] GameObject e2;
		[SerializeField] GameObject e3;
		[SerializeField] GameObject e4;
        [SerializeField] GameObject e5;
        [SerializeField] GameObject et;

		public void engbt()
		{
			e1.SetActive(true);
			e2.SetActive(true);
			e3.SetActive(true);
			e4.SetActive(true);
			e5.SetActive(true);
			e12.SetActive(true);
			et.SetActive(true);
			p1.SetActive(false);
			p2.SetActive(false);
			p3.SetActive(false);
			p4.SetActive(false);
			p5.SetActive(false);
			p12.SetActive(false);
			pt.SetActive(false);
            Global.language = 1;
        }

		[SerializeField] GameObject p1;
		[SerializeField] GameObject p12;
		[SerializeField] GameObject p2;
		[SerializeField] GameObject p3;
		[SerializeField] GameObject p4;
        [SerializeField] GameObject p5;
        [SerializeField] GameObject pt;

		public void ptbt()
		{
			e1.SetActive(false);
			e2.SetActive(false);
			e3.SetActive(false);
			e4.SetActive(false);
			e5.SetActive(false);
            e12.SetActive(false);
			et.SetActive(false);
			p1.SetActive(true);
			p2.SetActive(true);
			p3.SetActive(true);
			p4.SetActive(true);
			p5.SetActive(true);
            p12.SetActive(true);
			pt.SetActive(true);
			Global.language = 2;
		}

        [SerializeField] GameObject hardbutton;
        [SerializeField] GameObject inferno;
        [SerializeField] GameObject hardctive;
        [SerializeField] GameObject harddective;

        public void hardactive()
        {
            { Global.hard = true; inferno.SetActive(true); hardctive.SetActive(false); harddective.SetActive(true); }
			if(DinoSPEED.value == 3 && DinoDASH.value == 3 && DinoCD.value == 1 && Global.night && Global.hard)
			{
			Global.TRUEINFERNO = true;
			TRUEINFERNO.SetActive(true);
			TITLECARD.SetActive(false);
			}
        }
        public void harddeactive()
        {
            { Global.hard = false; inferno.SetActive(false); harddective.SetActive(false); hardctive.SetActive(true); }
			if(DinoSPEED.value == 3 && DinoDASH.value == 3 && DinoCD.value == 1 && Global.night && Global.hard)
			{
			Global.TRUEINFERNO = true;
			TRUEINFERNO.SetActive(true);
			TITLECARD.SetActive(false);
			} else {Global.TRUEINFERNO = false; TRUEINFERNO.SetActive(false); TITLECARD.SetActive(true); }
        }


		[SerializeField] Slider DinoSlider;
        [SerializeField] Slider MUSSlider;
        [SerializeField] Slider DinoSPEED;
		[SerializeField] Slider DinoDASH;
		[SerializeField] Slider DinoCD;
		public void AlterarSom()
		{
			Global.dinovol = DinoSlider.value;
			ask.volume = DinoSlider.value;
        }
        public void AlterarSomdois()
        {
            Global.musvol = MUSSlider.value;
        }

        [SerializeField] GameObject TRUEINFERNO;
        [SerializeField] GameObject TITLECARD;
        public void dinospeed()
		{
			Global.dinospeed = DinoSPEED.value;
			if(DinoSPEED.value == 3 && DinoDASH.value == 3 && DinoCD.value == 1 && Global.night && Global.hard)
			{
			Global.TRUEINFERNO = true;
			TRUEINFERNO.SetActive(true);
			TITLECARD.SetActive(false);
			} else {Global.TRUEINFERNO = false; TRUEINFERNO.SetActive(false); TITLECARD.SetActive(true); }
        }
		public void dinodash()
		{
			Global.dinodash = DinoDASH.value;
			if(DinoSPEED.value == 3 && DinoDASH.value == 3 && DinoCD.value == 1 && Global.night && Global.hard)
			{
			Global.TRUEINFERNO = true;
			TRUEINFERNO.SetActive(true);
			TITLECARD.SetActive(false);
			} else {Global.TRUEINFERNO = false; TRUEINFERNO.SetActive(false); TITLECARD.SetActive(true); }
		}
		public void dinocd()
		{
			Global.dinocd = DinoCD.value;
			if(DinoSPEED.value == 3 && DinoDASH.value == 3 && DinoCD.value == 1 && Global.night && Global.hard)
			{
			Global.TRUEINFERNO = true;
			TRUEINFERNO.SetActive(true);
			TITLECARD.SetActive(false);
			} else {Global.TRUEINFERNO = false; TRUEINFERNO.SetActive(false); TITLECARD.SetActive(true); }
		}

		[SerializeField] GameObject darknight;
		public void night()
		{
			Global.night = !Global.night;
			darknight.SetActive(!darknight.activeSelf);
			if(DinoSPEED.value == 3 && DinoDASH.value == 3 && DinoCD.value == 1 && Global.night && Global.hard)
			{
			Global.TRUEINFERNO = true;
			TRUEINFERNO.SetActive(true);
			TITLECARD.SetActive(false);
			} else {Global.TRUEINFERNO = false; TRUEINFERNO.SetActive(false); TITLECARD.SetActive(true);}
		}

	}
}