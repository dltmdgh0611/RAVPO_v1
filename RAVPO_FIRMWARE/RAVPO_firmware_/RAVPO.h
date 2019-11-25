#include <Arduino.h>
#ifndef RAVPO_H
#define RAVPO_H

#define J1_STEP_PIN         54
#define J1_DIR_PIN          55
#define J1_ENABLE_PIN       38
#define J1_MIN_PIN           3

#define J2_STEP_PIN			60
#define J2_DIR_PIN			61
#define J2_ENABLE_PIN		56
#define J2_MIN_PIN          14

#define MOVING_SELECT_X		1
#define MOVING_SELECT_Y		2


class INITS
{
public:
	bool j1E = false; //fist joint
	bool j2E = false; //second joint
	bool roE = false; //rotate base

	//-----------------------------------//
	

	void RAVPO_init(INITS initmod,int speed);
private:

};

class MOVING
{
public :
	int cur_x, cur_y;
	bool j1E_start_trigger = false;
	bool j2E_start_trigger = false;
	bool roE_start_trigger = false;
	bool RSF;
	int distance_x, distance_y;
	void RUNNING_STEPMOTOR(short MOTOR_ST);
	void MOVING_XY(int xpos, int ypos);
private:
	void JUDGEMENT_DIR(int xpos, int ypos);
	bool X_PorM, Y_PorM;

};

class SERIALINPUT
{
public:
	int grid[11][11][2];
	void SERIAL_INPUT(MOVING* MOVESTATUS);
	void gridinit();
	int serial_count;
	int serialX, serialY;
private:

};


class KEYINPUT
{
public:
	void INPUT_KEY(MOVING* MOVESTATUS, int delayamount, bool microsecond);

private:

};


#endif RAVPO_H