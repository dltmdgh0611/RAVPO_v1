#include "RAVPO.h"

void KEYINPUT::INPUT_KEY(MOVING* MOVESTATUS, int delayamount,bool microsecond) {
	if (Serial.available()) {
		static int xp, yp;
		char key = Serial.read();
		switch (key)
		{
		case 'a': xp -= 500; MOVESTATUS->MOVING_XY(xp, 0);  break;
		case 'd': xp += 500;  MOVESTATUS->MOVING_XY(xp, 0); break;
		case 'w': yp += 500; MOVESTATUS->MOVING_XY(0, yp);  break;
		case 's': yp -= 500; MOVESTATUS->MOVING_XY(0, yp);  break;
		default:
			break;
		}
	}
	delayMicroseconds((microsecond == true ? 1 : 1000) * delayamount);
}