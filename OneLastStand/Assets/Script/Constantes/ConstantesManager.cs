using UnityEngine;
using System.Collections;

//Contient toutes les constantes liées au GameDesign
public class ConstantesManager {


	// -------------------------------------------------ENNEMY VAR--------------------------------------------------------

	public static float VARIATION_TIME_BETWEEN_ATTACK_PERCENT = 10 / 100;

	public static float FREQUENCE_POP=1.5f;
	public static int VARIANCE_FREQUENCE_POP_PERCENT=20/100;

	public static Vector2 POP_POINT_1 = new Vector2(45,5);
	public static Vector2 POP_POINT_2 = new Vector2(5,45);
	public static Vector2 POP_POINT_3 = new Vector2(25,25);
	public static float ERROR_MARGE_POP = 10f;


	//Vague Var

	public static int FP_INITIAL = 4;
	public static int NB_PRECALCULATE_VAGUE = 3;
	public static float MIN_PERCENT_HUNTER = 20/100;
	public static float MAX_PERCENT_CRUISER = 50/100;

	public static int COST_HUNTER = 1;
	public static int COST_FRIGATE = 5;
	public static int COST_CRUISER = 20;




	//Hunter Var

	public static float HUNTER_FRAG_STANDARD_PERCENT = 100/100;
	public static float HUNTER_FRAG_DISINTEGRATOR_PERCENT = 16/100;
	public static float HUNTER_FRAG_EMP_PERCENT = 180/100;

	public static int HUNTER_PV = 100;
	public static int HUNTER_SCORE = 100;
	public static int HUNTER_SHOOT_DMG = 10;
	public static int HUNTER_KAMIKAZE_DMG = 100;
	public static float HUNTER_NORME_SPEED = 10;
	public static float HUNTER_TIME_BETWEEN_ATTACK = 2f; // time in s


	//Frigate Var

	public static float FRIGATE_FRAG_STANDARD_PERCENT = 90/100;
	public static float FRIGATE_FRAG_DISINTEGRATOR_PERCENT = 25/100;
	public static float FRIGATE_FRAG_EMP_PERCENT = 200/100;
	
	public static int FRIGATE_PV = 100;
	public static int FRIGATE_SCORE = 100;
	public static int FRIGATE_SHOOT_DMG = 10;
	public static int FRIGATE_KAMIKAZE_DMG = 100;
	public static float FRIGATE_NORME_SPEED = 10;
	public static float FRIGATE_TIME_BETWEEN_ATTACK = 2f; // time in s

	//Cruiser Var

	public static float CRUISER_FRAG_STANDARD_PERCENT = 80/100;
	public static float CRUISER_FRAG_DISINTEGRATOR_PERCENT = 33/100;
	public static float CRUISER_FRAG_EMP_PERCENT = 250/100;

	public static int CRUISER_PV = 100;
	public static int CRUISER_SCORE = 100;
	public static int CRUISER_SHOOT_DMG = 10;
	public static int CRUISER_KAMIKAZE_DMG = 100;
	public static float CRUISER_NORME_SPEED = 10;
	public static float CRUISER_TIME_BETWEEN_ATTACK = 2f; // time in s


	// -------------------------------------------------PLAYER VAR--------------------------------------------------------
	//City var
	public static int CITY_PV_MAX = 10000;

	//Bullet var
	public static float BULLET_TURRET_SPEED = 250; //px/sec
	public static float BULLET_TURRET_LIFE_TIME = 5; //sec

	//Disintegrator lvl 1 var
	public static int DISINTEGRATOR_LVL1_PV_MAX = 200; //shooting/sec
	public static int DISINTEGRATOR_LVL1_RATE_OF_FIRE = 10; //shooting/sec
	public static int DISINTEGRATOR_LVL1_SHOOT_DAMAGE = 50;

	//Disintegrator lvl 2 var
	public static int DISINTEGRATOR_LVL2_PV_MAX = 400; //shooting/sec
	public static int DISINTEGRATOR_LVL2_RATE_OF_FIRE = 15; //shooting/sec
	public static int DISINTEGRATOR_LVL2_SHOOT_DAMAGE = 70;

	//Disintegrator lvl 3 var
	public static int DISINTEGRATOR_LVL3_PV_MAX = 600; //shooting/sec
	public static int DISINTEGRATOR_LVL3_RATE_OF_FIRE = 20; //shooting/sec
	public static int DISINTEGRATOR_LVL3_SHOOT_DAMAGE = 100;

	//Standard lvl 1 var
	public static int STANDARD_LVL1_PV_MAX = 200; //shooting/sec
	public static int STANDARD_LVL1_RATE_OF_FIRE = 15; //shooting/sec
	public static int STANDARD_LVL1_SHOOT_DAMAGE = 15;
	
	//Standard lvl 2 var
	public static int STANDARD_LVL2_PV_MAX = 400; //shooting/sec
	public static int STANDARD_LVL2_RATE_OF_FIRE = 20; //shooting/sec
	public static int STANDARD_LVL2_SHOOT_DAMAGE = 25;
	
	//Standard lvl 3 var
	public static int STANDARD_LVL3_PV_MAX = 600; //shooting/sec
	public static int STANDARD_LVL3_RATE_OF_FIRE = 25; //shooting/sec
	public static int STANDARD_LVL3_SHOOT_DAMAGE = 40;

	//EMP lvl 1 var
	public static int EMP_LVL1_PV_MAX = 200; //shooting/sec
	public static int EMP_LVL1_RATE_OF_FIRE = 5; //shooting/sec
	public static int EMP_LVL1_SHOOT_DAMAGE = 60;
	
	//EMP lvl 2 var
	public static int EMP_LVL2_PV_MAX = 400; //shooting/sec
	public static int EMP_LVL2_RATE_OF_FIRE = 10; //shooting/sec
	public static int EMP_LVL2_SHOOT_DAMAGE = 80;
	
	//EMP lvl 3 var
	public static int EMP_LVL3_PV_MAX = 600; //shooting/sec
	public static int EMP_LVL3_RATE_OF_FIRE = 15; //shooting/sec
	public static int EMP_LVL3_SHOOT_DAMAGE = 110;

}
