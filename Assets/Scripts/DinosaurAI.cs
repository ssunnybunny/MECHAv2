using MECHA;
using System.Collections;
using System.Text;
using UnityEngine;
using static UnityEngine.UI.ScrollRect;

namespace MECHA
{
	class DinosaurAI : MonoBehaviour
	{
		void Awake()
		{
			Global.alive = true;
			if (Global.hard) { difficulty = 3; } else { difficulty = 1; }
			x = 0;
			xdone = false;
			ydone = false;
			zdone = false;
			decider1 = 0;
			decider2 = 0;
			ak.volume = Global.dinovol;
			dinodash = Global.dinodash;
			dinospeed = Global.dinospeed;
			dinocd = Global.dinocd;
			direction = 1;
			if(Global.night){nightdark.SetActive(true);}
			if(Global.hard){inferno.SetActive(true);}
			StartCoroutine(Roar());
			if(Global.TRUEINFERNO){WARNINGDECIDER = true;}else{WARNINGDECIDER = false;}
		}

		[SerializeField] GameObject nightdark;
		[SerializeField] GameObject inferno;

		[SerializeField] float dinodash;
		[SerializeField] float dinospeed;
		[SerializeField] float dinocd;

		[SerializeField] int stage1lives;
		[SerializeField] int stage2lives;
		[SerializeField] int stage3lives;

		[SerializeField] int decider1;
		[SerializeField] int decider2;
		[SerializeField] GameObject fire1;
		[SerializeField] GameObject fire2;
		[SerializeField] GameObject fire3;
		[SerializeField] GameObject fire4;
		[SerializeField] GameObject awarning1;
		[SerializeField] GameObject awarning2;
		[SerializeField] GameObject awarning3;
		[SerializeField] GameObject awarning4;
        [SerializeField] GameObject cwarning1;
        [SerializeField] GameObject cwarning2;
        [SerializeField] GameObject cwarning3;
        [SerializeField] GameObject cwarning4;

        [SerializeField] GameObject dinoheart1;
		[SerializeField] GameObject dinoheart2;
		[SerializeField] GameObject dinoheart3;
		[SerializeField] GameObject gamewin;
		[SerializeField] int difficulty;
		[SerializeField] float x;
		[SerializeField] bool xdone;
		[SerializeField] bool ydone;
		[SerializeField] bool zdone;

		[SerializeField] GameObject spritedefault;
		[SerializeField] GameObject spriteroar;

		[SerializeField] AudioClip aa;
		[SerializeField] AudioSource ak;

        [SerializeField] bool WARNINGDECIDER;

        IEnumerator Attack()
		{
			for (int i = 0;  i <= 100; i++)
			{
				transform.position = transform.position + new Vector3(0, direction*-.5f, 0);
				yield return new WaitForSeconds(dinodash/200);
			}
			x += 1;
			if (x == stage1lives && !xdone) { xdone = true; if (!Global.hard) { difficulty++; }; RoarScream(); dinoheart1.SetActive(false); }
			if (x == stage2lives && !ydone) { WARNINGDECIDER = true; ydone = true; if (!Global.hard) { difficulty++; }; RoarScream(); dinoheart2.SetActive(false); }
			if (x == stage3lives && !zdone) { zdone = true; RoarScream(); dinoheart2.SetActive(false); gamewin.SetActive(true); Global.alive = false; 
			Global.trophynorm = true;
			if(Global.night){Global.trophynorm = true; Global.trophynight = true;}
			if(Global.inferno){Global.trophynorm = true; Global.trophyinf = true;}
			if(Global.TRUEINFERNO){Global.trophynorm = true; Global.trophynight = true; Global.trophyinf = true; Global.trophytinf = true; }
			}
			direction *= -1;
			yield return new WaitForSeconds(dinocd);
			if (Global.alive) {StartCoroutine(Idle());}
			yield return null;
		}

        [SerializeField] int direction;
        IEnumerator Idle()
		{
			if (difficulty == 1) { decider1 = Random.Range(1, 4); }
			if (difficulty == 2) { decider1 = Random.Range(1, 4); decider2 = Random.Range(1, 4); if (decider1 == decider2 && decider2 != 4) { decider2++; } else if (decider1 == decider2 && decider2 == 4) { decider2--; } }
			if (difficulty == 3) { decider1 = Random.Range(1, 4); }
			if (difficulty == 1) switch (decider1) 
			{
			case 1: StartCoroutine(FireA()); break;
			case 2: StartCoroutine(FireB()); break;
			case 3: StartCoroutine(FireC()); break;
			case 4: StartCoroutine(FireD()); break;
			}
			if (difficulty == 2)
			{
				switch (decider1)
				{
					case 1: StartCoroutine(FireA()); break;
					case 2: StartCoroutine(FireB()); break;
					case 3: StartCoroutine(FireC()); break;
					case 4: StartCoroutine(FireD()); break;
				}
				switch (decider2)
				{
					case 1: StartCoroutine(FireA()); break;
					case 2: StartCoroutine(FireB()); break;
					case 3: StartCoroutine(FireC()); break;
					case 4: StartCoroutine(FireD()); break;
				}
			}
			if (difficulty == 3) switch (decider1)
			{
			case 1: StartCoroutine(FireB()); StartCoroutine(FireC()); StartCoroutine(FireD()); break;
			case 2: StartCoroutine(FireA()); StartCoroutine(FireC()); StartCoroutine(FireD()); break;
			case 3: StartCoroutine(FireA()); StartCoroutine(FireB()); StartCoroutine(FireD()); break;
			case 4: StartCoroutine(FireA()); StartCoroutine(FireB()); StartCoroutine(FireC()); break;
			}


			for (int i = 0; i <= 100; i++)
			{
				transform.position = transform.position + new Vector3(0, direction*-.5f, 0);
				yield return new WaitForSeconds(dinospeed/100);
			}
			yield return new WaitForSeconds(dinocd);
			for (int i = 0; i <= 100; i++)
			{
				transform.position = transform.position + new Vector3(0, direction*.5f, 0);
				yield return new WaitForSeconds(dinospeed/100);
			}
			yield return new WaitForSeconds(dinocd);
			if (Global.alive) {StartCoroutine(Attack());}
			yield return null;
		}


		IEnumerator FireA()
		{
			if(!WARNINGDECIDER){
			for (int i = 0; i <= dinospeed + dinocd/2; i++)
			{
				awarning1.SetActive(true);
				yield return new WaitForSeconds(1);
				awarning1.SetActive(false);
				yield return new WaitForSeconds(1);
			}
			fire1.SetActive(true);
			yield return new WaitForSeconds((dinodash/200)*100 + dinocd);
			fire1.SetActive(false);
			yield return null;}
			if(WARNINGDECIDER){
			for (int i = 0; i <= dinospeed + dinocd/2; i++)
			{
				cwarning1.SetActive(true);
				yield return new WaitForSeconds(1);
				cwarning1.SetActive(false);
				yield return new WaitForSeconds(1);
			}
			fire1.SetActive(true);
			yield return new WaitForSeconds((dinodash/200)*100 + dinocd);
			fire1.SetActive(false);
			yield return null;}
		}

		IEnumerator FireB()
		{
			if(!WARNINGDECIDER){
			for (int i = 0; i <= dinospeed + dinocd/2; i++)
			{
				awarning2.SetActive(true);
				yield return new WaitForSeconds(1);
				awarning2.SetActive(false);
				yield return new WaitForSeconds(1);
			}
			fire2.SetActive(true);
			yield return new WaitForSeconds((dinodash/200)*100 + dinocd);
            fire2.SetActive(false);
			yield return null;}
			if(WARNINGDECIDER){
			for (int i = 0; i <= dinospeed + dinocd/2; i++)
			{
				cwarning2.SetActive(true);
				yield return new WaitForSeconds(1);
				cwarning2.SetActive(false);
				yield return new WaitForSeconds(1);
			}
			fire2.SetActive(true);
			yield return new WaitForSeconds((dinodash/200)*100 + dinocd);
            fire2.SetActive(false);
			yield return null;}
		}

		IEnumerator FireC()
		{
			if(!WARNINGDECIDER){
			for (int i = 0; i <= dinospeed + dinocd/2; i++)
			{
				awarning3.SetActive(true);
				yield return new WaitForSeconds(1);
				awarning3.SetActive(false);
				yield return new WaitForSeconds(1);
			}
			fire3.SetActive(true);
			yield return new WaitForSeconds((dinodash/200)*100 + dinocd);
            fire3.SetActive(false);
			yield return null;}
			if(WARNINGDECIDER){
			for (int i = 0; i <= dinospeed + dinocd/2; i++)
			{
				cwarning3.SetActive(true);
				yield return new WaitForSeconds(1);
				cwarning3.SetActive(false);
				yield return new WaitForSeconds(1);
			}
			fire3.SetActive(true);
			yield return new WaitForSeconds((dinodash/200)*100 + dinocd);
            fire3.SetActive(false);
			yield return null;}
		}

		IEnumerator FireD()
		{
			if(!WARNINGDECIDER){
			for (int i = 0; i <= dinospeed + dinocd/2; i++)
			{
				awarning4.SetActive(true);
				yield return new WaitForSeconds(1);
				awarning4.SetActive(false);
				yield return new WaitForSeconds(1);
			}
			fire4.SetActive(true);
			yield return new WaitForSeconds((dinodash/200)*100 + dinocd);
            fire4.SetActive(false);
			yield return null;}
			if(WARNINGDECIDER){
			for (int i = 0; i <= dinospeed + dinocd/2; i++)
			{
				cwarning4.SetActive(true);
				yield return new WaitForSeconds(1);
				cwarning4.SetActive(false);
				yield return new WaitForSeconds(1);
			}
			fire4.SetActive(true);
			yield return new WaitForSeconds((dinodash/200)*100 + dinocd);
            fire4.SetActive(false);
			yield return null;}
		}


		IEnumerator Roar() 
		{
		spritedefault.SetActive(false);
		spriteroar.SetActive(true);
		RoarScream();
		yield return new WaitForSeconds(6.5f);
		spriteroar.SetActive(false);
		spritedefault.SetActive(true);
			for (int i = 0; i <= 49; i++)
			{
				transform.position = transform.position + new Vector3(0, 0.5f, 0);
				yield return new WaitForSeconds(.07f);
			}
		yield return new WaitForSeconds(dinocd);
		if (Global.alive){StartCoroutine(Idle());}
		}
		void RoarScream()
		{
			ak.clip = aa;
			ak.Play();
		}
	}
}

