#include "Variables.h"
#include "GeneratorQR.h"
#include "HacerPOST.h"
#include "NumeroRandom.h"

void setup() {
  

  Serial.begin(115200);
  WiFi.begin(ssid, password);
  u8g2.begin();

  randomSeed(analogRead(pinEsp));

    Serial.print("Conectando a WiFi...");
  while (WiFi.status() != WL_CONNECTED) {
    delay(1000);
    Serial.print(".");
  }

  Serial.println();
  Serial.println("Conectado a WiFi");
 //display.begin(SSD1306_EXTERNALVCC, 0x3c);

  //showQRCode("https://cyberello.com");
  

}

void loop() {
  mostrar = codificacion();
  showQRCode(mostrar);
  Post(mostrar);
  Serial.println("-------------------------");
  Serial.println(mostrar);
  Serial.println("-------------------------");

  delay(4000);
  //Serial.println("hola Mundo!!");
}
