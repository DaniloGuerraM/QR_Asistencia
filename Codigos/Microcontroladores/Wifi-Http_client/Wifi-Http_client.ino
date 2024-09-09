#include <WiFi.h>
#include <HTTPClient.h>


const char* ssid = "casa guerra";
const char* password = "Nachoytom";
String url = "http://www.google.com";

void setup()
{
  Serial.begin(115200);
  delay(10);

  // Conectar a WiFi
  WiFi.begin(ssid, password);
  Serial.print("Conectando a WiFi ");
  
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  Serial.println("");
  Serial.println("WiFi conectado.");
  Serial.println("Dirección IP: ");
  Serial.println(WiFi.localIP());
}

void loop()
{
  if (WiFi.status() == WL_CONNECTED) { 
    HTTPClient http;
    WiFiClient client;


    if (http.begin(client, url)) {
      Serial.println("[HTTP] GET...");

      int httpCode = http.GET(); 

  
      if (httpCode > 0) {
        Serial.printf("[HTTP] GET... código: %d\n", httpCode);


        if (httpCode == HTTP_CODE_OK) {
          String payload = http.getString();  
          Serial.println(payload);  
          }
      } else {
        Serial.printf("[HTTP] GET... fallido, error: %s\n", http.errorToString(httpCode).c_str());
      }

      http.end(); 
    } else {
      Serial.println("[HTTP] No se pudo conectar");
    }
  } else {
    Serial.println("WiFi no está conectado");
  }

  delay(30000);  
}
