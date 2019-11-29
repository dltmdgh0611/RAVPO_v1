#include "RAVPO.h"
#define x 0
#define y 1

void SERIALINPUT::gridinit() {
	for (int w = 0; w < 11; w++) {
		for (int h = 0; h < 11; h++) {
			grid[w][h][x] = 7000 + w * 1500;
			grid[w][h][y] = 19000 - h * 1500;
		}
	}
}


void SERIALINPUT::SERIAL_INPUT(MOVING* MOVESTATUS) {
	if (Serial.available()) {
		serial_count++;
		switch (serial_count)
		{
		case 1: Serial.setTimeout(5); serialX = Serial.parseInt(); break;
		case 2: 
			Serial.setTimeout(5);
			serialY = Serial.parseInt();
			serial_count = 0;

			MOVESTATUS->MOVING_XY(grid[serialX][serialY][x], grid[serialX][serialY][y]);
			break;

		default:
			break;
		}
	}
}