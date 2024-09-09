const int pinEsp = 35;
int valor = 0;
void setup() {
  Serial.begin(9600);
  randomSeed(analogRead(pinEsp));
}

void loop() {
  Serial.print(analogRead(pinEsp));
  valor = random(300);
  Serial.println(valor);
  delay(2000);
}
