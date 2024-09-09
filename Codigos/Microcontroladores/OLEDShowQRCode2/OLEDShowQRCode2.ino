

#include <Wire.h>
//#include <Adafruit_GFX.h>
//#include <Adafruit_SSD1306.h>
#include <qrcoderm.h>
#include <Arduino.h>
#include <U8g2lib.h>

#define SCREEN_WIDTH 128  
#define SCREEN_HEIGHT 64
#define OLED_RESET -1

long num= 0;
String id_aula = "001";
const int qrCodeVersion = 3;
const int pixelSize = 2;

//Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, OLED_RESET);

U8G2_SSD1306_128X64_NONAME_F_HW_I2C u8g2(U8G2_R0, /* reset=*/ U8X8_PIN_NONE);

void showQRCode(String qrCodeString) {

  QRCode qrcode;

  uint8_t qrcodeBytes[qrcode_getBufferSize(qrCodeVersion)];
  qrcode_initText(&qrcode, qrcodeBytes, qrCodeVersion, ECC_LOW,
                  qrCodeString.c_str());

  //display.clearDisplay();

  int startX = (SCREEN_WIDTH - (qrcode.size * pixelSize) - (pixelSize * 2))
               / 2;
  int startY = (SCREEN_HEIGHT - (qrcode.size * pixelSize) - (pixelSize * 2))
               / 2;

  // startX=0;
  // startY=0;


Serial.print("X: ");
Serial.println(startX);
Serial.print("Y: ");
Serial.println(startY);
  
  int qrCodeSize = qrcode.size;
Serial.print("qrCodeSize: ");
Serial.println(qrCodeSize);

  u8g2.setDrawColor(1);
  u8g2.clearBuffer();
  u8g2.drawRBox(startX, startY, (qrCodeSize * pixelSize) + (pixelSize * 2),(qrCodeSize * pixelSize) + (pixelSize * 2),1);
  u8g2.sendBuffer();
   
 // display.fillRect(startX, startY, (qrCodeSize * pixelSize) + (pixelSize * 2),
 //                  (qrCodeSize * pixelSize) + (pixelSize * 2), WHITE);


   
  u8g2.setDrawColor(0);
  
  for (uint8_t y = 0; y < qrCodeSize; y++) 
  {
    for (uint8_t x = 0; x < qrCodeSize; x++) {
      if (qrcode_getModule(&qrcode, x, y))
      {
        
        u8g2.drawRBox(x * pixelSize + startX + pixelSize,y * pixelSize + startY + pixelSize, pixelSize,
                         pixelSize,1);
        
        /*display.fillRect(x * pixelSize + startX + pixelSize,
                         y * pixelSize + startY + pixelSize, pixelSize,
                         pixelSize, BLACK);
        */
      }
      else 
      {
        //Serial.print("-,");
        
        }
      
    }
    //Serial.println();
  }
  u8g2.sendBuffer();
  
  //display.display();
    
}

void setup() {
  

  Serial.begin(9600);
  u8g2.begin();
 //display.begin(SSD1306_EXTERNALVCC, 0x3c);

  //showQRCode("https://cyberello.com");
  

}

void loop() {
  String qr = "";

  num = random(000000, 999999);
  qr = id_aula   + "-" + num;
  showQRCode(qr);
  Serial.println("-------------------------");
  Serial.println(num);
  Serial.println("-------------------------");

  delay(4000);
  //Serial.println("hola Mundo!!");
}
