#include "RAVPO.h"

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

