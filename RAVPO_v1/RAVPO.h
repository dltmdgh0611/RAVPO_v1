#include <Arduino.h>

#ifndef RAVPO_H
#define RAVPO_H

#define J1_STEP_PIN         54
#define J1_DIR_PIN          55
#define J1_ENABLE_PIN       38
#define J2_STEP_PIN			60
#define J2_DIR_PIN			61
#define J2_ENABLE_PIN		56

#define MOVING_SELECT_X		1
#define MOVING_SELECT_Y		2


class INITS
{
public:
	bool j1E = false; //fist joint
	bool j2E = false; //second joint
	bool roE = false; //rotate base

	void RAVPO_init(INITS initmod,int speed);
private:

};

struct MOVING
{
	bool j1E_start_trigger = false;
	bool j2E_start_trigger = false;
	bool roE_start_trigger = false;
	int distance_x, distance_y;
	void RUNNING_STEPMOTOR(short MOTOR_ST);
	void MOVING_XY(int xpos, int ypos);
	void JUDGEMENT_DIR(int xpos, int ypos);

};

class KEYINPUT
{
public:
	void INPUT_KEY(MOVING* MOVESTATUS, int delayamount, bool microsecond);

private:

};

#endif RAVPO_H