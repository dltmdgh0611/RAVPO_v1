#include "RAVPO.h"

void KEYINPUT::INPUT_KEY(MOVING* MOVESTATUS, int delayamount,bool microsecond) {
	if (Serial.available()) {
		Serial.println("aval");
		char key = Serial.read();
		if (key == 'a') MOVESTATUS->MOVING_XY(-200, 0);
		if (key == 'd') MOVESTATUS->MOVING_XY(200, 0);
		if (key == 'w') MOVESTATUS->MOVING_XY(0, 200);
		if (key == 's') MOVESTATUS->MOVING_XY(0, -200);
	}
	delayMicroseconds((microsecond == true ? 1 : 1000) * delayamount);
}