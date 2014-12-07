using UnityEngine;
using System.Collections;

//Contient toutes les constantes liées au GameDesign
public class ConstantesManager {


	// -------------------------------------------------ENNEMY VAR--------------------------------------------------------
	public static float VARIATION_TIME_BETWEEN_ATTACK_PERCENT = 10 / 100;

	public static int FREQUENCE_POP=1500;
	public static int VARIANCE_FREQUENCE_POP_PERCENT=20/100;
	public static Vector2 POP_POINT_1 = new Vector2(45,5);
	public static Vector2 POP_POINT_2 = new Vector2(5,45);
	public static Vector2 POP_POINT_3 = new Vector2(25,25);

	



	//Hunter Var

	public static int HUNTER_PV = 100;
	public static int HUNTER_SCORE = 100;
	public static int HUNTER_SHOOT_DMG = 10;
	public static int HUNTER_KAMIKAZE_DMG = 100;
	public static float HUNTER_NORME_SPEED = 10;
	public static float HUNTER_TIME_BETWEEN_ATTACK = 2000; // time in ms


	//Frigate Var
	
	public static int FRIGATE_PV = 100;
	public static int FRIGATE_SCORE = 100;
	public static int FRIGATE_SHOOT_DMG = 10;
	public static int FRIGATE_KAMIKAZE_DMG = 100;
	public static float FRIGATE_NORME_SPEED = 10;
	public static float FRIGATE_TIME_BETWEEN_ATTACK = 2000; // time in ms

	//Cruiser Var

	public static int CRUISER_PV = 100;
	public static int CRUISER_SCORE = 100;
	public static int CRUISER_SHOOT_DMG = 10;
	public static int CRUISER_KAMIKAZE_DMG = 100;
	public static float CRUISER_NORME_SPEED = 10;
	public static float CRUISER_TIME_BETWEEN_ATTACK = 2000; // time in ms


	// -------------------------------------------------PLAYER VAR--------------------------------------------------------
	//City var
	public static int CITY_PV = 10000;

	//Disintegrator lvl 1 var
	public static int DISINTEGRATOR_LVL1_PV_MAX = 200; //shooting/sec
	public static int DISINTEGRATOR_LVL1_RATE_OF_FIRE = 10; //shooting/sec
	public static int DISINTEGRATOR_LVL1_SHOOT_DAMAGE = 50;
	public static int DISINTEGRATOR_LVL1_FRAGMENT_PERCENT = 16; //in percent !

	//Disintegrator lvl 2 var
	public static int DISINTEGRATOR_LVL2_PV_MAX = 400; //shooting/sec
	public static int DISINTEGRATOR_LVL2_RATE_OF_FIRE = 15; //shooting/sec
	public static int DISINTEGRATOR_LVL2_SHOOT_DAMAGE = 70;
	public static int DISINTEGRATOR_LVL2_FRAGMENT_PERCENT = 25; //in percent !

	//Disintegrator lvl 3 var
	public static int DISINTEGRATOR_LVL3_PV_MAX = 600; //shooting/sec
	public static int DISINTEGRATOR_LVL3_RATE_OF_FIRE = 20; //shooting/sec
	public static int DISINTEGRATOR_LVL3_SHOOT_DAMAGE = 100;
	public static int DISINTEGRATOR_LVL3_FRAGMENT_PERCENT = 33; //in percent !

	//Standard lvl 1 var
	public static int STANDARD_LVL1_PV_MAX = 200; //shooting/sec
	public static int STANDARD_LVL1_RATE_OF_FIRE = 10; //shooting/sec
	public static int STANDARD_LVL1_SHOOT_DAMAGE = 50;
	public static int STANDARD_LVL1_FRAGMENT_PERCENT = 100; //in percent !
	
	//Standard lvl 2 var
	public static int STANDARD_LVL2_PV_MAX = 400; //shooting/sec
	public static int STANDARD_LVL2_RATE_OF_FIRE = 15; //shooting/sec
	public static int STANDARD_LVL2_SHOOT_DAMAGE = 70;
	public static int STANDARD_LVL2_FRAGMENT_PERCENT = 90; //in percent !
	
	//Standard lvl 3 var
	public static int STANDARD_LVL3_PV_MAX = 600; //shooting/sec
	public static int STANDARD_LVL3_RATE_OF_FIRE = 20; //shooting/sec
	public static int STANDARD_LVL3_SHOOT_DAMAGE = 100;
	public static int STANDARD_LVL3_FRAGMENT_PERCENT = 80; //in percent !

}
