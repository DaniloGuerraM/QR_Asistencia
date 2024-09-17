
#include <Wire.h>
#include <qrcoderm.h>
#include <Arduino.h>
#include <WiFi.h>
#include <HTTPClient.h>


#include <U8g2lib.h>


#define SCREEN_WIDTH 128  
#define SCREEN_HEIGHT 64
#define OLED_RESET -1


String id_aula = "001";

const char* ssid = "laboratorio";
const char* password = "laboratorio";
const char* serverUrl = "http://172.23.5.195:3001/holamundo/prueba";

//Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, OLED_RESET);

U8G2_SSD1306_128X64_NONAME_F_HW_I2C u8g2(U8G2_R0, /* reset=*/ U8X8_PIN_NONE);

const int pinEsp = 35;

String mostrar = "";
