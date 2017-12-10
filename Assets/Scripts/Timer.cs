using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

	public Semaforo semaforo;
	public CarroEplode explode;
	public float tiempoDespacio = 4f;
	public float tiempoLento = 2f;

	private float input;

	private bool muyDespacio;
	private bool muyLento;

	private bool primeraLLamada;
	private bool segundaLlamada;
	private bool terceraLlamada;

	private float tiempo;
	private float timer;

	public bool setToExplode;

	void Update ()
	{
		if (setToExplode) {
			input = Input.GetAxis ("Vertical");


			if (input == 0 && !muyDespacio) {
				Reset ();
				tiempo = 0;
				timer = tiempoDespacio;

				muyDespacio = true;
				muyLento = false;

			} else if (input == -1 && !muyLento) {
				Reset ();
				tiempo = 0;
				timer = tiempoLento;

				muyDespacio = false;
				muyLento = true;
			}

			tiempo += Time.deltaTime;

			if (tiempo > (timer / 3) && !primeraLLamada) {
				primeraLLamada = true;
				PrimeraLlamada ();
			} else if (tiempo > (timer / 3) * 2 && !segundaLlamada) {
				segundaLlamada = true;
				SegundaLlamada ();
			} else if (tiempo > timer && !terceraLlamada) {
				terceraLlamada = true;
				TerceraLlamada ();
			}
		}
	}

	void PrimeraLlamada ()
	{
		semaforo.Luz1 ();
	}

	void SegundaLlamada ()
	{
		semaforo.Luz2 ();
	}

	void TerceraLlamada ()
	{
		semaforo.Luz3 ();
		explode.Explode ();
	}

	void Reset ()
	{
		semaforo.BlankColors ();

		primeraLLamada = false;
		segundaLlamada = false;
		terceraLlamada = false;
	}
}
