#include <math.h>
#include "RAVPO.h"

MOVING MOVESTATUS;
INITS INITMOD;
KEYINPUT keyinput;
SERIALINPUT SerialInput;

void setup() {

	//all init
	{
		INITMOD.j1E = true;
		INITMOD.j2E = true;
		INITMOD.roE = true;
	} 
	
	
	INITMOD.RAVPO_init(INITMOD, 200);
	SerialInput.gridinit();
	MOVESTATUS = MOVING();
}

void loop() {   
	//keyinput.INPUT_KEY(&MOVESTATUS, 1, false);
	SerialInput.SERIAL_INPUT(&MOVESTATUS);
}


SIGNAL(TIMER1_COMPA_vect)
{
	MOVESTATUS.RUNNING_STEPMOTOR(MOVING_SELECT_X);
}

SIGNAL(TIMER3_COMPA_vect)
{
	MOVESTATUS.RUNNING_STEPMOTOR(MOVING_SELECT_Y);
}