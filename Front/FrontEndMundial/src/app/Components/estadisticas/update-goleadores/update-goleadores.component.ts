import { Goleadores } from 'src/app/models/Goleadores';
import { GoleadoresService } from 'src/app/services/estadisticas/goleadores.service';
import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { LoginService } from 'src/app/services/loginServices/login.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-update-goleadores',
  templateUrl: './update-goleadores.component.html',
  styleUrls: ['./update-goleadores.component.css'],
})
export class UpdateGoleadoresComponent {
  opcionSeleccionado: string = '0'; // Iniciamos
  opcion: string = '';
  id = 0;
  goles = 0;
  jugadorId = 0;
  nombreJugador = '';
  infoSeleccionada: any;
  goleadores!: Goleadores[];
  admin: boolean = false;
  subscripcion: Subscription = new Subscription();

  constructor(
    public goleadoresService: GoleadoresService,
    private servicioLogin: LoginService
  ) {}

  ngOnInit() {
    this.goleadoresService.getGoleadores_2();
    this.getDataGoleadores();

    this.subscripcion = this.servicioLogin
      .obtenerDatosUsuarioEnSesion()
      .subscribe((datos: any) => {
        if (datos) {
          this.admin = true;
        }
      });
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
    this.id = 0;
    this.jugadorId = 0;
    this.goles = 0;
    this.nombreJugador = '';
  }

  capturar() {
    this.opcion = this.opcionSeleccionado;
  }
  editar(posicion: any) {
    if (this.opcion === '0') {
      this.errorOpcion();
      this.nombreJugador = '';
      this.id = 0;
      this.goles = 0;
      this.jugadorId = 0;
    } else {
      const info = posicion;
      this.infoSeleccionada = info[parseInt(this.opcion) - 1];
      console.log(this.infoSeleccionada);

      this.nombreJugador = this.infoSeleccionada.nombreJugador;
      this.id = this.infoSeleccionada.id;
      this.goles = this.infoSeleccionada.goles;
      this.jugadorId = this.infoSeleccionada.jugadorId;
    }
  }

  enviarInfo() {
    let obj: Goleadores = {
      id: this.id,
      goles: this.goles,
      jugadorId: this.jugadorId,
      nombreJugador: this.nombreJugador,
    };
    if (obj.id === 0 || this.opcion === '0') {
      this.llenarDatosAlert();
    } else {
      console.log(obj);
      this.goleadoresService
        .updateGoleadores(this.id, obj)
        .subscribe((data) => {
          this.showAlert();
          setTimeout(() => {
            window.location.reload();
          }, 2000);
          console.log('Se actualizo');
        });
    }
  }

  //Llena el select:
  getDataGoleadores() {
    this.goleadoresService
      .getGoleadores()
      .subscribe((dataGol: Goleadores[]) => {
        this.goleadores = dataGol;
      });
  }
}
