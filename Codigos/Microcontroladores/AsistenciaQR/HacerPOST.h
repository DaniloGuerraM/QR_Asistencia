

void Post(String codigo);
void Post(String codigo){
  if (WiFi.status() == WL_CONNECTED) {
    HTTPClient http;
    http.begin(serverUrl);
    http.addHeader("Content-Type", "application/json");
    
    String postData = "{\"nombre\": \"ESP32\", \"valor\": "+ codigo+"}";
    
    int httpResponseCode = http.POST(postData);
    
    if (httpResponseCode > 0) {
      Serial.println(httpResponseCode);
      String response = http.getString();
      Serial.println("Respuesta del servidor:");
      Serial.println(response);
    } else {
      Serial.print("Error en la solicitud POST. Código de error: ");
      Serial.println(httpResponseCode);
    }
    http.end();
  }
  delay(10000);
}
