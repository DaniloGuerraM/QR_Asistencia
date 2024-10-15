package com.example.asistenciaites;

import android.Manifest;
import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;


import com.google.type.DateTime;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;



public class PedirAsistenciaActivity extends AppCompatActivity {

    public Button botonVolver;
    public ListView textMostrar;
    //public Button buttonMis;

    public ArrayList<String> fechaMostrar;

    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_pedir_asistencia);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
        textMostrar = findViewById(R.id.MostrarAsistencia);

        botonVolver = findViewById(R.id.volver2);
        //buttonMis = findViewById(R.id.misAsistencia);

        ConnectivityManager connMgr = (ConnectivityManager) getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo networkInfo = connMgr.getActiveNetworkInfo();
        if (networkInfo != null && networkInfo.isConnected()) {
            get();
        } else {
            Toast.makeText(PedirAsistenciaActivity.this, "\"No conectado\"", Toast.LENGTH_SHORT).show();
            //textMostrar.setAdapter();
        }
        /*
        buttonMis.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ConnectivityManager connMgr = (ConnectivityManager) getSystemService(Context.CONNECTIVITY_SERVICE);
                NetworkInfo networkInfo = connMgr.getActiveNetworkInfo();
                if (networkInfo != null && networkInfo.isConnected()) {
                    get();
                } else {
                    Toast.makeText(PedirAsistenciaActivity.this, "\"No conectado\"", Toast.LENGTH_SHORT).show();
                    //textMostrar.setAdapter();
                }
            }
        });
        */
        botonVolver.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ParaAtras();
            }
        });
    }

    /*
                }*/

/////////////////////////////////////////////////////////////////////////////////

    public void get() {
       // textMostrar.setText("Haciendo un GET");

        SharedPreferences sharedPreferences = getSharedPreferences("LoginPrefs", Context.MODE_PRIVATE);
        int  dniGuardado = sharedPreferences.getInt("DNI", -1); // -1 es el valor predeterminado si no se encuentra la clave

        String url = "http://172.23.5.184:3002/api/RegistroAsistencia/"+dniGuardado;
        new GetAPI().execute(url);
    }

    private class GetAPI extends AsyncTask<String, Void, String> {

        @Override
        protected String doInBackground(String... urls) {
            try {
                return doGetRequest(urls[0]);
            } catch (Exception e) {
                e.printStackTrace();
                return null;
            }
        }

        @Override
        protected void onPostExecute(String result) {
            if (result != null) {

                try {
                    // Convertir el resultado en un JSONArray
                    JSONArray jsonArray = new JSONArray(result);
                    fechaMostrar = new ArrayList<String>();

                    for (int i = 0; i < jsonArray.length(); i++) {
                        JSONObject jsonObject = jsonArray.getJSONObject(i);

                        long fechaUnix = jsonObject.getLong("fecha");

                        // Multiplicamos por 1000 para convertir a milisegundos
                        Date date = new Date(fechaUnix * 1000L);

                        @SuppressLint("SimpleDateFormat")
                        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
                        String formattedDate = sdf.format(date);

                        fechaMostrar.add(formattedDate);

                    }
                    ArrayAdapter<String> fechaAdactada = new ArrayAdapter<String>(PedirAsistenciaActivity.this, android.R.layout.simple_list_item_1, fechaMostrar);
                    textMostrar.setAdapter(fechaAdactada);

                } catch (JSONException e) {
                    //textMostrar.setText("Error al procesar la respuesta JSON");
                    throw new RuntimeException(e);
                }

            } else {
                Toast.makeText(PedirAsistenciaActivity.this, "\"Error al realizar la solicitud\"", Toast.LENGTH_SHORT).show();
                //textMostrar.setText();
            }
        }
    }

    private String doGetRequest(String urlstr) throws MalformedURLException {
        HttpURLConnection urlConnection = null;
        BufferedReader reader = null;
        try {
            URL url = new URL(urlstr);

            urlConnection = (HttpURLConnection) url.openConnection();
            urlConnection.setRequestMethod("GET");
            urlConnection.connect();

            int responseCode = urlConnection.getResponseCode();
            //Toast.makeText(this, "\"HTTP GET\", \"Response Code: \" + responseCode", Toast.LENGTH_SHORT).show();
            //Log.d("HTTP GET", "Response Code: " + responseCode);

            if (responseCode != HttpURLConnection.HTTP_OK) {
                throw new IOException("Error de respuesta: " + responseCode);
            }

            reader = new BufferedReader(new InputStreamReader(urlConnection.getInputStream()));
            StringBuilder result = new StringBuilder();
            String line;

            while ((line = reader.readLine()) != null) {
                result.append(line);
            }

            //Toast.makeText(this, result.toString(), Toast.LENGTH_SHORT).show();
            //textMostrar.setText(result.toString());
            return result.toString();
        } catch (IOException e) {
            e.printStackTrace();
            return null;
        } finally {
            if (urlConnection != null) {
                urlConnection.disconnect();
            }
            if (reader != null) {
                try {
                    reader.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }
/////////////////////////////////////////////////////////////////////////////////


    public void ParaAtras(){
        Intent intent = new Intent(PedirAsistenciaActivity.this, EleccionActivity.class);
        startActivity(intent);
        finish();

    }
}