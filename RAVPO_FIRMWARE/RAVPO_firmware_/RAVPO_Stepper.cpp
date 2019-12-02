#include "RAVPO.h"
//윈도우 락을 생활화 합시다.
void MOVING::RUNNING_STEPMOTOR(short MOTOR_ST) {
	static bool PWM_toggle_X = true;
	static bool PWM_toggle_Y = true;
	static int PWM_count_X = 0;
	static int PWM_count_Y = 0;
	static bool move_toggle = true;
	switch (MOTOR_ST)
	{
	case MOVING_SELECT_X:
		if (j1E_start_trigger && (digitalRead(J1_MIN_PIN) == 1 || X_PorM == 1)) {
			stepXfin = false;

			if (PWM_toggle_X) {
				PWM_count_X++;
				if (PWM_count_X >= abs(cur_x - distance_x)) {
					j1E_start_trigger = false;
					if (X_PorM) cur_x += PWM_count_X;
					else cur_x -= PWM_count_X;
					PWM_count_X = 0;
					if (RSF) {
						cur_x = 0;
						RSF = false;
					}
					stepXfin = true;
					if (drawenable && stepXfin && stepYfin) roE_start_trigger = true;
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
			stepYfin = false;
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
					stepYfin = true;
					if (drawenable && stepXfin && stepYfin) roE_start_trigger = true;
				}
				digitalWrite(J2_STEP_PIN, 1);
				PWM_toggle_Y = false;
			}
			else {
				digitalWrite(J2_STEP_PIN, 0);
				PWM_toggle_Y = true;
			}
			
		}
		break;
	default:
		break;
	}
}

void MOVING::run_z() {
	static bool PWM_toggle_Z = true;
	static int PWM_count_Z = 0;
	

	if (roE_start_trigger) {
		if (PWM_toggle_Z) {
			PWM_count_Z++;
			if (PWM_count_Z == 1) {
				digitalWrite(Z_DIR_PIN, 0);
			}
			if(PWM_count_Z<4000) digitalWrite(Z_STEP_PIN, 1);
			if (PWM_count_Z >= 4000 && PWM_count_Z<9000) {
				draw(PWM_count_Z);
			}
			if (PWM_count_Z >= 9000 && PWM_count_Z <13000) {
				
				digitalWrite(Z_DIR_PIN, 1);
				digitalWrite(Z_STEP_PIN, 1);
			}
			if (PWM_count_Z >= 13000) {
				roE_start_trigger = false;
				PWM_count_Z = 0;
				MOVING_XY(26000, 23500);
				drawenable = false;
			}
			PWM_toggle_Z = false;
		}
		else {
			digitalWrite(Z_STEP_PIN, 0);
			digitalWrite(J1_STEP_PIN, 0);
			digitalWrite(J2_STEP_PIN, 0);
			PWM_toggle_Z = true;
		}
	}
}

void MOVING::draw(int value) {
	if (value <= 4300) {
		digitalWrite(J1_DIR_PIN, 0);
		digitalWrite(J2_DIR_PIN, 0);
		digitalWrite(J1_STEP_PIN, 1);
		digitalWrite(J2_STEP_PIN, 1);
	}
	if (value > 4300 && value <= 4900) {
		digitalWrite(J1_DIR_PIN, 1);
		digitalWrite(J1_STEP_PIN, 1);
	}
	if (value > 4900 && value <= 5500) {
		digitalWrite(J2_DIR_PIN, 1);
		digitalWrite(J2_STEP_PIN, 1);
	}
	if (value > 5500 && value <= 6100) {
		digitalWrite(J1_DIR_PIN, 0);
		digitalWrite(J1_STEP_PIN, 1);
	}
	if (value > 6100 && value <= 6700) {
		digitalWrite(J2_DIR_PIN, 0);
		digitalWrite(J2_STEP_PIN, 1);
	}
	if (value > 6700 && value <= 7000) {
		digitalWrite(J1_DIR_PIN, 1);
		digitalWrite(J2_DIR_PIN, 1);
		digitalWrite(J1_STEP_PIN, 1);
		digitalWrite(J2_STEP_PIN, 1);
	}
}


void MOVING::MOVING_XY(int xpos, int ypos) {
	if (stepXfin && stepYfin) {
		JUDGEMENT_DIR(xpos, ypos);
		j1E_start_trigger = (xpos == cur_x ? false : true);
		j2E_start_trigger = (ypos == cur_y ? false : true);
		distance_x = xpos;
		distance_y = ypos;
		stepXfin = false;
		stepYfin = false;
	}
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



