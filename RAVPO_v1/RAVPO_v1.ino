#include <math.h>
#include <RAVPO.h>

INITS INITMOD;

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
  
}
