#include "RAVPO.h"
MOVING m;
void INITS::RAVPO_init(INITS initmod) {
	if (initmod.j1E) {
		TCCR1A = 0x00;
		TCCR1B = 0x0A;
		TCCR1C = 0x00;
		OCR1A = 200;
		TIMSK1 = 0x02;
		pinMode(J1_STEP_PIN, OUTPUT);
		pinMode(J1_DIR_PIN, OUTPUT);
		pinMode(J1_ENABLE_PIN, OUTPUT);
	}
	if (initmod.j2E) {
		TCCR3A = 0x00;
		TCCR3B = 0x0A;
		TCCR3C = 0x00;
		OCR3A = 200;
		TIMSK3 = 0x02;
		pinMode(J2_STEP_PIN, OUTPUT);
		pinMode(J2_DIR_PIN, OUTPUT);
		pinMode(J2_ENABLE_PIN, OUTPUT);
	}
}

void MOVING::RUNNING_STEPMOTOR(short MOTOR_ST) {
	bool PWM_toggle;
	int PWM_count;
	switch (MOTOR_ST)
	{
	case MOVING_SELECT_X : 
		if (j1E_start_trigger) {
			if (PWM_toggle) {
				PWM_count++;

				if (PWM_count >= abs(distance_x)) {
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

	j1E_start_trigger = xpos == 0 ? false : true;
	j2E_start_trigger = ypos == 0 ? false : true;
	distance_x = xpos;
	distance_y = ypos;
}

void MOVING::JUDGEMENT_DIR(int xpos, int ypos) {
	if (xpos < 0) digitalWrite(J1_STEP_PIN, 1);
	else digitalWrite(J1_STEP_PIN, 0);
	if (ypos < 0) digitalWrite(J2_STEP_PIN, 1);
	else digitalWrite(J2_STEP_PIN, 0);
}

void KEYINPUT::INPUT_KEY() {
	if (Serial.available()) {
		char key = Serial.read();
		if (key == 'a') m.MOVING_XY(200, 0);
		if (key == 'd') m.MOVING_XY(-200, 0);
	}
}

