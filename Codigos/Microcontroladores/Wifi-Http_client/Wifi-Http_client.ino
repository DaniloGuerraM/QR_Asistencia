#include <WiFi.h>
#include <HTTPClient.h>

// Replace with your WiFi data
const char* ssid = "laboratorio";
const char* password = "laboratorio";

const char* serverName = "http://172.23.5.208:3001/esp32";
//String url = "http://www.google.com";//172.23.5.222
//String url = "http://192.168.56.1:3001/esp32";192.168.56.1

unsigned long lastTime = 0;

unsigned long timerTime = 5000;



void setup()
{
  Serial.begin(115200);
  delay(10);

  // Connect to WiFi
  WiFi.begin(ssid, password);
  Serial.print("conectando");
  while (WiFi.status() != WL_CONNECTED) 
  {
    Serial.print(".");
    delay(500);
  }

  Serial.println("");
  Serial.println("conectando a red WIFI con direccion IP");
  Serial.println(WiFi.localIP());

//WiFi.printDiag((Print) &Serial);

    
}

void loop()
{
  if ((millis() - lastTime) > timerTime)
  {
    if (WiFi.status() == WL_CONNECTED)
    {
      HTTPClient http;
      WiFiClient client;
      http.begin(client, serverName);

      http.addHeader("Content-Type", "text/plain");
      int httpResponseCode = http.POST("Hello. World");

      Serial.print("HTTP Response code: ");
      Serial.println(httpResponseCode);
      http.end();
    }else {
      Serial.println("WiFi desconectada");
    }
    lastTime = millis();
  }
}


/*
 *  HTTPClient http;
  WiFiClient client;

//bool begin(NetworkClient &client, String host, uint16_t port, String uri = "/", bool https = false);

  //if (http.begin(client, url,443,"/v1/current.json?q=eduardo&lang=es&key=87637c428a6a496098d230942242604",0)) //Initiate connection
  if (http.begin(client, url))
  {
    Serial.print("[HTTP] GET...\n");
    int httpCode = http.GET();  // Make request

    if (httpCode > 0) {
      Serial.printf("[HTTP] GET... code: %d\n", httpCode);

      if (httpCode == HTTP_CODE_OK || httpCode == HTTP_CODE_MOVED_PERMANENTLY) {
        String payload = http.getString();  // Get response
        Serial.println(payload);  // Display response via serial
      }
    }
    else {
      Serial.printf("[HTTP] GET... failed, error: %s\n", http.errorToString(httpCode).c_str());
    }

    http.end();
  }
  else {
    Serial.printf("[HTTP} Unable to connect\n");
  }

  delay(30000);
}
 * 
 * 
 * #include <WiFi.h>
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

*/
