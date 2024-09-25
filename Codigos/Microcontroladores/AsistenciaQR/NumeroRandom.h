
long valor = 0; 
String codificacion();

String codificacion(){
    String qr = "";
    valor = random(000000, 999999);
    qr = id_aula   + "-" + valor;
    return qr;
}
