import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

//Componentes
import { NavBarComponent } from './Components/nav-bar/nav-bar.component';
import { FooterComponent } from './Components/footer/footer.component';
import { EstadisticasComponent } from './Components/estadisticas/estadisticas.component';
import { UpdateAsistenciasComponent } from './Components/estadisticas/update-asistencias/update-asistencias.component';
import { UpdateGoleadoresComponent } from './Components/estadisticas/update-goleadores/update-goleadores.component';
import { PosicionesComponent } from './Components/posiciones/posiciones.component';
import { FormularioUpdatePosicionesComponent } from './Components/posiciones/formularioUpdatePosiciones/formulario-update-posiciones.component';
import { AppComponent } from './app.component';
import { AddEditUsuariosComponent } from './Components/usuarios/add-edit-usuarios/add-edit-usuarios.component';
import { VerUsuariosComponent } from './Components/usuarios/ver-usuarios/ver-usuarios.component';
import { UpdateTarjetasRojasComponent } from './Components/estadisticas/update-tarjetas-rojas/update-tarjetas-rojas.component';
import { LoginComponent } from './Components/login/login.component';
import { JugadoresComponent } from './Components/jugadores/jugadores.component';
import { PartidosComponent } from './Components/partidos/partidos.component';
import { FormUpdatePartidosComponent } from './Components/partidos/form-update-partidos/form-update-partidos.component';
import { ErrorComponent } from './Components/error/error.component';

//Modulos
import { MaterialModuleModule } from './material-module/material-module.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    EstadisticasComponent,
    PartidosComponent,
    NavBarComponent,
    FooterComponent,
    PosicionesComponent,
    JugadoresComponent,
    LoginComponent,
    FormularioUpdatePosicionesComponent,
    FormUpdatePartidosComponent,
    UpdateAsistenciasComponent,
    UpdateGoleadoresComponent,
    AppComponent,
    AddEditUsuariosComponent,
    VerUsuariosComponent,
    UpdateGoleadoresComponent,
    UpdateAsistenciasComponent,
    UpdateTarjetasRojasComponent,
    ErrorComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModuleModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
