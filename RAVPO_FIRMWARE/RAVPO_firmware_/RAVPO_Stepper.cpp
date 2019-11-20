#include "RAVPO.h"

void MOVING::RUNNING_STEPMOTOR(short MOTOR_ST) {
	static bool PWM_toggle_X = true;
	static bool PWM_toggle_Y = true;
	static int PWM_count_X = 0;
	static int PWM_count_Y = 0;

	switch (MOTOR_ST)
	{
	case MOVING_SELECT_X : 
		//digitalREAD (1 switch on / 0 switch off) | PorM(1 not switch direction /0 switch direction)
		if (j1E_start_trigger && (digitalRead(J1_MIN_PIN) == 1 || X_PorM == 1)) { 
			if (PWM_toggle_X) {
				PWM_count_X++;
				if (PWM_count_X >= abs(cur_x - distance_x)) {
					j1E_start_trigger = false;
					if (X_PorM) cur_x+=PWM_count_X;
					else cur_x-= PWM_count_X;
					PWM_count_X = 0;
					if (RSF) {
						cur_x = 0;
						RSF = false;
					}
				}
				digitalWrite(J1_STEP_PIN, 1);
				PWM_toggle_X = false;
			}
			else {
				digitalWrite(J1_STEP_PIN, 0);
				PWM_toggle_X = true;
			}
		}
		break;
	
	case MOVING_SELECT_Y:
		if (j2E_start_trigger && (digitalRead(J2_MIN_PIN) || Y_PorM)) {
			if (PWM_toggle_Y) {
				PWM_count_Y++;
				if (PWM_count_Y >= abs(cur_y - distance_y)) {
					
					j2E_start_trigger = false;
					if (Y_PorM) cur_y += PWM_count_Y;
					else cur_y -= PWM_count_Y;
					PWM_count_Y = 0;
					if (RSF) {
						cur_y = 0;
						RSF = false;
					}
				}
				digitalWrite(J2_STEP_PIN, 1);
				PWM_toggle_Y = false;
			}
			else {
				digitalWrite(J2_STEP_PIN, 0);
				PWM_toggle_Y = true;
			}
			break;
		}
	default:
		break;
	}
}

void MOVING::MOVING_XY(int xpos, int ypos) {
	JUDGEMENT_DIR(xpos, ypos);
	j1E_start_trigger = (xpos == cur_x ? false : true);
	j2E_start_trigger = (ypos == cur_y ? false : true);
	distance_x = xpos;
	distance_y = ypos;
}

void MOVING::JUDGEMENT_DIR(int xpos, int ypos) {
	if (xpos < cur_x) {
		digitalWrite(J1_DIR_PIN, 1);
		X_PorM = false;
	}
	else {
		digitalWrite(J1_DIR_PIN, 0);
		X_PorM = true;
	}

	if (ypos < cur_y) {
		digitalWrite(J2_DIR_PIN, 1);
		Y_PorM = false;
	}
	else {
		digitalWrite(J2_DIR_PIN, 0);
		Y_PorM = true;
	}
}



