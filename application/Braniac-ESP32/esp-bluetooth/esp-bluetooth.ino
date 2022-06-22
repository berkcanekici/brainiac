int val_0 = 0;
int val_1 = 0;
int val_2 = 0;
int val_3 = 0;
#include "BluetoothSerial.h"
BluetoothSerial SerialBT;
void setup() {
  // put your setup code here, to run once:
  SerialBT.begin("ESP32test");
  delay(1000);
  Serial.begin(9600);
  pinMode(18, OUTPUT);
  pinMode(19, OUTPUT);

  digitalWrite(18, HIGH);
  digitalWrite(19, HIGH);
}

void loop() {
  // put your main code here, to run repeatedly:

  val_0 = analogRead(39);
  val_1 = analogRead(36);
  val_2 = analogRead(34);
  val_3 = analogRead(35);
  if (SerialBT.available()) {
    SerialBT.println(String(val_0)+  ";" + String(val_1) + ";"  + String(val_2) + ";" + String(val_3));
  }
  Serial.print("0: ");
  Serial.print(val_0);
  Serial.print(" ");

  Serial.print("1: ");
  Serial.print(val_1);
  Serial.print(" ");

  Serial.print("2: ");
  Serial.print(val_2);
  Serial.print(" ");

  Serial.print("3: ");
  Serial.print(val_3);
  Serial.println("");

  delay(250);
}
