using UnityEngine;
using System.Collections;

//Contient toutes les constantes liées au GameDesign
public class ConstantesManager {


	// -------------------------------------------------ENNEMY VAR--------------------------------------------------------

	public static float VARIATION_TIME_BETWEEN_ATTACK_PERCENT = 10 / 100;

	public static float FREQUENCE_POP=1.5f;
	public static float VARIANCE_FREQUENCE_POP_PERCENT=20f/100f;

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

	public static float HUNTER_FRAG_STANDARD_PERCENT = 100f/100f;
	public static float HUNTER_FRAG_DISINTEGRATOR_PERCENT = 16f/100f;
	public static float HUNTER_FRAG_EMP_PERCENT = 180f/100f;

	public static int HUNTER_PV = 1000;
	public static int HUNTER_SCORE = 100;
	public static int HUNTER_SHOOT_DMG = 10;
	public static int HUNTER_KAMIKAZE_DMG = 100;
	public static float HUNTER_NORME_SPEED = 50;
	public static float HUNTER_TIME_BETWEEN_ATTACK = 2f; // time in s


	//Frigate Var

	public static float FRIGATE_FRAG_STANDARD_PERCENT = 90f/100f;
	public static float FRIGATE_FRAG_DISINTEGRATOR_PERCENT = 25f/100f;
	public static float FRIGATE_FRAG_EMP_PERCENT = 200f/100f;
	
	public static int FRIGATE_PV = 100;
	public static int FRIGATE_SCORE = 100;
	public static int FRIGATE_SHOOT_DMG = 10;
	public static int FRIGATE_KAMIKAZE_DMG = 100;
	public static float FRIGATE_NORME_SPEED = 10;
	public static float FRIGATE_TIME_BETWEEN_ATTACK = 2f; // time in s

	//Cruiser Var

	public static float CRUISER_FRAG_STANDARD_PERCENT = 80f/100f;
	public static float CRUISER_FRAG_DISINTEGRATOR_PERCENT = 33f/100f;
	public static float CRUISER_FRAG_EMP_PERCENT = 250f/100f;

	public static int CRUISER_PV = 100;
	public static int CRUISER_SCORE = 100;
	public static int CRUISER_SHOOT_DMG = 10;
	public static int CRUISER_KAMIKAZE_DMG = 100;
	public static float CRUISER_NORME_SPEED = 10;
	public static float CRUISER_TIME_BETWEEN_ATTACK = 2f; // time in s


	// -------------------------------------------------PLAYER VAR--------------------------------------------------------

	//Player var
	public static Color SCORE_LABEL_COLOR = new Color (0,255,0);
	public static Color FRAGMENT_LABEL_COLOR = new Color (0,255,0);
	public static Color LIFE_LABEL_COLOR = new Color (255,0,0);
	public static float TIME_IN_CONSTRUCTION_STATE = 30f;//sec
	public static int POINT_SURVIVE_VAGUE = 1000;

	//City var
	public static int CITY_PV_MAX = 10000;
	public static Vector3 CITY_LOCAL_POSITION = new Vector3(100,230,0);

	//Label var
	public static int LABEL_LIFE_TIME = 3;//sec

	//Bullet var
	public static float BULLET_TURRET_SPEED = 250; //px/sec
	public static float BULLET_TURRET_LIFE_TIME = 5; //sec

	//Turret var
	public static Vector3 TURRET_1_LOCAL_POSITION = new Vector3(-35,85,0);
	public static Vector3 TURRET_2_LOCAL_POSITION = new Vector3(35,65,0);
	public static Vector3 TURRET_3_LOCAL_POSITION = new Vector3(85,5,0);
	public static Vector3 TURRET_4_LOCAL_POSITION = new Vector3(135,8,0);
	public static float DISTANCE_OF_VUE_SHOOT = 1000;//pixel

	//Disintegrator lvl 1 var
	public static int DISINTEGRATOR_LVL1_PV_MAX = 200; //shooting/sec
	public static float DISINTEGRATOR_LVL1_RATE_OF_FIRE = 1f; //shooting/sec
	public static int DISINTEGRATOR_LVL1_SHOOT_DAMAGE = 50;

	//Disintegrator lvl 2 var
	public static int DISINTEGRATOR_LVL2_PV_MAX = 400; //shooting/sec
	public static float DISINTEGRATOR_LVL2_RATE_OF_FIRE = 2; //shooting/sec
	public static int DISINTEGRATOR_LVL2_SHOOT_DAMAGE = 70;

	//Disintegrator lvl 3 var
	public static int DISINTEGRATOR_LVL3_PV_MAX = 600; //shooting/sec
	public static float DISINTEGRATOR_LVL3_RATE_OF_FIRE = 3f; //shooting/sec
	public static int DISINTEGRATOR_LVL3_SHOOT_DAMAGE = 100;

	//Standard lvl 1 var
	public static int STANDARD_LVL1_PV_MAX = 200; //shooting/sec
	public static float STANDARD_LVL1_RATE_OF_FIRE = 1f; //shooting/sec
	public static int STANDARD_LVL1_SHOOT_DAMAGE = 15;
	
	//Standard lvl 2 var
	public static int STANDARD_LVL2_PV_MAX = 400; //shooting/sec
	public static float STANDARD_LVL2_RATE_OF_FIRE = 2f; //shooting/sec
	public static int STANDARD_LVL2_SHOOT_DAMAGE = 25;
	
	//Standard lvl 3 var
	public static int STANDARD_LVL3_PV_MAX = 600; //shooting/sec
	public static float STANDARD_LVL3_RATE_OF_FIRE = 3f; //shooting/sec
	public static int STANDARD_LVL3_SHOOT_DAMAGE = 40;

	//EMP lvl 1 var
	public static int EMP_LVL1_PV_MAX = 200; //shooting/sec
	public static float EMP_LVL1_RATE_OF_FIRE = 1f; //shooting/sec
	public static int EMP_LVL1_SHOOT_DAMAGE = 60;
	
	//EMP lvl 2 var
	public static int EMP_LVL2_PV_MAX = 400; //shooting/sec
	public static float EMP_LVL2_RATE_OF_FIRE = 2f; //shooting/sec
	public static int EMP_LVL2_SHOOT_DAMAGE = 80;
	
	//EMP lvl 3 var
	public static int EMP_LVL3_PV_MAX = 600; //shooting/sec
	public static float EMP_LVL3_RATE_OF_FIRE = 3f; //shooting/sec
	public static int EMP_LVL3_SHOOT_DAMAGE = 110;

}
