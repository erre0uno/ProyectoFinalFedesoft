import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { TarjetaRoja } from 'src/app/models/TarjetaRoja';
import { TarjetasrojasService } from 'src/app/services/estadisticas/tarjetasrojas.service';
import { LoginService } from 'src/app/services/loginServices/login.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-update-tarjetas-rojas',
  templateUrl: './update-tarjetas-rojas.component.html',
  styleUrls: ['./update-tarjetas-rojas.component.css'],
})
export class UpdateTarjetasRojasComponent {
  opcionSeleccionado: string = '0'; // Iniciamos
  opcion: string = '';
  id = 0;
  tarjetasrojas = 0;
  jugadorId = 0;
  nombreJugador = '';
  infoSeleccionada: any;
  admin: boolean = false;
  subscripcion: Subscription = new Subscription();
  expulsado!: TarjetaRoja[];

  constructor(
    public tarjetasrojasservice: TarjetasrojasService,
    private servicioLogin: LoginService
  ) {}

  ngOnInit() {
    this.tarjetasrojasservice.getTarjetasRojas_2();
    this.getDataTarjetasRojas();

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
    this.tarjetasrojas = 0;
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
      this.tarjetasrojas = 0;
      this.jugadorId = 0;
    } else {
      const info = posicion;
      this.infoSeleccionada = info[parseInt(this.opcion) - 1];
      console.log(this.infoSeleccionada);

      this.nombreJugador = this.infoSeleccionada.nombreJugador;
      this.id = this.infoSeleccionada.id;
      this.tarjetasrojas = this.infoSeleccionada.numero;
      this.jugadorId = this.infoSeleccionada.jugadorId;
    }
  }
  enviarInfo() {
    let obj: TarjetaRoja = {
      id: this.id,
      numero: this.tarjetasrojas,
      jugadorId: this.jugadorId,
      nombreJugador: this.nombreJugador,
    };
    if (obj.id === 0 || this.opcion === '0') {
      this.llenarDatosAlert();
    } else {
      this.tarjetasrojasservice
        .updateTarjetasRojas(this.id, obj)
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
  getDataTarjetasRojas() {
    this.tarjetasrojasservice
      .getTarjetasRojas()
      .subscribe((dataTR: TarjetaRoja[]) => {
        this.expulsado = dataTR;
      });
  }
}
