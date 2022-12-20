import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { Asistencia } from 'src/app/models/Asistencia';
import { AsistenciasService } from 'src/app/services/estadisticas/asistencias.service';
import { LoginService } from 'src/app/services/loginServices/login.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-update-asistencias',
  templateUrl: './update-asistencias.component.html',
  styleUrls: ['./update-asistencias.component.css'],
})
export class UpdateAsistenciasComponent {
  opcionSeleccionado: string = '0'; // Iniciamos
  opcion: string = '';
  id = 0;
  asistencias = 0;
  jugadorId = 0;
  nombreJugador = '';
  infoSeleccionada: any;
  admin: boolean = false;
  subscripcion: Subscription = new Subscription();
  asistente!: Asistencia[];

  constructor(
    public asistenciasservice: AsistenciasService,
    private servicioLogin: LoginService
  ) {}


  ngOnInit() {
    this.asistenciasservice.getAsistencias_2();
    this.getDataAsistencias();

    this.subscripcion = this.servicioLogin
      .obtenerDatosUsuarioEnSesion()
      .subscribe((datos: any) => {
        if (datos) {
          this.admin = true;
        }
      });
  }

  capturar() {
    this.opcion = this.opcionSeleccionado;
  }

  editar(posicion: any) {
    if (this.opcion === '0') {
      this.errorOpcion();
      this.nombreJugador = '';
      this.id = 0;
      this.asistencias = 0;
      this.jugadorId = 0;
    } else {
      const info = posicion;
      this.infoSeleccionada = info[parseInt(this.opcion) - 1];
      console.log(this.infoSeleccionada);

      this.nombreJugador = this.infoSeleccionada.nombreJugador;
      this.id = this.infoSeleccionada.id;
      this.asistencias = this.infoSeleccionada.asistencias;
      this.jugadorId = this.infoSeleccionada.jugadorId;
    }
  }

  showAlert() {
    Swal.fire({
      icon: 'success',
      title: 'Registro actualizado correctamente',
      showConfirmButton: false,
      timer: 2000,
    });
  }
  llenarDatosAlert() {
    Swal.fire({
      icon: 'error',
      title: 'Error al actualizar los datos',
      showConfirmButton: false,
      timer: 2000,
    });
  }
  errorOpcion() {
    Swal.fire({
      icon: 'error',
      title: 'No se pudo seleccionar un jugador',
      showConfirmButton: false,
      timer: 2000,
    });
  }

  limpiarFormulario() {
    this.opcionSeleccionado = '0';
    this.asistencias = 0;
    this.jugadorId = 0;
    this.nombreJugador = '';
  }

  enviarInfo() {
    let obj: Asistencia = {
      id: this.id,
      asistencias: this.asistencias,
      jugadorId: this.jugadorId,
      nombreJugador: this.nombreJugador,
    };
    if (obj.id === 0 || this.opcion === '0') {
      this.llenarDatosAlert();
    } else {
      console.log(obj);
      this.asistenciasservice
        .updateAsistencias(this.id, obj)
        .subscribe((data) => {
          this.asistenciasservice.getAsistencias_2;
          this.showAlert();
          setTimeout(() => {
            window.location.reload();
          }, 2000);

          console.log('Se actualizo');
        });
    }
  }

  //Llena el select:
  getDataAsistencias() {
    this.asistenciasservice
      .getAsistencias()
      .subscribe((dataGol: Asistencia[]) => {
        this.asistente = dataGol;
      });
  }
}
