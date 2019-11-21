#include "RAVPO.h"

void KEYINPUT::INPUT_KEY(MOVING* MOVESTATUS, int delayamount,bool microsecond) {
	if (Serial.available()) {
		static int xp, yp;
		char key = Serial.read();
		Serial.println(xp);
		Serial.println(yp);
		switch (key)
		{
		case 'a': xp -= 1500; MOVESTATUS->MOVING_XY(xp, MOVESTATUS->cur_y);  break;
		case 'd': xp += 1500; MOVESTATUS->MOVING_XY(xp, MOVESTATUS->cur_y);  break;
		case 'w': yp += 1500; MOVESTATUS->MOVING_XY(MOVESTATUS->cur_x, yp);  break;
		case 's': yp -= 1500; MOVESTATUS->MOVING_XY(MOVESTATUS->cur_x, yp);  break;
		case 'r': xp -= xp; yp -= yp; MOVESTATUS->MOVING_XY(xp, yp); MOVESTATUS->RSF = true; break;
		default:
			break;
		}
	}
	delayMicroseconds((microsecond == true ? 1 : 1000) * delayamount);
}