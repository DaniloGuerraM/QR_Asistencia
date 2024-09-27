package com.example.asistenciaites;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class EleccionActivity extends AppCompatActivity {

    public Button botonTomar;
    public Button botonPedir;
    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_eleccion);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
        botonPedir = findViewById(R.id.pedirAsistencia);
        botonTomar = findViewById(R.id.tomarAsistencia);
        botonPedir.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                PedirAsistencia();
            }
        });
        botonTomar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                TomarAsistencia();
            }
        });
    }
    public void TomarAsistencia(){
        Intent intent = new Intent(EleccionActivity.this, TomarAsistenciaActivity.class);
        startActivity(intent);
    }
    public void PedirAsistencia(){
        Intent intent = new Intent(EleccionActivity.this, PedirAsistenciaActivity.class);
        startActivity(intent);
    }
}