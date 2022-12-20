import { Component } from '@angular/core';
import { TablaPosiciones } from 'src/app/models/TablaPosiciones';
import { TablaPosicionesService } from 'src/app/services/tablaPosiciones/tabla-posiciones.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-formulario-update-posiciones',
  templateUrl: './formulario-update-posiciones.component.html',
  styleUrls: ['./formulario-update-posiciones.component.css'],
})
export class FormularioUpdatePosicionesComponent {
  opcionSeleccionado: string = '0'; // Iniciamos
  opcion: string = '';
  posiciones: any = [];

  nombreEquipo: string = '';
  infoSeleccionada: any;
  pj: string = '';
  pg: string = '';
  pe: string = '';
  pp: string = '';
  gf: string = '';
  gc: string = '';
  pts: string = '';
  id: string = '';
  equipoId: string = '';

  constructor(public tablaPosicionesServices: TablaPosicionesService) {}

  ngOnInit() {
    this.tablaPosicionesServices.obtenerPosiciones();
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
      title: 'No se pudo seleccionar un equipo',
      showConfirmButton: false,
      timer: 2000,
    });
}
  capturar() {
    this.opcion = this.opcionSeleccionado;
  }

  limpiarFormulario() {
    this.opcionSeleccionado = '0';
    this.nombreEquipo = '';
    this.id = '';
    this.pj = '';
    this.pg = '';
    this.pe = '';
    this.pp = '';
    this.gf = '';
    this.gc = '';
    this.pts = '';
    this.equipoId = '';
  }

  editar(posicion: any) {
    if (this.opcion==='0') {
      this.errorOpcion()
      this.id = '';
      this.pj = '';
      this.pg = '';
      this.pe = '';
      this.pp = '';
      this.gf = '';
      this.gc = '';
      this.pts = '';
      this.equipoId = '';
     }else{
 
    const info = posicion;
    this.infoSeleccionada = info[parseInt(this.opcion) - 1];
    console.log(this.infoSeleccionada);

    this.nombreEquipo = this.infoSeleccionada.nombreEquipo;
    this.id = this.infoSeleccionada.id;
    this.pj = this.infoSeleccionada.pj;
    this.pg = this.infoSeleccionada.pg;
    this.pe = this.infoSeleccionada.pe;
    this.pp = this.infoSeleccionada.pp;
    this.gf = this.infoSeleccionada.gf;
    this.gc = this.infoSeleccionada.gc;
    this.pts = this.infoSeleccionada.puntos;
    this.equipoId = this.infoSeleccionada.equipoId;
  }
}

  enviarInfo() {
    let obj: TablaPosiciones = {
      id: parseInt(this.id),
      pj: parseInt(this.pj),
      pg: parseInt(this.pg),
      pe: parseInt(this.pe),
      pp: parseInt(this.pp),
      gf: parseInt(this.gf),
      gc: parseInt(this.gc),
      puntos: parseInt(this.pts),
      equipoId: parseInt(this.equipoId),
      nombreEquipo: this.nombreEquipo,
    };
    if (
      Number.isNaN(obj.id) ||
      Number.isNaN(obj.pj) ||
      Number.isNaN(obj.pg) ||
      Number.isNaN(obj.pe) ||
      Number.isNaN(obj.pp) ||
      Number.isNaN(obj.gf) ||
      Number.isNaN(obj.gc) ||
      Number.isNaN(obj.puntos) ||
      Number.isNaN(obj.equipoId)
    ) {
      this.llenarDatosAlert();
    } else {
      this.tablaPosicionesServices
        .actualizarPosciones(parseInt(this.id), obj)
        .subscribe((data) => {
          this.tablaPosicionesServices.obtenerPosiciones();

          console.log('Se actualizo');
          this.showAlert();
          this.limpiarFormulario();
        });
    }
  }
}
