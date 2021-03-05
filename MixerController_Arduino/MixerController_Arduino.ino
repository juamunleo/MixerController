#define POT_IZQ_PIN A0
#define POT_DER_PIN A1

long POT_IZQ_VAL = 0;
long last_POT_IZQ_VAL = 0;
long POT_DER_VAL = 0;
long last_POT_DER_VAL = 0;

void setup() {
  pinMode(POT_IZQ_PIN, INPUT);
  pinMode(POT_DER_PIN, INPUT);
  Serial.begin(9600);
}

void loop() {
  POT_IZQ_VAL = (long) (1023 - analogRead(POT_IZQ_PIN))*100/1023;
  POT_DER_VAL = (long) (1023 - analogRead(POT_DER_PIN))*100/1023;
  if(POT_IZQ_VAL != last_POT_IZQ_VAL){
    //Serial.print("\nPotenciometro izquierdo:");
    Serial.print("0");
    Serial.print(POT_IZQ_VAL);
    Serial.print("\n");
    last_POT_IZQ_VAL = POT_IZQ_VAL;
  }

  if(POT_DER_VAL != last_POT_DER_VAL){
    //Serial.print("\nPotenciometro derecho:");
    Serial.print("1");
    Serial.print(POT_DER_VAL);
    Serial.print("\n");
    last_POT_DER_VAL = POT_DER_VAL;
  }
  delay(100);
}
