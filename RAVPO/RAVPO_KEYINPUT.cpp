#include "RAVPO.h"

MOVING Moving;

void KEYINPUT::INPUT_KEY(int delayamount,bool microsecond) {
	if (Serial.available()) {
		char key = Serial.read();
		if (key == 'a') Moving.MOVING_XY(200, 0);
		if (key == 'd') Moving.MOVING_XY(-200, 0);
	}
	delayMicroseconds((microsecond == true ? 1 : 1000) * delayamount);
}