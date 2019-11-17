#include <math.h>
#include <RAVPO.h>

INITS INITMOD;
MOVING MOVINGSTATUS;
KEYINPUT keyinput;

void setup() {

	//all init
	{
		INITMOD.j1E = true;
		INITMOD.j2E = true;
		INITMOD.roE = true;
	} 
	
	
	INITMOD.RAVPO_init(INITMOD);
}

void loop() {
	keyinput.INPUT_KEY(1,false);
}


SIGNAL(TIMER1_COMPA_vect)
{
	MOVINGSTATUS.RUNNING_STEPMOTOR(MOVING_SELECT_X);
}

SIGNAL(TIMER3_COMPA_vect)
{
	MOVINGSTATUS.RUNNING_STEPMOTOR(MOVING_SELECT_Y);
}