#include "RAVPO.h"

void MOVING::RUNNING_STEPMOTOR(short MOTOR_ST) {
	static bool PWM_toggle = true;
	static int PWM_count = 0;
	switch (MOTOR_ST)
	{
	case MOVING_SELECT_X : 
		if (j1E_start_trigger) {
			Serial.println("stepping");
			if (PWM_toggle) {
				PWM_count++;

				if (PWM_count >= abs(distance_x)) {
					j1E_start_trigger = false;
					PWM_count = 0;
				}
				digitalWrite(J1_STEP_PIN, 1);
				PWM_toggle = false;
			}
			else {
				digitalWrite(J1_STEP_PIN, 0);
				PWM_toggle = true;
			}
		}
		break;
	
	case MOVING_SELECT_Y:
		if (j2E_start_trigger) {
			if (PWM_toggle) {
				PWM_count++;

				if (PWM_count >= abs(distance_y)) {
					PWM_count = 0;
					j2E_start_trigger = false;
				}
				digitalWrite(J2_STEP_PIN, 1);
				PWM_toggle = false;
			}
			else {
				digitalWrite(J2_STEP_PIN, 0);
				PWM_toggle = true;
			}
			break;
		}
	default:
		break;
	}
}

void MOVING::MOVING_XY(int xpos, int ypos) {
	JUDGEMENT_DIR(xpos, ypos);
	Serial.println("movingmethod");
	j1E_start_trigger = (xpos == 0 ? false : true);
	j2E_start_trigger = (ypos == 0 ? false : true);
	Serial.println(j1E_start_trigger);
	distance_x = xpos;
	distance_y = ypos;
}

void MOVING::JUDGEMENT_DIR(int xpos, int ypos) {
	Serial.println("judgement dir");
	if (xpos < 0) digitalWrite(J1_DIR_PIN, 1);
	else digitalWrite(J1_DIR_PIN, 0);
	if (ypos < 0) digitalWrite(J2_DIR_PIN, 1);
	else digitalWrite(J2_DIR_PIN, 0);
}



