#define POT_0_PIN A0
#define POT_1_PIN A1
#define POT_2_PIN A2
#define POT_3_PIN A3
#define BTN_PIN 2

long BTN_LAST = 0;
long BTN_THRESHHOLD = 500;

long POT_0_VAL = 0;
long last_POT_0_VAL = -1;

long POT_1_VAL = 0;
long last_POT_1_VAL = -1;

long POT_2_VAL = 0;
long last_POT_2_VAL = -1;

long POT_3_VAL = 0;
long last_POT_3_VAL = -1;

void setup() {
  pinMode(POT_0_PIN, INPUT);
  pinMode(POT_1_PIN, INPUT);
  pinMode(POT_2_PIN, INPUT);
  pinMode(POT_3_PIN, INPUT);
  pinMode(BTN_PIN, INPUT);
  attachInterrupt(digitalPinToInterrupt(BTN_PIN), BTN_FUNC, RISING);
  Serial.begin(9600);
}

void loop() {
  POT_0_VAL = (long) (1023 - analogRead(POT_0_PIN))*100/1023;
  POT_1_VAL = (long) (1023 - analogRead(POT_1_PIN))*100/1023;
  POT_2_VAL = (long) (1023 - analogRead(POT_2_PIN))*100/1023;
  POT_3_VAL = (long) (1023 - analogRead(POT_3_PIN))*100/1023;
  
  if(abs(POT_0_VAL - last_POT_0_VAL)>1){
    Serial.print("0");
    Serial.print(POT_0_VAL);
    Serial.print("\n");
    last_POT_0_VAL = POT_0_VAL;
  }

  if(abs(POT_1_VAL - last_POT_1_VAL)>1){
    Serial.print("1");
    Serial.print(POT_1_VAL);
    Serial.print("\n");
    last_POT_1_VAL = POT_1_VAL;
  }

  if(abs(POT_2_VAL - last_POT_2_VAL)>1){
    Serial.print("2");
    Serial.print(POT_2_VAL);
    Serial.print("\n");
    last_POT_2_VAL = POT_2_VAL;
  }

  if(abs(POT_3_VAL - last_POT_3_VAL)>1){
    Serial.print("3");
    Serial.print(POT_3_VAL);
    Serial.print("\n");
    last_POT_3_VAL = POT_3_VAL;
  }
  delay(100);
}

void BTN_FUNC(){
  if(millis() - BTN_LAST > BTN_THRESHHOLD){
    Serial.print("B");
    Serial.print(digitalRead(BTN_PIN));
    Serial.print("\n");
    BTN_LAST = millis();
  }
}
